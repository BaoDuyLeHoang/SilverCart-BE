using MediatR;
using SilverCart.Domain.Enums;

namespace Infrastructures.Features.Users.Commands.Update.UpdateDependentUser;

public sealed record UpdateDependentUserCommand(
    Guid Id,
    string? FullName = null,
    DateTime? DateOfBirth = null,
    RelationshipEnum? Relationship = null,
    string? PhoneNumber = null,
    string? MedicalNotes = null,
    decimal? MonthlySpendingLimit = null,
    Guid? AddressId = null,
    string? ImageUrl = null,
    List<int>? SuggestedCategoryIds = null
) : IRequest<UpdateDependentUserResponse>;

public record UpdateDependentUserResponse(
    Guid Id,
    string FullName,
    DateTime? DateOfBirth,
    RelationshipEnum Relationship,
    string PhoneNumber,
    string? MedicalNotes,
    decimal? MonthlySpendingLimit,
    Guid? AddressId,
    string? ImageUrl,
    List<int>? SuggestedCategoryIds
);