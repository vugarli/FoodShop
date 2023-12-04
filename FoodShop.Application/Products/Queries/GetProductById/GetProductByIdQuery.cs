using FoodShop.Domain.Entities;
using MediatR;

namespace FoodShop.Application.Products.Queries.GetProductById;

public sealed record GetProductByIdQuery(Guid Id) : IRequest<Product>;