using FoodShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodShop.Application.Filters
{
    public class CategoryFilter : IFilter<Category>
    {

        public string? ParentCategoryName { get; set; }

        public string? GenderName { get; set; }
        

        public IQueryable<Category> Filter(IQueryable<Category> query)
        {
            if (ParentCategoryName != null)
                query = query.Where(c => c.ParentCategory.Name == ParentCategoryName);

            if (GenderName != null)
                query = query.Where(c => c.BaseCategoryDiscriminator.Name == GenderName);

            return query;
        }
    }
}
