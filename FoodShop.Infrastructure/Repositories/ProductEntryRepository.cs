using FoodShop.Application.Abstractions;
using FoodShop.Application.Filters;
using FoodShop.Application.Queries;
using FoodShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FoodShop.Infrastructure.Repositories;

public class ProductEntryRepository : IProductEntryRepository
{
    private readonly ApplicationDbContext _context;

    public ProductEntryRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task DeleteProductEntryAsync(Guid id)
    {
        await _context.Set<ProductEntry>().Where(pe => pe.Id == id).ExecuteDeleteAsync();
    }

    public async Task<ProductEntry> CreateProductEntryAsync(ProductEntry productEntry)
    {
        await _context.Set<ProductEntry>().AddAsync(productEntry);
        return productEntry;
    }

    public async Task<ProductEntry> UpdateProductEntryAsync(ProductEntry productEntry)
    {
        _context.Attach(productEntry);
        _context.Entry(productEntry).State = EntityState.Modified;
        return productEntry;
    }

    public async Task<ProductEntry> GetProductEntryByIdAsync(Guid id)
    {
        var productEntry = await _context.Set<ProductEntry>()
            .Include(pe=>pe.Product)
            .FirstOrDefaultAsync(pe => pe.Id == id);
        return productEntry;
    }

    public async Task<IEnumerable<ProductEntry>> GetProductEntriesAsync()
    {
        var pes = await _context.Set<ProductEntry>()
            .ToListAsync();
        return pes;
    }

    public async Task<bool> ProductEntryExistsAsync(Guid id,CancellationToken cancellationToken)
    {
        return await _context.Set<ProductEntry>().AnyAsync(pe => pe.Id == id,cancellationToken);
    }

    public async Task<IEnumerable<ProductEntry>> GetPaginatedProductEntriesAsync(int page, int per_page)
    {
        return await _context.Set<ProductEntry>().AddPagination(page, per_page).ToListAsync();
    }

    public async Task<int> GetProductEntriesCountAsync()
    {
        return await _context.Set<ProductEntry>().CountAsync();
    }

    public async Task<IEnumerable<ProductEntry>> GetProductEntriesWithFiltersAsync(params IFilter<ProductEntry>[] filters)
    {
        return await _context.Set<ProductEntry>().Include(pe => pe.Product).ApplyFilters(filters).ToListAsync();
    }

    public async Task<int> GetProductEntriesWithFiltersCountAsync(params IFilter<ProductEntry>[] filters)
    {
        return await _context.Set<ProductEntry>().ApplyFilters(filters).CountAsync();
    }
}