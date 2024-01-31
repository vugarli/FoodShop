using FoodShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodShop.Application.Specifications.Categories
{
    public class ParentCategorySpecification : Specification<Category> 
    {
        public ParentCategorySpecification()
            :base(c=>c.ParentId == null) { }
    }
}
