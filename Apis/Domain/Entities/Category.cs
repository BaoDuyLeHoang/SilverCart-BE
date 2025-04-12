using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class Category : BaseFullEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public CategoryStatusEnum Status { get; set; }

    public enum CategoryStatusEnum
    {
        Active,
        Inactive,
        Pending,
    }

    // Navigation properties
    public int ApprovedById { get; set; }
    public int ParentCategoryId { get; set; }
    public virtual Category ParentCategory { get; set; }
    public virtual ICollection<Category> SubCategories { get; set; }
    public virtual ICollection<Product> Products { get; set; }
    [ForeignKey("ApprovedById")] 
    public virtual AdministratorUser ApprovedUser { get; set; }
}