using FoodShop.Application.Abstractions;
using FoodShop.Application.Filters;
using FoodShop.Application.Queries;
using FoodShop.Application.Specifications;
using FoodShop.Domain.Entities;
using FoodShop.Infrastructure.Specifications;
using Microsoft.EntityFrameworkCore;

namespace FoodShop.Infrastructure.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly ApplicationDbContext _dbContext;

    public CategoryRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    private IQueryable<Category> ApplySpecification(Specification<Category> specification)
        => SpecificationEvaluator.GetQuery(_dbContext.Set<Category>(),specification);


    public async Task<Category> GetCategoryBySpecification(Specification<Category> specification)
        => await ApplySpecification(specification).FirstOrDefaultAsync();
    
    public async Task<IEnumerable<Category>> GetCategoriesBySpecification(Specification<Category> specification)
        => await ApplySpecification(specification).ToListAsync();

    public async Task<bool> CheckCategoryBySpecification(Specification<Category> specification)
        => await ApplySpecification(specification).AnyAsync();
    
    public async Task<bool> CheckCategoriesBySpecification(Specification<Category> specification, int count)
        => await ApplySpecification(specification).CountAsync() == count;


    public async Task DeleteCategoriesBySpecification(Specification<Category> specification)
        => await ApplySpecification(specification).ExecuteDeleteAsync();


    public async Task<Category> UpdateCategoryAsync(Category category)
    {
        _dbContext.Attach(category);
        _dbContext.Entry(category).State = EntityState.Modified;
        return category;
    }

    public async Task CreateCategoryAsync(Category category)
    {
        IfVariationsAddedToCategory(category);
        await _dbContext.Set<Category>().AddAsync(category);
    }

    public void IfVariationsAddedToCategory(Category category)
    {
        if (category.Variations != null)
        foreach (var variation in category.Variations)
        {
            _dbContext.Attach(variation);
            _dbContext.Entry(variation).State = EntityState.Unchanged;
        }
    }

    public async Task<int> GetCategoriesCountAsync()
    {
        return await _dbContext.Set<Category>().CountAsync();
    }

    public async Task<IEnumerable<Category>> GetCategoriesWithFiltersAsync(params IFilter<Category>[] filters)
    {
        return await _dbContext.Set<Category>().Include(c=>c.ParentCategory).Include(c=>c.BaseCategoryDiscriminator).Include(c=>c.Variations).ApplyFilters(filters).ToListAsync();
    }

    // delegate this task to variaiton repo
    public async Task<bool> IsVariationBelongsToCategoryAsync(Guid categoryId, Guid variationId)
    {
        return await _dbContext.Set<Category>().Include(c=>c.Variations)
            .AnyAsync(c=>c.Id == categoryId && c.Variations.Any(v=>v.Id == variationId));
    }

    
}