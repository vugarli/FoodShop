using FoodShop.Application.Products;
using FoodShop.Application.Products.Commands.UpdateProduct;
using FoodShop.Domain.Entities;
using System.Collections.Generic;

namespace FoodShop.Application.Abstractions;

public interface IProductRepository
{
    public Task<IEnumerable<Product>> GetProductsAsync();
    public Task<IEnumerable<Product>> GetPaginatedProductsAsync(int page,int per_page);
    public Task<int> GetProductsCountAsync();

    public Task CreateProductAsync(Product product);
    public Task<Product> GetProductByIdAsync(Guid id);
    public Task<bool> ProductExistsAsync(Guid Id,CancellationToken cancellationToken);
    public Task<bool> ProductsExistsAsync(IEnumerable<Guid> Ids,CancellationToken cancellationToken);
    public Task<Product> UpdateProductAsync(Product product);
    public Task DeleteProductByIdAsync(Guid Id);
    public Task DeleteProductsByIdsAsync(IEnumerable<Guid> Ids);
}