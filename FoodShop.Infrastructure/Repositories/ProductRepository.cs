using AutoMapper;
using FoodShop.Application.Abstractions;
using FoodShop.Application.Queries;
using FoodShop.Application.Products.Commands.UpdateProduct;
using FoodShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using FoodShop.Application.Filters;
using Azure;
using FoodShop.Application.Specifications;
using FoodShop.Infrastructure.Specifications;

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
    private IQueryable<Product> ApplySpecification(Specification<Product> specification)
    => SpecificationEvaluator.GetQuery(_context.Set<Product>(), specification);

    public async Task<Product> GetProductBySpecification(Specification<Product> specification)
    => await ApplySpecification(specification).FirstOrDefaultAsync();

    public async Task<IEnumerable<Product>> GetProductsBySpecification(Specification<Product> specification)
        => await ApplySpecification(specification).ToListAsync();

    public async Task<bool> CheckProductBySpecification(Specification<Product> specification)
    => await ApplySpecification(specification).AnyAsync();

    public async Task DeleteProductsBySpecification(Specification<Product> specification)
    => await ApplySpecification(specification).ExecuteDeleteAsync();

    public async Task<bool> CheckProductsBySpecification(Specification<Product> specification, int count)
    => await ApplySpecification(specification).CountAsync() == count;

    public async Task CreateProductAsync(Product product)
    {
        await _context.Products.AddAsync(product);
    }
    public async Task<Product> UpdateProductAsync(Product product)
    {
        _context.Attach(product);
        _context.Entry(product).State = EntityState.Modified;
        return product;
    }

    public async Task<int> CountProductsBySpecification(Specification<Product> specification)
    => await ApplySpecification(specification).CountAsync();
}