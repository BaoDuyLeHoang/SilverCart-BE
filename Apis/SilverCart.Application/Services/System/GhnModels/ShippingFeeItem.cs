namespace SilverCart.Application.Services.System;

public class ShippingFeeItem
{
    public required string Name { get; set; }
    public required int Quantity { get; set; }
    public required int Length { get; set; }
    public required int Width { get; set; }
    public required int Height { get; set; }
    public required int Weight { get; set; }
}
