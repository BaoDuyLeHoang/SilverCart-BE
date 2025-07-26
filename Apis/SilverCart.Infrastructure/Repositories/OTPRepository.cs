
using Core.Interfaces;
using SilverCart.Application.Repositories;
using SilverCart.Domain.Entities;

namespace Infrastructures.Repositories;

public class OTPRepository : IOTPRepository
{
    private readonly IRedisService _redis;
    private const string OTP_PREFIX = "otp:";
    private const string OTP_USER_PREFIX = "otp:user:";
    private const string OTP_VERIFICATION_PREFIX = "otp:verification:";

    public OTPRepository(IRedisService redis)
    {
        _redis = redis;
    }

    public async Task<OTPData?> GetByCodeAsync(string code)
    {
        var otpJson = await _redis.GetAsync<OTPData>($"{OTP_PREFIX}{code}");
        if (otpJson == null)
            return null;

        return otpJson;
    }

    public async Task<OTPData?> GetActiveOTPAsync(string code, OTPTypeEnum type)
    {
        var otp = await GetByCodeAsync(code);
        if (otp == null || otp.Type != type || otp.IsUsed || otp.ExpirationTime <= DateTime.UtcNow)
            return null;

        return otp;
    }

    public async Task<OTPData?> GetByVerificationIdAsync(Guid verificationId)
    {
        var key = $"{OTP_VERIFICATION_PREFIX}{verificationId}";
        var otpCode = await _redis.GetAsync<string>(key);
        if (otpCode == null)
            return null;

        return await GetByCodeAsync(otpCode);
    }

    public async Task<IEnumerable<OTPData>> GetByUserIdAsync(Guid userId)
    {
        var key = $"{OTP_USER_PREFIX}{userId}";
        var otpCodesJson = await _redis.GetAsync<List<string>>(key);
        if (otpCodesJson == null)
            return Enumerable.Empty<OTPData>();

        var otpCodes = otpCodesJson;
        var result = new List<OTPData>();

        foreach (var code in otpCodes)
        {
            var otp = await GetByCodeAsync(code);
            if (otp != null)
                result.Add(otp);
        }

        return result;
    }

    public async Task<bool> MarkAsUsedAsync(string code)
    {
        var otp = await GetByCodeAsync(code);
        if (otp == null || otp.IsUsed)
            return false;

        otp.IsUsed = true;
        await _redis.SetAsync(
            $"{OTP_PREFIX}{code}",
            otp,
            TimeSpan.FromMinutes(5) // Keep used OTPs for a short time
        );

        return true;
    }

    public async Task<bool> IsValidAsync(string code, OTPTypeEnum type)
    {
        var otp = await GetActiveOTPAsync(code, type);
        return otp != null;
    }

    // Helper method to store a new OTP in Redis
    public async Task CreateOTPAsync(OTPData otp)
    {
        // Store the main OTP data with expiration matching the OTP expiration
        var expiryTime = otp.ExpirationTime - DateTime.UtcNow;
        if (expiryTime <= TimeSpan.Zero)
            return;

        await _redis.SetAsync(
            $"{OTP_PREFIX}{otp.Code}",
            otp,
            expiryTime
        );

        // Store verification ID reference
        await _redis.SetAsync(
            $"{OTP_VERIFICATION_PREFIX}{otp.VerificationToId}",
            otp,
            expiryTime
        );

        // Add to user's OTP list
        var userKey = $"{OTP_USER_PREFIX}{otp.UserId}";
        var existingCodesJson = await _redis.GetAsync<List<string>>(userKey);
        var codes = existingCodesJson ?? new List<string>();

        codes.Add(otp.Code);
        await _redis.SetAsync(
                    userKey,
            codes,
            TimeSpan.FromDays(7) // Keep user's OTP list for a week
        );
    }
}
