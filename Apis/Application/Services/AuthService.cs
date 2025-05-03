using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using Application.Commons;
using Application.Interfaces;
using Application.Utils;
using Application.ViewModels.UserViewModels;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.IdentityModel.Tokens;

namespace Application.Services;

public class AuthService : IAuthService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly ICurrentTime _currentTime;
    private readonly AppConfiguration _configuration;
    private readonly IWebHostEnvironment _env;
    private readonly IEmailService _emailService;
    private readonly ISMSService _smsService;


    public AuthService(
        IUnitOfWork unitOfWork,
        IMapper mapper,
        ICurrentTime currentTime,
        AppConfiguration configuration,
        IWebHostEnvironment env,
        IEmailService emailService,
        ISMSService smsService)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _currentTime = currentTime;
        _configuration = configuration;
        _env = env;
        _emailService = emailService;
        _smsService = smsService;
    }

    public async Task<Result<TokenResponseDTO>> LoginAsync(LoginUserDTO loginUserObject)
    {
        var user = await _unitOfWork.UserRepository.GetUserByEmail(loginUserObject.Email);
        if (user == null)
        {
            return Result<TokenResponseDTO>.Failure("User not found", HttpStatusCode.NotFound);
        }

        if (!user.IsVerified)
        {
            return Result<TokenResponseDTO>.Failure("User account is not verified", HttpStatusCode.Unauthorized);
        }

        if (!user.PasswordHash.VerifyPassword(loginUserObject.Password))
        {
            return Result<TokenResponseDTO>.Failure("Invalid password", HttpStatusCode.Unauthorized);
        }

        var tokenResponse = await GenerateTokenResponse(user);
        return Result<TokenResponseDTO>.Success(tokenResponse);
    }

    public async Task<Result<TokenResponseDTO>> LoginSuperAdmin(LoginUserDTO loginDTO)
    {
        var user = await _unitOfWork.UserRepository.GetAdminUserByEmail(_configuration.SuperAdmin.Email);

        if (user == null)
        {
            return Result<TokenResponseDTO>.Failure("Super admin does not exist", HttpStatusCode.NotFound);
        }

        if (user.PasswordHash.VerifyPassword(loginDTO.Password))
        {
            return Result<TokenResponseDTO>.Failure("Invalid credentials", HttpStatusCode.Unauthorized);
        }

        var tokenResponse = await GenerateTokenResponse(user);
        return Result<TokenResponseDTO>.Success(tokenResponse);
    }

    public async Task<Result<string>> RegisterAsync(RegisterUserDTO registerUserObject)
    {
        // Validation (Kiểm tra đầu vào)
        if (string.IsNullOrEmpty(registerUserObject.Email) && string.IsNullOrEmpty(registerUserObject.Phone))
        {
            return Result<string>.Failure("Please provide Phone or Email", HttpStatusCode.BadRequest);
        }

        if (!_configuration.IsDevelopment && string.IsNullOrEmpty(registerUserObject.Email) &&
            string.IsNullOrEmpty(registerUserObject.Phone))
        {
            return Result<string>.Failure("Please provide only Phone or Email", HttpStatusCode.BadRequest);
        }

        // Check existing user (Kiểm tra user đã tồn tại)
        if (!string.IsNullOrEmpty(registerUserObject.Email) &&
            await _unitOfWork.UserRepository.CheckEmailExisted(registerUserObject.Email))
        {
            return Result<string>.Failure("Email already exists", HttpStatusCode.Conflict);
        }

        if (!string.IsNullOrEmpty(registerUserObject.Phone) &&
            await _unitOfWork.UserRepository.CheckPhoneExisted(registerUserObject.Phone))
        {
            return Result<string>.Failure("Phone already exists", HttpStatusCode.Conflict);
        }

        // Create new user (Tạo user mới)
        var newUser = _mapper.Map<RegisterUserDTO, CustomerUser>(registerUserObject);
        await using var transaction = await _unitOfWork.BeginTransactionAsync();
        Result<string>? result = null;

        if (!string.IsNullOrEmpty(registerUserObject.Email))
        {
            var verificationToken = StringUtils.GenerateVerifyToken();
            newUser.RefreshToken = verificationToken;

            await _unitOfWork.UserRepository.AddAsync(newUser);

            await _emailService.SendVerificationEmail(newUser.Email, verificationToken);

            result = Result<string>.Success(verificationToken, HttpStatusCode.Created);
        }

        if (!string.IsNullOrEmpty(registerUserObject.Phone))
        {
            var otpCode = StringUtils.GenerateOTPCode();
            newUser.OTP = OTPData.Init(otpCode, 1);

            await _unitOfWork.UserRepository.AddAsync(newUser);


            // Send OTP based on environment
            var recipient = _configuration.IsDevelopment ? registerUserObject.Email : registerUserObject.Phone;
            await _smsService.SendOTPSMS(recipient, otpCode);

            result = Result<string>.Success(otpCode, HttpStatusCode.Created);
        }

        if (result != null && result.IsSuccess)
        {
            await _unitOfWork.SaveChangeAsync();

            await transaction.CommitAsync();
            return result;
        }

        return Result<string>.Failure("Invalid registration data", HttpStatusCode.BadRequest);
    }

    public async Task<Result<string>> VerifyEmailAsync(string token, string email)
    {
        var user = await _unitOfWork.UserRepository.GetUserByEmail(email);

        if (user == null)
        {
            return Result<string>.Failure("User not found", HttpStatusCode.NotFound);
        }

        if (user.RefreshToken != token)
        {
            return Result<string>.Failure("Invalid verification token", HttpStatusCode.BadRequest);
        }

        user.IsVerified = true;
        user.RefreshToken = null;


        return Result<string>.Success("Email verified successfully");
    }

    public async Task<Result<string>> VerifyOTPAsync(string otp, string phoneNumber)
    {
        BaseUser? user;

        user = await _unitOfWork.UserRepository.GetUserByPhone(phoneNumber);

        if (user == null)
        {
            return Result<string>.Failure("User not found", HttpStatusCode.NotFound);
        }

        if (user.OTP.Code != otp)
        {
            return Result<string>.Failure("Invalid OTP");
        }

        if (user.OTP.IsUsed)
        {
            return Result<string>.Failure("OTP has already been used");
        }

        if (user.OTP.ExpirationTime < _currentTime.GetCurrentTime())
        {
            return Result<string>.Failure("OTP has expired");
        }

        user.OTP.IsUsed = true;
        user.IsVerified = true;
        user.RefreshToken = null;

        await _unitOfWork.SaveChangeAsync();


        return Result<string>.Success("OTP verified successfully");
    }

    public async Task<Result<TokenResponseDTO>> RefreshTokenAsync(string refreshToken)
    {
        var user = await _unitOfWork.UserRepository.GetUserByRefreshToken(refreshToken);

        if (user == null)
        {
            return Result<TokenResponseDTO>.Failure("Invalid refresh token", HttpStatusCode.BadRequest);
        }

        var tokenResponse = await GenerateTokenResponse(user);
        return Result<TokenResponseDTO>.Success(tokenResponse);
    }

    public async Task<Result> RevokeTokenAsync(string refreshToken)
    {
        var user = await _unitOfWork.UserRepository.GetUserByRefreshToken(refreshToken);

        if (user == null)
        {
            return Result.Failure("Invalid refresh token", HttpStatusCode.BadRequest);
        }

        user.RefreshToken = null;


        return Result.Success(HttpStatusCode.NoContent);
    }


    public async Task<Result<BaseUser>> CreateUser(RegisterUserDTO registerUserDTO, int roleId)
    {
        var isExisted = await _unitOfWork.UserRepository.CheckEmailExisted(registerUserDTO.Email);

        if (isExisted)
        {
            return Result<BaseUser>.Failure("Email already exists", HttpStatusCode.Conflict);
        }

        BaseUser newUser;

        switch (roleId)
        {
            case 1: // Admin
                newUser = new AdministratorUser
                {
                    Email = registerUserDTO.Email,
                    PasswordHash = registerUserDTO.Password.Hash(),
                    FirstName = registerUserDTO.FirstName,
                    LastName = registerUserDTO.LastName,
                    Phone = registerUserDTO.Phone,
                    IsVerified = true,
                    SignInTime = _currentTime.GetCurrentTime()
                };
                break;
            case 2: // Store User
                newUser = new StoreUser
                {
                    Email = registerUserDTO.Email,
                    PasswordHash = registerUserDTO.Password.Hash(),
                    FirstName = registerUserDTO.FirstName,
                    LastName = registerUserDTO.LastName,
                    Phone = registerUserDTO.Phone,
                    IsVerified = true,
                    SignInTime = _currentTime.GetCurrentTime()
                };
                break;
            default: // Customer
                newUser = new CustomerUser
                {
                    Email = registerUserDTO.Email,
                    PasswordHash = registerUserDTO.Password.Hash(),
                    FirstName = registerUserDTO.FirstName,
                    LastName = registerUserDTO.LastName,
                    Phone = registerUserDTO.Phone,
                    IsVerified = true,
                    SignInTime = _currentTime.GetCurrentTime()
                };
                break;
        }

        await _unitOfWork.UserRepository.AddAsync(newUser);

        return Result<BaseUser>.Success(newUser, HttpStatusCode.Created);
    }

    private async Task<TokenResponseDTO> GenerateTokenResponse(BaseUser user)
    {
        // Generate JWT token
        var accessToken =
            GenerateTokenString.GenerateJsonWebToken(user, _configuration.JWTSecretKey, _currentTime.GetCurrentTime());

        // Generate refresh token
        var refreshToken = StringUtils.GenerateVerifyToken();

        // Save refresh token to user
        user.RefreshToken = refreshToken;
        user.SignInTime = _currentTime.GetCurrentTime();
        await _unitOfWork.SaveChangeAsync();

        return new TokenResponseDTO
        {
            AccessToken = accessToken,
            RefreshToken = refreshToken,
            Expiration = _currentTime.GetCurrentTime().AddMinutes(15) // Token expires in 15 minutes
        };
    }
}