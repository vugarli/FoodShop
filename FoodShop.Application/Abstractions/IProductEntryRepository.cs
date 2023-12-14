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

    public Task<bool> ProductEntryExistsAsync(Guid id,CancellationToken cancellationToken);
    public Task<int> GetProductEntriesCountAsync();
}