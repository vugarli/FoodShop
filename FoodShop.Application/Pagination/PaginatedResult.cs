using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodShop.Application.Pagination
{
    public class PaginatedResult<T>
    {
        public PaginatedResult(IEnumerable<T> data, int page, int per_page, int rowCount)
        {
            Data = data;
            Page = page;
            Per_Page = per_page;
            RowCount = rowCount;
        }
        public IEnumerable<T> Data { get; init; }

        public int Page { get; init; }
        public int Per_Page { get; init; }
        public int RowCount { get; init; }
        public int TotalPages { get => (int) Math.Ceiling(RowCount * 1.0d /Per_Page); }

        public string Previous { get; set; }
        public string Next { get; set; }
    }

}
