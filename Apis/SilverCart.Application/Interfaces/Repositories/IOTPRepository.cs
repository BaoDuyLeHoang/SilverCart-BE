using SilverCart.Domain.Entities;

namespace SilverCart.Application.Repositories;

public interface IOTPRepository
{
    Task<OTPData?> GetByCodeAsync(string code);
    Task<OTPData?> GetActiveOTPAsync(string code, OTPTypeEnum type);
    Task<OTPData?> GetByVerificationIdAsync(Guid verificationId);
    Task<IEnumerable<OTPData>> GetByUserIdAsync(Guid userId);
    Task<bool> MarkAsUsedAsync(string code);
    Task<bool> IsValidAsync(string code, OTPTypeEnum type);
    Task CreateOTPAsync(OTPData otp); // New method to create OTP
}
