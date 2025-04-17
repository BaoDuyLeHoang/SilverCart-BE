// Application/Services/UserService.cs

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Application.Commons;
using Application.Interfaces;
using Application.Utils;
using Application.ViewModels.UserViewModels;
using AutoMapper;
using Domain.Entities;
using Microsoft.IdentityModel.Tokens;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ICurrentTime _currentTime;
        private readonly AppConfiguration _configuration;
        private readonly IEmailService _emailService;

        public UserService(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            ICurrentTime currentTime,
            AppConfiguration configuration,
            IEmailService emailService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _currentTime = currentTime;
            _configuration = configuration;
            _emailService = emailService;
        }

        public async Task<TokenResponseDTO> LoginAsync(UserLoginDTO userObject)
        {
            var user = await _unitOfWork.UserRepository.GetUserByUserNameAndPasswordHash(
                userObject.Email, userObject.Password.Hash());

            return await GenerateTokenResponse(user);
        }

        public async Task<TokenResponseDTO> LoginSuperAdmin(UserLoginDTO loginObject)
        {
            if (loginObject.Email != _configuration.SuperAdmin.Username ||
                loginObject.Password != _configuration.SuperAdmin.Password)
            {
                throw new Exception("Invalid super admin credentials");
            }

            var user = await _unitOfWork.UserRepository.GetAdminUserByUsername(_configuration.SuperAdmin.Username);
            if (user == null)
            {
                throw new Exception("Super admin does not exist");
            }

            return await GenerateTokenResponse(user);
        }

        public async Task RegisterAsync(UserLoginDTO userObject)
        {
            var isExited = await _unitOfWork.UserRepository.CheckUserNameExited(userObject.Email);

            if (isExited)
            {
                throw new Exception("Email already exists");
            }

            var newUser = new CustomerUser
            {
                Email = userObject.Email,
                PasswordHash = userObject.Password.Hash(),
                IsVerified = false,
                SignInTime = _currentTime.GetCurrentTime(),
                FirstName = string.Empty,
                LastName = string.Empty,
                PhoneNumber = string.Empty
            };

            // Generate verification token
            var verificationToken = GenerateRandomToken();
            newUser.RefreshToken = verificationToken;

            await _unitOfWork.UserRepository.AddAsync(newUser);
            await _unitOfWork.SaveChangeAsync();

            // Send verification email (Implement IEmailService interface)
            await _emailService.SendVerificationEmail(newUser.Email, verificationToken);
        }

        public async Task<string> VerifyEmailAsync(string token, string email)
        {
            var user = await _unitOfWork.UserRepository.GetUserByEmail(email);

            if (user == null)
            {
                throw new Exception("User not found");
            }

            if (user.RefreshToken != token)
            {
                throw new Exception("Invalid verification token");
            }

            user.IsVerified = true;
            user.RefreshToken = null;

            await _unitOfWork.SaveChangeAsync();
            return "Email verified successfully";
        }

        public async Task<TokenResponseDTO> RefreshTokenAsync(string refreshToken)
        {
            var user = await _unitOfWork.UserRepository.GetUserByRefreshToken(refreshToken);

            if (user == null)
            {
                throw new Exception("Invalid refresh token");
            }

            return await GenerateTokenResponse(user);
        }

        public async Task RevokeTokenAsync(string refreshToken)
        {
            var user = await _unitOfWork.UserRepository.GetUserByRefreshToken(refreshToken);

            if (user == null)
            {
                throw new Exception("Invalid refresh token");
            }

            user.RefreshToken = null;
            await _unitOfWork.SaveChangeAsync();
        }

        public async Task<BaseUser> CreateUser(UserRegisterDTO userRegisterDTO, int roleId)
        {
            var isExited = await _unitOfWork.UserRepository.CheckUserNameExited(userRegisterDTO.Email);

            if (isExited)
            {
                throw new Exception("Email already exists");
            }

            BaseUser newUser;

            switch (roleId)
            {
                case 1: // Admin
                    newUser = new AdministratorUser
                    {
                        Email = userRegisterDTO.Email,
                        PasswordHash = userRegisterDTO.Password.Hash(),
                        FirstName = userRegisterDTO.FirstName,
                        LastName = userRegisterDTO.LastName,
                        PhoneNumber = userRegisterDTO.PhoneNumber,
                        IsVerified = true,
                        SignInTime = _currentTime.GetCurrentTime()
                    };
                    break;
                case 2: // Store User
                    newUser = new StoreUser
                    {
                        Email = userRegisterDTO.Email,
                        PasswordHash = userRegisterDTO.Password.Hash(),
                        FirstName = userRegisterDTO.FirstName,
                        LastName = userRegisterDTO.LastName,
                        PhoneNumber = userRegisterDTO.PhoneNumber,
                        IsVerified = true,
                        SignInTime = _currentTime.GetCurrentTime()
                    };
                    break;
                default: // Customer
                    newUser = new CustomerUser
                    {
                        Email = userRegisterDTO.Email,
                        PasswordHash = userRegisterDTO.Password.Hash(),
                        FirstName = userRegisterDTO.FirstName,
                        LastName = userRegisterDTO.LastName,
                        PhoneNumber = userRegisterDTO.PhoneNumber,
                        IsVerified = true,
                        SignInTime = _currentTime.GetCurrentTime()
                    };
                    break;
            }

            await _unitOfWork.UserRepository.AddAsync(newUser);
            await _unitOfWork.SaveChangeAsync();

            return newUser;
        }

        public async Task CreateSuperAdminIfNotExists()
        {
            var superAdminExists =
                await _unitOfWork.UserRepository.CheckUserNameExited(_configuration.SuperAdmin.Username);

            if (!superAdminExists)
            {
                var superAdmin = new AdministratorUser
                {
                    Email = _configuration.SuperAdmin.Username,
                    PasswordHash = _configuration.SuperAdmin.Password.Hash(),
                    FirstName = "Super",
                    LastName = "Admin",
                    PhoneNumber = "",
                    IsVerified = true,
                    SignInTime = _currentTime.GetCurrentTime()
                };

                await _unitOfWork.UserRepository.AddAsync(superAdmin);
                await _unitOfWork.SaveChangeAsync();
            }
        }

        private async Task<TokenResponseDTO> GenerateTokenResponse(BaseUser user)
        {
            // Generate JWT token
            var accessToken = GenerateJwtToken(user);

            // Generate refresh token
            var refreshToken = GenerateRandomToken();

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

        private string GenerateJwtToken(BaseUser user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration.JWTSecretKey);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}"),
                new Claim(ClaimTypes.Role, DetermineUserRole(user))
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = _currentTime.GetCurrentTime().AddMinutes(15), // 15 minutes
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        private string GenerateRandomToken()
        {
            var randomBytes = new byte[64];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomBytes);
            return Convert.ToBase64String(randomBytes);
        }

        private string DetermineUserRole(BaseUser user)
        {
            if (user is AdministratorUser)
            {
                if (user.Email == _configuration.SuperAdmin.Username)
                    return "SuperAdmin";
                return "Admin";
            }
            else if (user is StoreUser)
                return "Store";
            else if (user is CustomerUser)
                return "Customer";

            return "User";
        }
    }
}