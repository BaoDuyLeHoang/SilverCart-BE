using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SilverCart.Domain.Common.Interfaces;

namespace SilverCart.Domain.Entities;

public class OTPData : BaseEntity
{

    [StringLength(10, MinimumLength = 6)]
    public string Code { get; set; } = string.Empty;
    public Guid VerificationToId { get; set; }
    public DateTime ExpirationTime { get; set; }
    public OTPTypeEnum Type { get; set; }
    public bool IsUsed { get; set; } = false;

    public static OTPData Init(string code, int days) => new OTPData()
    {
        Code = code,
        ExpirationTime = DateTime.UtcNow.AddDays(days),
        IsUsed = false
    };

    public Guid? UserId { get; set; }
}