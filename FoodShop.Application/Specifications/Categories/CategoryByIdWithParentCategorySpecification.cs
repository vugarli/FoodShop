using FoodShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodShop.Application.Specifications.Categories
{
    public class CategoryByIdWithParentCategorySpecification
        : Specification<Category>
    {

        public CategoryByIdWithParentCategorySpecification(Guid Id)
            :base(c => c.Id == Id)
        {
            AddInclude(c => c.ParentCategory);
        }


    }
}
