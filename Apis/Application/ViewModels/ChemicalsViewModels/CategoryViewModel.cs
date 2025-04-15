using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Application.ViewModels.CategorysViewModels
{
    public class CategoryViewModel : Category
    {
        
    }

    public abstract class BaseEntityViewModel : BaseEntity
    {
        public string Id { get; set; }
    }
}