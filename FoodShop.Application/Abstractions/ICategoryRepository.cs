using FoodShop.Domain.Entities;

namespace FoodShop.Application.Abstractions;

public interface ICategoryRepository
{
    public Task<Category> GetCategoryByIdAsync(Guid id);

    public Task<IEnumerable<Category>> GetCategoriesAsync();

    public Task<Category> UpdateCategoryAsync(Category category);

    public Task DeleteCategoryByIdAsync(Guid id);

    public Task AddAsync(Category category);

    public Task<bool> CategoryExistsAsync(Guid id,CancellationToken cancellationToken);

}