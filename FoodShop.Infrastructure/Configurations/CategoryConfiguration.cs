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

        builder.HasOne<BaseCategoryDiscriminator>(c => c.BaseCategoryDiscriminator)
            .WithMany(b => b.Categories).HasForeignKey(c => c.BaseCategoryDiscriminatorId);

        builder.HasMany(c => c.Variations)
            .WithMany(v => v.Categories);
    }
}