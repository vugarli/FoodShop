using FoodShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodShop.Application.Specifications.ProductEntries
{
    public class ProductEntriesByIdsSpecification : Specification<ProductEntry>
    {
        public ProductEntriesByIdsSpecification(IEnumerable<Guid> Ids)
            : base(pe=>Ids.Contains(pe.Id))
        {
            
        }
    }
}
