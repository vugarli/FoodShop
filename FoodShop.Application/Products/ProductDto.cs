namespace FoodShop.Application.Products;

public class ProductDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public Guid CategoryId { get; set; }
    public string Image { get; set; }
    
}