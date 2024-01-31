using FoodShop.Application.Filters;
using FoodShop.Application.Products;
using FoodShop.Application.Products.Commands.UpdateProduct;
using FoodShop.Application.Specifications;
using FoodShop.Domain.Entities;
using System.Collections.Generic;

namespace FoodShop.Application.Abstractions;

public interface IProductRepository
{
    
    public Task CreateProductAsync(Product product);
    
    public Task<Product> UpdateProductAsync(Product product);


    public Task<Product> GetProductBySpecification(Specification<Product> specification);
    public Task<IEnumerable<Product>> GetProductsBySpecification(Specification<Product> specification);
    public Task<bool> CheckProductBySpecification(Specification<Product> specification);
    public Task DeleteProductsBySpecification(Specification<Product> specification);
    public Task<bool> CheckProductsBySpecification(Specification<Product> specification, int count);

    public Task<int> CountProductsBySpecification(Specification<Product> specification);
}