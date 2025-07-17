using System.ComponentModel.DataAnnotations;
using SilverCart.Domain.Entities.Auth;
using SilverCart.Domain.Enums;

namespace SilverCart.Domain.Entities.Categories;

public class Category : BaseEntity
{
    [StringLength(100)]
    public string Name { get; set; } = string.Empty;
    [StringLength(10000)]
    public string Description { get; set; } = string.Empty;
    public CategoryStatusEnum Status { get; set; }
    public string? ImageUrl { get; set; }

    // Navigation properties
    public Guid? ApprovedById { get; set; }
    public Guid? ParentCategoryId { get; set; }
    public virtual Category? ParentCategory { get; set; }
    public virtual ICollection<Category>? SubCategories { get; set; }
    public virtual ICollection<ProductCategory> ProductCategories { get; set; } = new List<ProductCategory>();
    public virtual AdministratorUser? ApprovedUser { get; set; }
}