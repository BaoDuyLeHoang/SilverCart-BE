namespace Application.Utils;

public static class SMSUtils
{
    public static string GenerateRandomToken()
    {
        Random random = new Random();
        string token = random.Next(100000, 999999).ToString();
        return token;
    }

    public static void SendSMS(string phoneNumber, string message)
    {
        #region Development
            
        #endregion

        // Implement your SMS sending logic here
        // This is a placeholder for the actual SMS sending code

        #region Production

        Console.WriteLine($"Sending SMS to {phoneNumber}: {message}");

        #endregion
    }
}