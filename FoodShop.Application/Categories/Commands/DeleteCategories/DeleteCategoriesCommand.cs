using FoodShop.Application.Abstractions.CQSegregationInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodShop.Application.Categories.Commands.DeleteCategories
{
    public record DeleteCategoriesCommand(IEnumerable<Guid> ids) : ICommand;
}
