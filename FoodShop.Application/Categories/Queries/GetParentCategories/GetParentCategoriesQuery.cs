using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodShop.Application.Categories.Queries.GetParentCategories
{
    public class GetParentCategoriesQuery : IRequest<IEnumerable<CategoryDto>>
    {
    }
}
