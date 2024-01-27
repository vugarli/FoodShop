using FoodShop.Application.Filters;
using FoodShop.Application.Queries;
using FoodShop.Domain.Entities;
using MediatR;

namespace FoodShop.Application.Categories.Queries.GetCategories;

public record GetCategoriesQuery(params IFilter<Category>[] filters) : IRequest<IQueryResult>;
