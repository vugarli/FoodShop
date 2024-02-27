using FoodShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FoodShop.Infrastructure.Configurations;

public class ProductEntryConfiguration : IEntityTypeConfiguration<ProductEntry>
{
    public void Configure(EntityTypeBuilder<ProductEntry> builder)
    {
        builder.HasKey(pe => pe.Id);
        builder.HasOne<Product>(pe => pe.Product)
            .WithMany().HasForeignKey(p=>p.ProductId).OnDelete(DeleteBehavior.Restrict);
        builder.HasMany<VariationOption>(pe => pe.VariationOptions);
    }
}