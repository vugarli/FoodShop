using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FoodShop.Application.Queries
{
    public interface IPaginatedResult
    {
        public int Page { get; init; }
        public int Per_Page { get; init; }
        public string? Previous { get; set; }
        public string? Next { get; set; }

        public bool HasNext { get; }
        public bool HasPrev { get; }
    }
    public class PaginatedQueryResult<T> : QueryResult<T>, IPaginatedResult
    {
        public PaginatedQueryResult(IEnumerable<T> data, int page, int per_page, int rowCount) :base(data)
        {
            Page = page;
            Per_Page = per_page;
            RowCount = rowCount;
        }
        
        public int Page { get; init; }
        public int Per_Page { get; init; }
        public int RowCount { get; init; }
        public int TotalPages { get => (int) Math.Ceiling(RowCount * 1.0d /Per_Page); }

        public string? Previous { get; set; }
        public string? Next { get; set; }

        public bool HasNext => Page < TotalPages;

        public bool HasPrev => Page > 1;
    }

}
