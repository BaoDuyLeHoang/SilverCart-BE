using System.ComponentModel.DataAnnotations;

namespace Application.ViewModels.UserViewModels
{
    public class UserFilterDTO
    {
        // Search text (Văn bản tìm kiếm)
        public string? SearchTerm { get; set; }

        // User type filters (Bộ lọc loại người dùng)
        public UserType? UserType { get; set; }

        // Verification status (Trạng thái xác minh)
        public bool? IsVerified { get; set; }

        // Date range filters (Bộ lọc khoảng thời gian)
        public DateTime? SignInDateFrom { get; set; }
        public DateTime? SignInDateTo { get; set; }
        public DateTime? CreatedDateFrom { get; set; }
        public DateTime? CreatedDateTo { get; set; }

        // Pagination (Phân trang)
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;

        // Sorting (Sắp xếp)
        public string? SortBy { get; set; }
        public bool IsDescending { get; set; } = false;
    }

    public enum UserType
    {
        All,
        Customer,
        Store,
        Administrator
    }



    // DTO for list items (DTO cho các mục danh sách)
    public class UserListItemDTO
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string? Phone { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public bool IsVerified { get; set; }
        public DateTime? SignInTime { get; set; }
        public DateTime CreatedAt { get; set; }
        public string UserType { get; set; }
    }
}