using FoodShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodShop.Application.Specifications.Products
{
    public class ProductByIdSpecification : Specification<Product>
    {
        public ProductByIdSpecification(Guid Id)
            :base(p=>p.Id == Id) {}

    }
}
