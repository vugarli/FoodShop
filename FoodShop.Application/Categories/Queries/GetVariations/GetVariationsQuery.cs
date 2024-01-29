using FoodShop.Application.Queries;
using FoodShop.Application.Variations;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodShop.Application.Categories.Queries.GetVariations
{
    public record GetVariationsQuery(Guid categoryId) : IRequest<QueryResult<VariationDto>>;
}
