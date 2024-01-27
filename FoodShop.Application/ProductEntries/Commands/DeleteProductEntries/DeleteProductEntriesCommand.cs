using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodShop.Application.Abstractions.CQSegregationInterfaces;


namespace FoodShop.Application.ProductEntries.Commands.DeleteProductEntries
{
    public record DeleteProductEntriesCommand(IEnumerable<Guid> Ids) : ICommand;
}
