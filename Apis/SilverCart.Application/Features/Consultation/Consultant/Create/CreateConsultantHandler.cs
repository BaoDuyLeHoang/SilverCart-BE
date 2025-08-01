using Infrastructures.Commons.Exceptions;
using Infrastructures.Interfaces.System;
using Infrastructures.Services.System;
using MediatR;
using Microsoft.AspNetCore.Identity;
using SilverCart.Application.Interfaces;
using SilverCart.Domain.Entities;
using SilverCart.Domain.Entities.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructures.Features.Consultation.Consultant.Create
{
    public sealed record CreateConsultantCommand(
       string Email,
       string Password,
       string Phone,
       string FullName,
       string Gender,
       RegisterUserAddress Address,
       string Specialization,
       string? CertificationDocumentLink = null
   ) : IRequest<Guid>;
    public class CreateConsultantHandler(
       IUnitOfWork unitOfWork,
       UserManager<BaseUser> userManager,
       ICurrentTime currentTime,
       IStringeeService stringeeService
   ) : IRequestHandler<CreateConsultantCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly UserManager<BaseUser> _userManager = userManager;
        private readonly ICurrentTime _currentTime = currentTime;
        private readonly IStringeeService _stringeeService = stringeeService;

        public async Task<Guid> Handle(CreateConsultantCommand request, CancellationToken cancellationToken)
        {
            var checkMailExist = await _userManager.FindByEmailAsync(request.Email);
            if (checkMailExist != null)
                throw new AppExceptions("Email already exists");

            var checkPhoneExist = await _unitOfWork.UserRepository.GetAllAsync(x => x.PhoneNumber == request.Phone);
            if (checkPhoneExist.Any())
                throw new AppExceptions("Phone number already exists");

            var consultantUser = new SilverCart.Domain.Entities.Auth.ConsultantUser
            {
                FullName = request.FullName,
                Email = request.Email,
                PhoneNumber = request.Phone,
                UserName = request.Email,
                Gender = request.Gender,
                CreationDate = _currentTime.GetCurrentTime(),
                Specialization = request.Specialization,
            };

            var address = new SavedAddress
            {
                StreetAddress = request.Address.StreetAddress,
                WardCode = request.Address.WardCode ?? string.Empty,
                DistrictId = request.Address.DistrictId,
                DistrictName = request.Address.ToDistrictName ?? string.Empty,
                ProvinceName = request.Address.ToProvinceName ?? string.Empty
            };
            consultantUser.Addresses.Add(address);

            var createResult = await _userManager.CreateAsync(consultantUser, request.Password);
            if (!createResult.Succeeded)
            {
                var errors = string.Join("; ", createResult.Errors.Select(e => e.Description));
                throw new AppExceptions(errors);
            }

            var roleResult = await _userManager.AddToRoleAsync(consultantUser, "Consultant");
            if (!roleResult.Succeeded)
            {
                var errors = string.Join("; ", roleResult.Errors.Select(e => e.Description));
                throw new AppExceptions(errors);
            }

            // Register with video call platform
            var stringeeUserToken = await _stringeeService.RegisterUserAsync(new StringeeUserRegistrationRequest
            {
                UserId = consultantUser.Id.ToString(),
                FullName = consultantUser.FullName,
                Email = consultantUser.Email,
                Role = "Consultant"
            });

            await _unitOfWork.ConsultantUserRepository.AddAsync(consultantUser);
            await _unitOfWork.SaveChangeAsync();

            return consultantUser.Id;
        }
    }

}

