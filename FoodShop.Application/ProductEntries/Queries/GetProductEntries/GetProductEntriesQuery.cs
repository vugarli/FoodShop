using MediatR;

namespace FoodShop.Application.ProductEntries.Queries.GetProductEntries;

public record GetProductEntriesQuery() : IRequest<IEnumerable<ProductEntryDto>>;