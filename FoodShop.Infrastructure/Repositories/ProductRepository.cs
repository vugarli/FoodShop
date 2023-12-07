using AutoMapper;
using FoodShop.Application.Abstractions;
using FoodShop.Application.Products.Commands.UpdateProduct;
using FoodShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FoodShop.Infrastructure.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public ProductRepository(ApplicationDbContext context,IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    public async Task CreateProductAsync(Product product)
    {
        await _context.Products.AddAsync(product);
    }

    public async Task<Product> GetProductByIdAsync(Guid id)
    {
        return await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<IEnumerable<Product>> GetProductsAsync()
    {
        return await _context.Set<Product>().ToListAsync();
    }

    public async Task<bool> ProductExistsAsync(Guid Id,CancellationToken cancellationToken)
    {
        return await _context.Products.AnyAsync(p => p.Id == Id,cancellationToken);
    }

    public async Task<Product> UpdateProductAsync(Product product)
    {
        _context.Attach(product);
        _context.Entry(product).State = EntityState.Modified;
        return product;
    }

    public async Task DeleteProductByIdAsync(Guid Id)
    {
        await _context.Products.Where(p => p.Id == Id).ExecuteDeleteAsync();
    }
}