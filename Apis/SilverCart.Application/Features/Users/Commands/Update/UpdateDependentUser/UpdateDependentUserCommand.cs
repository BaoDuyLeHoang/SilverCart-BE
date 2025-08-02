using MediatR;

namespace Infrastructures.Features.Users.Commands.Update.UpdateDependentUser;

public sealed record UpdateDependentUserCommand(
    Guid Id,
    string? FullName = null,
    DateTime? DateOfBirth = null,
    string? Relationship = null,
    string? PhoneNumber = null,
    string? MedicalNotes = null,
    decimal? MonthlySpendingLimit = null,
    Guid? AddressId = null,
    string? ImageUrl = null
) : IRequest<UpdateDependentUserResponse>;

public record UpdateDependentUserResponse(
    Guid Id,
    string FullName,
    DateTime? DateOfBirth,
    string? Relationship,
    string PhoneNumber,
    string? MedicalNotes,
    decimal? MonthlySpendingLimit,
    Guid? AddressId,
    string? ImageUrl
);