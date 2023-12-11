using MediatR;

namespace FoodShop.Application.ProductEntries.Queries.GetProductEntryById;

public record GetProductEntryByIdQuery(Guid Id) : IRequest<ProductEntryDto>;