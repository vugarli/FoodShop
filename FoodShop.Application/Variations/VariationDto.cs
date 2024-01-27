namespace FoodShop.Application.Variations;

public class VariationDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Guid CategoryId { get; set; }
    public string CategoryName { get; set; }
}