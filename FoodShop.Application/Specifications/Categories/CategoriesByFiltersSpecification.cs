using FoodShop.Application.Filters;
using FoodShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodShop.Application.Specifications.Categories
{
    public class CategoriesByFiltersSpecification : Specification<Category>
    {
        public CategoriesByFiltersSpecification(IFilter<Category>[] filters)
        : base(null)
        {
            AddInclude(c=>c.BaseCategoryDiscriminator);
            AddInclude(c=>c.ParentCategory);
            AddInclude(c=>c.Variations);
            SetFilters(filters);
        }
    }
}
