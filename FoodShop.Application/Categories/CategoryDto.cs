namespace FoodShop.Application.Categories;

public class CategoryDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string ParentName { get; set; }
    public Nullable<Guid> ParentId { get; set; }
}