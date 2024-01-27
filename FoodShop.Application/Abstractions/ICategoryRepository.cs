using FoodShop.Application.Filters;
using FoodShop.Domain.Entities;

namespace FoodShop.Application.Abstractions;

public interface ICategoryRepository
{
    public Task<IEnumerable<Category>> GetCategoriesAsync();
    public Task<IEnumerable<Category>> GetParentCategoriesAsync();
    public Task<IEnumerable<Category>> GetPaginatedCategoriesAsync(int page,int per_page);

    public Task<Category> GetCategoryByIdAsync(Guid id);

    public Task<Category> UpdateCategoryAsync(Category category);

    public Task DeleteCategoryByIdAsync(Guid id);
    public Task DeleteCategoriesByIdsAsync(IEnumerable<Guid> ids);

    public Task CreateCategoryAsync(Category category);

    public Task<IEnumerable<Category>> GetCategoriesWithFiltersAsync(params IFilter<Category>[] filters);

    public Task<bool> CategoryExistsAsync(Guid id,CancellationToken cancellationToken);
    public Task<bool> CategoriesExistsAsync(IEnumerable<Guid> ids,CancellationToken cancellationToken);

    public Task<int> GetCategoriesCountAsync();


}