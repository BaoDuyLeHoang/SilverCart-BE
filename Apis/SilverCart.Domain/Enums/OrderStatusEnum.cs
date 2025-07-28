public enum GhnOrderStatusEnum
{
    ReadyToPick,      // Mới tạo đơn hàng
    Picking,          // Nhân viên đang lấy hàng
    Cancel,           // Hủy đơn hàng
    MoneyCollectPicking, // Đang thu tiền người gửi
    Picked,           // Nhân viên đã lấy hàng
    Storing,          // Hàng đang nằm ở kho
    Transporting,     // Đang luân chuyển hàng
    Sorting,          // Đang phân loại hàng hóa
    Delivering,       // Nhân viên đang giao cho người nhận
    MoneyCollectDelivering, // Nhân viên đang thu tiền người nhận
    Delivered,        // Nhân viên đã giao hàng thành công
    DeliveryFail,     // Nhân viên giao hàng thất bại
    WaitingToReturn,  // Đang đợi trả hàng về cho người gửi
    Return,           // Trả hàng
    ReturnTransporting, // Đang luân chuyển hàng trả
    ReturnSorting,    // Đang phân loại hàng trả
    Returning,        // Nhân viên đang đi trả hàng
    ReturnFail,       // Nhân viên trả hàng thất bại
    Returned,         // Nhân viên trả hàng thành công
    Exception,        // Đơn hàng ngoại lệ
    Damage,           // Hàng bị hư hỏng
    Lost             // Hàng bị mất
}
