using FoodShop.Application.Filters;
using FoodShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodShop.Application.Specifications.ProductEntries
{
    public class ProductEntriesByFiltersSpecification : Specification<ProductEntry>
    {
        public ProductEntriesByFiltersSpecification(IFilter<ProductEntry>[] filters)
            : base(null)
        {
            SetFilters(filters);
            AddInclude(pe => pe.Product);
        }
    }
}
