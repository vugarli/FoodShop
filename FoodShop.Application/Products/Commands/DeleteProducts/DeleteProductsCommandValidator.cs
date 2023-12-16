using FluentValidation;
using FoodShop.Application.Abstractions;
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
            RuleFor(x=>x.Ids).MustAsync(async (ids,cancel)=>await repository.ProductsExistsAsync(ids,cancel))
                .WithMessage("One or more resources are not found!");
        }
    }
}
