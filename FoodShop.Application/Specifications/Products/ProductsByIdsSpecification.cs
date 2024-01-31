using FoodShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodShop.Application.Specifications.Products
{
    public class ProductsByIdsSpecification
        :Specification<Product>
    {
        public ProductsByIdsSpecification(IEnumerable<Guid> Ids)
            :base(p=>Ids.Contains(p.Id))
        {
        }
    }
}
