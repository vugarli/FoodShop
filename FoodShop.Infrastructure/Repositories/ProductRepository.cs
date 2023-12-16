using AutoMapper;
using FoodShop.Application.Abstractions;
using FoodShop.Application.Pagination;
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
        return await _context.Set<Product>().Include(p=>p.Category).ToListAsync();
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

    public async Task<IEnumerable<Product>> GetPaginatedProductsAsync(int page, int per_page)
    {
        return await _context.Set<Product>().Include(p => p.Category).AddPagination(page,per_page).ToListAsync();
    }

    public async Task<int> GetProductsCountAsync()
    {
        return await _context.Set<Product>().CountAsync();
    }
}