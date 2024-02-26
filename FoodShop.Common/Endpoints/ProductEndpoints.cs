using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodShop.Common.Endpoints
{
    public class ProductEndpoints
    {
        private const string Prefix = "/api/Products";

        public const string GetProductsEndpoint = Prefix + "/";
        public const string PaginatedProductsEndpoint = Prefix + "?page={page}&per_page={per_page}";
        public const string GetProductByIdEndpoint = Prefix + "/{id}";
        public const string UpdateProductEndpoint = Prefix + "/{id}";
        public const string DeleteProductByIdEndpoint = Prefix + "/{id}";
        public const string PostProductEndpoint = Prefix + "/";
        public const string DeleteProductsEndpoint = Prefix + "/";



    }
}
