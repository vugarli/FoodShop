using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FoodShop.Application.Queries
{
    [JsonPolymorphic]
    [JsonDerivedType(typeof(QueryResult<>))]
    [JsonDerivedType(typeof(PaginatedQueryResult<>))]
    public interface IQueryResult
    { 
        
    }

    public class QueryResult<T> : IQueryResult
    {
        public IEnumerable<T> Data { get; init; }

        public QueryResult(IEnumerable<T> data)
        {
            Data = data;
        }
    }
}
