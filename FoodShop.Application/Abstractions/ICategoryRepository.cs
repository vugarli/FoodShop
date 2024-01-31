using FoodShop.Application.Filters;
using FoodShop.Application.Specifications;
using FoodShop.Domain.Entities;

namespace FoodShop.Application.Abstractions;

public interface ICategoryRepository
{
    public void IfVariationsAddedToCategory(Category category);
    public Task<Category> UpdateCategoryAsync(Category category);
    public Task CreateCategoryAsync(Category category);
    public Task<bool> IsVariationBelongsToCategoryAsync(Guid categoryId,Guid variationId);
    public Task<Category> GetCategoryBySpecification(Specification<Category> specification);
    public Task<IEnumerable<Category>> GetCategoriesBySpecification(Specification<Category> specification);
    public Task<bool> CheckCategoryBySpecification(Specification<Category> specification);
    public Task DeleteCategoriesBySpecification(Specification<Category> specification);
    public Task<bool> CheckCategoriesBySpecification(Specification<Category> specification, int count);
    public Task<int> CountCategoriesBySpecification(Specification<Category> specification);
    public Task<int> GetCategoriesCountAsync();
}