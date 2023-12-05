using FoodShop.Domain.Entities;

namespace FoodShop.Application.Abstractions;

public interface IProductRepository
{
    public Task AddAsync(Product product);
    public Task<Product> GetProductByIdAsync(Guid id);
    public Task<IEnumerable<Product>> GetProductsAsync();
    
}