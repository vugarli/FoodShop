﻿using FoodShop.Application.Abstractions;
using FoodShop.Application.Filters;
using FoodShop.Application.Queries;
using FoodShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FoodShop.Infrastructure.Repositories;

public class VariationRepository : IVariationRepository
{
    private readonly ApplicationDbContext _dbContext;

    public VariationRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<Variation> CreateVariationAsync(Variation variation)
    {
        await _dbContext.Set<Variation>().AddAsync(variation);
        return variation;
    }

    public async Task<Variation> GetVariationByIdAsync(Guid id)
    {
        var variation = await _dbContext.Set<Variation>().Include(v=>v.VariationOptions).FirstOrDefaultAsync(v=>v.Id == id);
        return variation;
    }

    public async Task<bool> VariationExistsAsync(Guid id,CancellationToken cancellationToken)
    {
        return await _dbContext.Set<Variation>().AnyAsync(v => v.Id == id,cancellationToken);
    }

    public async Task<IEnumerable<Variation>> GetVariationsAsync()
    {
        var variations = await _dbContext.Set<Variation>().ToListAsync();
        return variations;
    }

    public async Task<Variation> UpdateVariationAsync(Variation variation)
    {
        _dbContext.Update(variation);
        return variation;
    }

    public async Task DeleteVariationAsync(Guid id)
    {
        var r = await _dbContext.Set<Variation>().Where(v => v.Id == id).ExecuteDeleteAsync();
    }

    public async Task<IEnumerable<Variation>> GetPaginatedVariationsAsync(int page, int per_page)
    {
        return await _dbContext.Set<Variation>().AddPagination(page, per_page).ToListAsync();
    }

    public async Task<int> GetVariationsCountAsync()
    {
        return await _dbContext.Set<Variation>().CountAsync();
    }

    public async Task<IEnumerable<Variation>> GetFilteredVariationsAsync(params IFilter<Variation>[] filters)
    {
        return await _dbContext.Set<Variation>().Include(v=>v.VariationOptions).ApplyFilters(filters).ToListAsync();
    }

    public async Task DeleteVariationsAsync(IEnumerable<Guid> ids)
    {
        await _dbContext.Set<Variation>().Where(v=>ids.Contains(v.Id)).ExecuteDeleteAsync();
    }

    public async Task<bool> VariationsExistsAsync(IEnumerable<Guid> ids, CancellationToken cancellationToken)
    {
        var count = await _dbContext.Set<Variation>().Where(v => ids.Contains(v.Id)).CountAsync(cancellationToken);
        return count == ids.Count();
    }
}