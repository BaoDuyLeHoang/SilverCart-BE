using System.ComponentModel.DataAnnotations.Schema;
using SilverCart.Domain.Enums;

namespace SilverCart.Domain.Entities;

public class Category : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public CategoryStatusEnum Status { get; set; }

    // Navigation properties
    public Guid? ApprovedById { get; set; }
    public Guid? ParentCategoryId { get; set; }
    public DateTime? CreatedDate { get; set; }
    public virtual Category? ParentCategory { get; set; }
    public virtual ICollection<Category>? SubCategories { get; set; }
    public virtual ICollection<ProductCategory> ProductCategories { get; set; } = new List<ProductCategory>();
    public virtual AdministratorUser? ApprovedUser { get; set; }
}