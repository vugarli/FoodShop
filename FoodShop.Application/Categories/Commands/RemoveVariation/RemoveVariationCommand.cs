using FoodShop.Application.Abstractions.CQSegregationInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodShop.Application.Categories.Commands.RemoveVariation
{
    public record RemoveVariationCommand(Guid CategoryId,Guid VariationId) : ICommand;
}
