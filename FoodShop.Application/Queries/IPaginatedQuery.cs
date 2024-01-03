using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodShop.Application.Queries
{
    internal interface IPaginatedQuery
    {
        public int page { get; init; }
        public int per_page { get; init; }
    }
}
