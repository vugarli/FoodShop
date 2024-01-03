using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FoodShop.Application.Queries
{
    public static class PaginationExtensions
    {
        public static IQueryable<T> AddPagination<T>(this IQueryable<T> queryable,int page,int per_page)
        {
            return queryable.Skip((page - 1) * per_page).Take(per_page);
        }

        
    }
}
