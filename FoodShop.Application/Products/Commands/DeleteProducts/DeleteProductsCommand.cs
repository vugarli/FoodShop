using FoodShop.Application.Abstractions.CQSegregationInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodShop.Application.Products.Commands.DeleteProducts
{
    public record DeleteProductsCommand(IEnumerable<Guid> Ids) : ICommand;
}
