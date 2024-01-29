using FoodShop.Application.Abstractions.CQSegregationInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FoodShop.Application.Variations.Commands.DeleteVariations
{
    public record DeleteVariationsCommand(IEnumerable<Guid> Ids) : ICommand;
}
