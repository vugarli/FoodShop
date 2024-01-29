using FoodShop.Application.VariationOptions;

namespace FoodShop.Application.Variations;

public class VariationDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public IEnumerable<VariationOptionDto> VariationOptions { get; set; }
}