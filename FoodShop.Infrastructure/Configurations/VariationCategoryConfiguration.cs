using FoodShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodShop.Infrastructure.Configurations
{
	public class VariationCategoryConfiguration : IEntityTypeConfiguration<VariationCategory>
	{
		public void Configure(EntityTypeBuilder<VariationCategory> builder)
		{
			builder.HasKey(pe => new { pe.CategoryId,pe.VariationId });
		}

		
	}
}
