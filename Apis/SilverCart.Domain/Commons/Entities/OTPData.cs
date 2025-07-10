public class OTPData
    {
        public string Code { get; set; } = string.Empty;
        public DateTime ExpirationTime { get; set; }
        public bool IsUsed { get; set; } = false;

        public static OTPData Init(string code, int days) => new OTPData()
        {
            Code = code,
            ExpirationTime = DateTime.UtcNow.AddDays(days),
            IsUsed = false
        };
    }