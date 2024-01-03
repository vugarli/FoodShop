using System.Security.Cryptography.X509Certificates;
using FoodShop.Application.Abstractions;
using FoodShop.Application.Queries;
using FoodShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace FoodShop.Infrastructure.Repositories;

public class VariationOptionRepository : IVariationOptionRepository
{
    private readonly ApplicationDbContext _context;

    public VariationOptionRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<VariationOption> GetVariationOptionByIdAsync(Guid id)
    {
        var variationOption = await _context.Set<VariationOption>()
            .FirstOrDefaultAsync(vo=> vo.Id == id);
        return variationOption;
    }

    public async Task<IEnumerable<VariationOption>> GetVariationOptionsAsync()
    {
        return await _context.Set<VariationOption>().ToListAsync();
    }

    public async Task CreateVariationOptionAsync(VariationOption variationOption)
    {
        await _context.Set<VariationOption>().AddAsync(variationOption);
    }

    public async Task<VariationOption> UpdateVariationOptionAsync(VariationOption variationOption)
    {
        _context.Attach(variationOption);
        _context.Entry(variationOption).State = EntityState.Modified;
        return variationOption;
    }

    public async Task DeleteVariationOptionAsync(Guid id)
    {
        await _context.Set<VariationOption>().Where(vo=>vo.Id == id).ExecuteDeleteAsync();
    }

    public Task<bool> VariationOptionExistsAsync(Guid id, CancellationToken cancellationToken)
    {
        return _context.Set<VariationOption>().AnyAsync(vo=>vo.Id == id);
    }

    public async Task<IEnumerable<VariationOption>> GetPaginatedVariationOptionsAsync(int page, int per_page)
    {
        return await _context.Set<VariationOption>().AddPagination(page, per_page).ToListAsync();
    }

    public async Task<int> GetVariationOptionsCountAsync()
    {
        return await _context.Set<VariationOption>().CountAsync();
    }
}