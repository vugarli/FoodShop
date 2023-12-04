using FoodShop.Domain.Entities;
using MediatR;

namespace FoodShop.Application.Products.Queries.GetProducts;

public class GetProductsQuery : IRequest<IEnumerable<Product>> {}