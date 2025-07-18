﻿global using SilverCart.Domain.Entities.Products;
global using SilverCart.Domain.Entities.Stores;
using SilverCart.Domain.Entities.Products;

namespace SilverCart.Domain.Entities.Cart;

public class CartItem : BaseEntity
{
    public int Quantity { get; set; }
    public decimal Price { get; set; }

    public decimal TotalPrice { get; set; }

    public bool IsSelected { get; set; } = true;

    // Navigation properties
    public Guid CartId { get; set; }

    public Guid ProductId { get; set; }
    public virtual Product Product { get; set; } = null!;
    public Guid ProductItemId { get; set; }
    public virtual ProductItem ProductItem { get; set; } = null!;
    public Guid StoreId { get; set; }
    public virtual Store Store { get; set; } = null!;
}