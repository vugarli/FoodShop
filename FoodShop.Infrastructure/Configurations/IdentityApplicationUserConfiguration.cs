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
    public class IdentityApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationIdentityUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationIdentityUser> builder)
        {
            
        }
    }
}
