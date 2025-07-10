namespace Infrastructures.Interfaces;

public interface ISmsService
{
    Task SendSMS(string phoneNumber, string otp);
}