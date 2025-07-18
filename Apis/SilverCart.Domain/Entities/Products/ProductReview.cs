﻿using System.ComponentModel.DataAnnotations;
using SilverCart.Domain.Entities.Auth;

namespace SilverCart.Domain.Entities;

public class ProductReview : BaseEntity
{
    public string ReviewText { get; set; } = string.Empty;
    [Range(1, 5)]
    public int Rating { get; set; }

    // Navigation properties
    public Guid ProductId { get; set; }
    public Product Product { get; set; } = null!;
    public Guid CustomerId { get; set; }
    public CustomerUser Customer { get; set; } = null!;
}