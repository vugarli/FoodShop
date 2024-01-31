using FoodShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodShop.Application.Specifications.ProductEntries
{
    public class ProductEntryByIdSpecification : Specification<ProductEntry>
    {
        public ProductEntryByIdSpecification(Guid Id)
            :base(pe=>pe.Id == Id) {}
    }
}
