using FoodShop.Application.Filters;
using FoodShop.Application.Specifications;
using FoodShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodShop.Application.Specifications
{
    public class ProductsByFiltersSpecification : Specification<Product>
    {
        public ProductsByFiltersSpecification(IFilter<Product>[] filters)
            : base(null)
        {
            AddInclude(c=>c.Category);
            SetFilters(filters);
        }
    }
}
