using FoodShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FoodShop.Infrastructure.Configurations;

public class VaritationOptionConfiguration : IEntityTypeConfiguration<VariationOption>
{
    public void Configure(EntityTypeBuilder<VariationOption> builder)
    {
        builder.HasKey(vo => vo.Id);
        builder.HasOne<Variation>(vo => vo.Variation).WithMany(v=>v.VariationOptions).HasForeignKey(vo => vo.VariationId);
        builder.HasMany<ProductEntry>(vo => vo.ProductEntries)
            .WithMany(pe => pe.VariationOptions);
    }
}