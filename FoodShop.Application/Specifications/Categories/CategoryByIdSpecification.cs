using FoodShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodShop.Application.Specifications.Categories
{
    public class CategoryByIdSpecification : Specification<Category>
    {
        public CategoryByIdSpecification(Guid Id) : base(c=>c.Id == Id) {}
    }
}
