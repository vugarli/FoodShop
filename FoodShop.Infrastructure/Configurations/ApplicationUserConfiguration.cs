using FoodShop.Domain.Entities;
using FoodShop.Infrastructure.IdentityRelated;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodShop.Infrastructure.Configurations
{
    public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.HasDiscriminator(c => c.AccountType)
                .HasValue<ApplicationSellerUser>(AccountType.Seller)
                .HasValue<ApplicationCustomerUser>(AccountType.Customer);

            builder.HasOne(typeof(ApplicationIdentityUser)).WithOne().HasForeignKey(typeof(ApplicationUser),"IdentityId");
        }
    }

    public class ApplicationSellerUserConfiguration : IEntityTypeConfiguration<ApplicationSellerUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationSellerUser> builder)
        {
            builder
                .HasMany(su => su.Products)
                .WithOne(p=>p.Seller)
                .HasForeignKey(p=>p.SellerId)
                .OnDelete(DeleteBehavior.Restrict);
                
            builder
                .HasMany(su => su.ProductEntries)
                .WithOne(p => p.Seller)
                .HasForeignKey(p => p.SellerId)
                .OnDelete(DeleteBehavior.Restrict); 

        }
    }




}
