using FoodShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodShop.Application.Filters
{
    public class ProductFilter : IFilter<Product>
    {
        public string? Category { get; set; }
        public string? Gender { get; set; }

        public IQueryable<Product> Filter(IQueryable<Product> query)
        {
            if (Category != null)
                query = query.Where<Product>(pe => pe.Category.Name == Category);

            if (Gender != null)
                query = query.Where(pe => pe.Category.BaseCategoryDiscriminator.Name == Gender);

            return query;
        }
    }
}
