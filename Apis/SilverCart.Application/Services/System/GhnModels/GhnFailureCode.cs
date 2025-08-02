namespace SilverCart.Application.Services.System;

public static class GhnFailureCode
{
    // Lấy thất bại
    public const string PICKUP_RESCHEDULE = "GHN-PFA1A0";  // Người gửi hẹn lại
    public const string PICKUP_WRONG_INFO = "GHN-PFA2A2";  // Thông tin sai
    public const string PICKUP_NO_CONTACT = "GHN-PFA2A1";  // Không liên lạc được

    // Giao thất bại
    public const string DELIVERY_RESCHEDULE = "GHN-DFC1A0"; // Người nhận hẹn lại
    public const string DELIVERY_NO_CONTACT = "GHN-DFC1A2"; // Không liên lạc được
    public const string DELIVERY_WRONG_INFO = "GHN-DCD0A1"; // Sai thông tin
    public const string DELIVERY_REFUSE = "GHN-DCD0A8";     // Từ chối nhận
}

