using FoodShop.Application.Filters;
using FoodShop.Application.Specifications;
using FoodShop.Domain.Entities;

namespace FoodShop.Application.Abstractions;

public interface IProductEntryRepository
{

    public Task<ProductEntry> CreateProductEntryAsync(ProductEntry productEntry);
    
    public Task<ProductEntry> UpdateProductEntryAsync(ProductEntry productEntry);


    public Task<ProductEntry> GetProductEntryBySpecification(
        Specification<ProductEntry> specification);
    
    public Task<IEnumerable<ProductEntry>> GetProductEntriesBySpecification(
        Specification<ProductEntry> specification);

    public Task<bool> CheckProductEntryBySpecification(
        Specification<ProductEntry> specification);
    
    public Task DeleteProductEntriesBySpecification(
        Specification<ProductEntry> specification);
    
    public Task<bool> CheckProductEntriesBySpecification(
        Specification<ProductEntry> specification,
        int count);

    public Task<int> CountProductEntriesBySpecification(
        Specification<ProductEntry> specification);

}