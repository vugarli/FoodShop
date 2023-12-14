using FoodShop.Domain.Entities;

namespace FoodShop.Application.Abstractions;

public interface ICategoryRepository
{
    public Task<IEnumerable<Category>> GetCategoriesAsync();
    public Task<IEnumerable<Category>> GetPaginatedCategoriesAsync(int page,int per_page);

    public Task<Category> GetCategoryByIdAsync(Guid id);

    public Task<Category> UpdateCategoryAsync(Category category);

    public Task DeleteCategoryByIdAsync(Guid id);

    public Task CreateCategoryAsync(Category category);

    public Task<bool> CategoryExistsAsync(Guid id,CancellationToken cancellationToken);
    public Task<int> GetCategoriesCountAsync();


}