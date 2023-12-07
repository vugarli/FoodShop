using FoodShop.Domain.Entities;
using MediatR;

namespace FoodShop.Application.Categories.Queries.GetCategoryById;

public record GetCategoryByIdQuery(Guid Id): IRequest<CategoryDto>;