using FoodShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FoodShop.Infrastructure.Configurations;

public class VariationConfiguration : IEntityTypeConfiguration<Variation>
{
    public void Configure(EntityTypeBuilder<Variation> builder)
    {
        builder.HasKey(v => v.Id);

        builder.HasMany(v => v.VaritaionCategories)
            .WithOne(c => c.Variation);
        
    }
}