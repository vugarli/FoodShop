using FoodShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FoodShop.Infrastructure.Configurations;

public class VariationConfiguration : IEntityTypeConfiguration<Variation>
{
    public void Configure(EntityTypeBuilder<Variation> builder)
    {
        builder.HasKey(v => v.Id);

        builder.HasOne<Category>(v => v.Category)
            .WithMany(c=>c.Variations)
            .HasForeignKey(v=>v.CategoryId).OnDelete(DeleteBehavior.NoAction);
        
    }
}