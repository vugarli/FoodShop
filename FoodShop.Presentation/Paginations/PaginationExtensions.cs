using FoodShop.Application.Queries;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FoodShop.Presentation.Paginations
{
    public static class PaginationExtensions
    {

        public static void SetUrls<T>(this PaginatedQueryResult<T> p,LinkGenerator linkgen, string actionName)
        {
            if(p.Page != 1)
                p.Previous = linkgen.GetPathByName(actionName, new { page = p.Page - 1, per_page = p.Per_Page });
            if(p.Page + 1 <= p.TotalPages)
                p.Next = linkgen.GetPathByName(actionName, new { page = p.Page + 1, per_page = p.Per_Page });
        }
    }
}
