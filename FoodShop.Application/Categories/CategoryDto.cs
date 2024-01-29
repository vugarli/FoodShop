using FoodShop.Application.Variations;

namespace FoodShop.Application.Categories;

public class CategoryDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string ParentName { get; set; }
    public Nullable<Guid> ParentId { get; set; }

    public Nullable<Guid> BaseCategoryDiscriminatorId { get; set; }
    public string? BaseCategoryDiscriminatorName { get; set; }
    public IEnumerable<VariationDto>? Variations { get; set; }
}