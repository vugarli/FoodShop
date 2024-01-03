using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodShop.Application.BaseCategoryDiscriminators.Queries.GetBaseCategoryDiscriminators
{
    public class GetBaseCategoryDiscriminatorsQuery : IRequest<IEnumerable<BaseCategoryDiscriminatorDto>>
    {
    }
}
