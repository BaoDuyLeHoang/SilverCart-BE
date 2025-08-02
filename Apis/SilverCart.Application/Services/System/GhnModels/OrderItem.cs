namespace SilverCart.Application.Services.System;

public class GhnOrderItem
{
    public required string Name { get; set; }
    public string? Code { get; set; }
    public required int Quantity { get; set; }
    public required decimal Price { get; set; }
    public int? Length { get; set; }
    public int? Width { get; set; }
    public int? Height { get; set; }
    public int? Weight { get; set; }
    public CategoryInfo? Category { get; set; }
}
