﻿using FoodShop.Application.Abstractions;
using FoodShop.Application.Pagination;
using FoodShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FoodShop.Infrastructure.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly ApplicationDbContext _dbContext;

    public CategoryRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<Category> GetCategoryByIdAsync(Guid id)
    {
        return await _dbContext.Set<Category>().Include(c=>c.ParentCategory).FirstOrDefaultAsync(c=>c.Id == id);
    }

    public async Task<IEnumerable<Category>> GetCategoriesAsync()
    {
        return await _dbContext.Set<Category>().Include(c => c.ParentCategory).ToListAsync();
    }

    public async Task<Category> UpdateCategoryAsync(Category category)
    {
        _dbContext.Attach(category);
        _dbContext.Entry(category).State = EntityState.Modified;
        return category;
    }

    public async Task DeleteCategoryByIdAsync(Guid id)
    {
        await _dbContext.Set<Category>().Where(c => c.Id == id).ExecuteDeleteAsync();
    }

    public async Task CreateCategoryAsync(Category category)
    {
        await _dbContext.Set<Category>().AddAsync(category);
    }

    public async Task<bool> CategoryExistsAsync(Guid id,CancellationToken cancellationToken)
    {
        return await _dbContext.Set<Category>().AnyAsync(c=>c.Id==id,cancellationToken);
    }

    public async Task<IEnumerable<Category>> GetPaginatedCategoriesAsync(int page, int per_page)
    {
        return await _dbContext.Set<Category>().Include(c => c.ParentCategory).AddPagination(page, per_page).ToListAsync();
    }

    public async Task<int> GetCategoriesCountAsync()
    {
        return await _dbContext.Set<Category>().CountAsync();
    }

    public async Task<IEnumerable<Category>> GetParentCategoriesAsync()
    {
        return await _dbContext.Set<Category>().Where(c => c.ParentId == null).ToListAsync();
    }

    public async Task<bool> CategoriesExistsAsync(IEnumerable<Guid> ids, CancellationToken cancellationToken)
    {
        var result = await _dbContext.Set<Category>().Where(c => ids.Contains(c.Id)).CountAsync();
        return result == ids.Count();
    }

    public async Task DeleteCategoriesByIdsAsync(IEnumerable<Guid> ids)
    {
        await _dbContext.Set<Category>().Where(c => ids.Contains(c.Id)).ExecuteDeleteAsync();
    }
}