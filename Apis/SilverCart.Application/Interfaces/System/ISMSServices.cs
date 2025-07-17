namespace SilverCart.Application.Interfaces.System;

public interface ISMSService
{
    Task SendSMS(string phoneNumber, string message);
}