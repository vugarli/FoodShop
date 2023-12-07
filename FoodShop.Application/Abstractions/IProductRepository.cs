using FoodShop.Application.Products;
using FoodShop.Application.Products.Commands.UpdateProduct;
using FoodShop.Domain.Entities;

namespace FoodShop.Application.Abstractions;

public interface IProductRepository
{
    public Task CreateProductAsync(Product product);
    public Task<Product> GetProductByIdAsync(Guid id);
    public Task<IEnumerable<Product>> GetProductsAsync();
    public Task<bool> ProductExistsAsync(Guid Id,CancellationToken cancellationToken);
    public Task<Product> UpdateProductAsync(Product product);
    public Task DeleteProductByIdAsync(Guid Id);
}