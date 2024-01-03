using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodShop.Application.Filters
{
    public interface IFilter<T>
    {
        public IQueryable<T> Filter(IQueryable<T> query);
    }
}
