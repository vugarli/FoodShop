using FoodShop.Domain.Abstractions;
using FoodShop.Domain.Entities;
using FoodShop.Domain.Primitives;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualBasic.CompilerServices;

namespace FoodShop.Infrastructure;

public class ApplicationDbContext : DbContext, IUnitOfWork
{
    public DbSet<Product> Products { get; set; }
    public DbSet<BaseCategoryDiscriminator> BaseCategoryDiscriminators { get; set; }
    
    
	protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }

    private IConfiguration _configuration { get; }
    public ApplicationDbContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = _configuration.GetConnectionString(name: "MSSQL");
        optionsBuilder.UseSqlServer(connectionString);
        base.OnConfiguring(optionsBuilder);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        foreach (var history in this.ChangeTracker.Entries()
            .Where(e => e.Entity is Entity && (e.State == EntityState.Added ||
                e.State == EntityState.Modified))
            .Select(e => e.Entity as Entity)
            )
        {
            history.ModifiedAt = DateTime.Now;
            if (history.CreatedAt <= DateTime.MinValue)
            {
                history.CreatedAt = DateTime.Now;
            }
        }

        return base.SaveChangesAsync(cancellationToken);
    }

}