using AutoMapper;
using FoodShop.Application.Abstractions;
using FoodShop.Application.Queries;
using FoodShop.Application.Products.Commands.UpdateProduct;
using FoodShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using FoodShop.Application.Filters;
using Azure;

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
    
    public async Task<int> GetFilteredProductsCountAsync(params IFilter<Product>[] filters)
    {
        return await _context.Set<Product>().ApplyFilters(filters).CountAsync();
    }

    public async Task DeleteProductsByIdsAsync(IEnumerable<Guid> Ids)
    {
        await _context.Set<Product>().Where(p => Ids.Contains(p.Id)).ExecuteDeleteAsync();
    }

    public async Task<bool> ProductsExistsAsync(IEnumerable<Guid> Ids, CancellationToken cancellationToken)
    {
        var count = await _context.Set<Product>().Where(x => Ids.Contains(x.Id)).CountAsync();
        return count == Ids.Count();
    }

    public async Task<IEnumerable<Product>> GetFilteredProductsAsync(params IFilter<Product>[] filters)
    {
        return await _context.Set<Product>().Include(p=>p.Category).ApplyFilters<Product>(filters).ToListAsync();
    }


}