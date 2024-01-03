using FoodShop.Application.Filters;
using FoodShop.Domain.Entities;

namespace FoodShop.Application.Abstractions;

public interface IProductEntryRepository
{
    public Task DeleteProductEntryAsync(Guid id);

    public Task<ProductEntry> CreateProductEntryAsync(ProductEntry productEntry);
    
    public Task<ProductEntry> UpdateProductEntryAsync(ProductEntry productEntry);

    public Task<ProductEntry> GetProductEntryByIdAsync(Guid id);

    public Task<IEnumerable<ProductEntry>> GetProductEntriesAsync();
    public Task<IEnumerable<ProductEntry>> GetPaginatedProductEntriesAsync(int page,int per_page);

    public Task<IEnumerable<ProductEntry>> GetProductEntriesWithFiltersAsync(params IFilter<ProductEntry>[] filters);
    public Task<int> GetProductEntriesWithFiltersCountAsync(params IFilter<ProductEntry>[] filters);
    public Task<int> GetProductEntriesCountAsync();

    public Task<bool> ProductEntryExistsAsync(Guid id,CancellationToken cancellationToken);
}