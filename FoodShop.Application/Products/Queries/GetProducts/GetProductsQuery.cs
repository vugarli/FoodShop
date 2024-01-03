using FoodShop.Application.Filters;
using FoodShop.Application.Queries;
using FoodShop.Domain.Entities;
using MediatR;

namespace FoodShop.Application.Products.Queries.GetProducts;

public record GetProductsQuery(params IFilter<Product>[] filters) : IRequest<IQueryResult>;