using MediatR;

namespace FoodShop.Application.Categories.Queries.GetCategories;

public record GetCategoriesQuery():IRequest<IEnumerable<CategoryDto>>;