using FoodShop.Application.Abstractions;
using FoodShop.Application.Filters;
using FoodShop.Application.Queries;
using FoodShop.Application.Specifications;
using FoodShop.Domain.Entities;
using FoodShop.Infrastructure.Specifications;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace FoodShop.Infrastructure.Repositories;

public class ProductEntryRepository : IProductEntryRepository
{
    private readonly ApplicationDbContext _context;

    public ProductEntryRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    private IQueryable<ProductEntry> ApplySpecification(Specification<ProductEntry> specification)
     => SpecificationEvaluator.GetQuery(_context.Set<ProductEntry>(), specification);


    public async Task<ProductEntry> GetProductEntryBySpecification(Specification<ProductEntry> specification)
    => await ApplySpecification(specification).FirstOrDefaultAsync();

    public async Task<IEnumerable<ProductEntry>> GetProductEntriesBySpecification(
        Specification<ProductEntry> specification)
        => await ApplySpecification(specification).ToListAsync();

    public async Task<bool> CheckProductEntryBySpecification(
        Specification<ProductEntry> specification)
        => await ApplySpecification(specification).AnyAsync();


    public async Task DeleteProductEntriesBySpecification(
        Specification<ProductEntry> specification)
        => await ApplySpecification(specification).ExecuteDeleteAsync();

    public async Task<bool> CheckProductEntriesBySpecification(
        Specification<ProductEntry> specification,
        int count)
        => await ApplySpecification(specification).CountAsync() == count;

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
      
}