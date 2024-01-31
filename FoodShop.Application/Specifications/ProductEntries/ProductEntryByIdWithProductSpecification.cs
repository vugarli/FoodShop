using FoodShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodShop.Application.Specifications.ProductEntries
{
    public class ProductEntryByIdWithProductSpecification : Specification<ProductEntry>
    {
        public ProductEntryByIdWithProductSpecification(Guid Id)
            :base(pe => pe.Id == Id)
        {
            AddInclude(pe => pe.Product);
        }
    }
}
