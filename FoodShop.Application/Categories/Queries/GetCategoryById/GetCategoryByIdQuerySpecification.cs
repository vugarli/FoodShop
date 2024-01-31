using FoodShop.Application.Specifications;
using FoodShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodShop.Application.Categories.Queries.GetCategoryById
{
    public class GetCategoryByIdQuerySpecification : Specification<Category>
    {
        public GetCategoryByIdQuerySpecification(Guid Id)
            : base(c=>c.Id == Id)
        {
            AddInclude(c=>c.ParentCategory);
            AddInclude(c=>c.Variations);
        }
    }
}
