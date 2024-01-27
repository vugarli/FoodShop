using FoodShop.Application.VariationOptions;
using FoodShop.Domain.Entities;

namespace FoodShop.Application.ProductEntries;

public class ProductEntryDto
{
    public Guid Id { get; set; }
    public Guid ProductId { get; private set; }
    public string ProductName { get; private set; }
    public string SKU { get; private set; }
    public decimal Price { get; private set; }
    public string Image { get; private set; }
    public int Quantity { get; private set; }
    public IEnumerable<VariationOptionDto>? VariationOptions { get; private set; }
}