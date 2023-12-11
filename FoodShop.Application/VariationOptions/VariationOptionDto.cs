namespace FoodShop.Application.VariationOptions;

public class VariationOptionDto
{
    public Guid Id { get; set; }
    public string Value { get; set; }
    public Guid VariationId { get; set; }
}