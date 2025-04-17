using System.ComponentModel.DataAnnotations.Schema;
using Domain.Enums;

namespace Domain.Entities;

public class Category : BaseFullEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public CategoryStatusEnum Status { get; set; }
    
    // Navigation properties
    public Guid ApprovedById { get; set; }
    public Guid ParentCategoryId { get; set; }
    public virtual Category ParentCategory { get; set; }
    public virtual ICollection<Category> SubCategories { get; set; }
    public virtual ICollection<Product> Products { get; set; }

    public virtual AdministratorUser ApprovedUser { get; set; }
}