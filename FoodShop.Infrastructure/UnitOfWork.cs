using FoodShop.Domain.Abstractions;

namespace FoodShop.Infrastructure;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;

    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<int> SaveChangesAsync(CancellationToken token)
    {
        return await _context.SaveChangesAsync();
    }
}