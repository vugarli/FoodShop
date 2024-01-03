using FoodShop.Domain.Abstractions;
using FoodShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.VisualBasic.CompilerServices;

namespace FoodShop.Infrastructure;

public class ApplicationDbContext : DbContext, IUnitOfWork
{
    public DbSet<Product> Products { get; set; }
    public DbSet<BaseCategoryDiscriminator> BaseCategoryDiscriminators { get; set; }
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :base(options) {}
    
	protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

        

    }
}