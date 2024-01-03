using FoodShop.Application.Filters;
using FoodShop.Application.Queries;
using FoodShop.Domain.Entities;
using FoodShop.Domain.Primitives;
using MediatR;

namespace FoodShop.Application.ProductEntries.Queries.GetProductEntries;

public record GetProductEntriesQuery(params IFilter<ProductEntry>[] filters) : IRequest<IQueryResult>;