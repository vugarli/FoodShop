using FoodShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FoodShop.Infrastructure.Configurations;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasKey(c=>c.Id);
        builder.HasOne<Category>(c => c.ParentCategory)
            .WithMany().HasForeignKey(c=>c.ParentId)
            .OnDelete(DeleteBehavior.NoAction);
        builder.HasMany<Variation>(c => c.Variations)
            .WithOne(v => v.Category).HasForeignKey(v=>v.CategoryId);
    }
}