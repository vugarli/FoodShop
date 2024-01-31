using FluentValidation;
using FoodShop.Application.Abstractions;
using FoodShop.Application.Specifications.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodShop.Application.Products.Commands.DeleteProducts
{
    public class DeleteProductsCommandValidator : AbstractValidator<DeleteProductsCommand>
    {
        public DeleteProductsCommandValidator(IProductRepository repository)
        {
            RuleFor(x=>x.Ids).MustAsync(async (ids,cancel)=>
            {
            var spec = new ProductsByIdsSpecification(ids);
                return await repository.CheckProductsBySpecification(spec,ids.Count());
            })
                .WithMessage("One or more resources are not found!");
        }
    }
}
