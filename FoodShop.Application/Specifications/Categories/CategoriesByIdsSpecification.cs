using FoodShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodShop.Application.Specifications.Categories
{
    public class CategoriesByIdsSpecification : Specification<Category>
    {
        public CategoriesByIdsSpecification(IEnumerable<Guid> Ids)
            :base(c=>Ids.Contains(c.Id)) { }
    }
}
