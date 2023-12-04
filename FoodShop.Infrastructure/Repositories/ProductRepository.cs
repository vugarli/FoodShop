using FoodShop.Application.Abstractions;
using FoodShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FoodShop.Infrastructure.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly ApplicationDbContext _context;

    public ProductRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task AddAsync(Product product)
    {
        await _context.Set<Product>().AddAsync(product);
    }

    public async Task<Product> GetProductById(Guid id)
    {
        return await _context.Set<Product>().FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<IEnumerable<Product>> GetProductsAsync()
    {
        return await _context.Set<Product>().ToListAsync();
    }
}