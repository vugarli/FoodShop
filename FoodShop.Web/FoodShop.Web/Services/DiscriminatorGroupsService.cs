//using FoodShop.Application.Categories;
//using FoodShop.Application.Pagination;
//using FoodShop.Web.Abstractions.Services;
//using FoodShop.Web.ViewModels.Categories;
//using FoodShop.Web.ViewModels.Products;
//using System.Net;

//namespace FoodShop.Web.Services
//{
//    public class DiscriminatorGroupsService : IDiscriminatorGroupsService
//    {
//        HttpClient client;

//        public DiscriminatorGroupsService(IHttpClientFactory httpClientFactory)
//        {
//            client = httpClientFactory.CreateClient("API");
//        }

//        public async Task<IEnumerable<BaseDiscriminatorGroupVM>> GetDiscriminatorGroups()
//        {
//            var categories = (await client.GetFromJsonAsync<PaginatedResult<CategoryVM>>("/categories?page=1&per_page=100")).Data;

//            if (categories == null) new List<CategoryGroupVM>();

//            var discs = categories.Where(c => c.BaseCategoryDiscriminatorId != null).GroupBy(c => new { c.BaseCategoryDiscriminatorName, c.BaseCategoryDiscriminatorId });

//            var result = new List<BaseDiscriminatorGroupVM>();

//            foreach (var dis in discs)
//            {
//                result.Add(new BaseDiscriminatorGroupVM
//                { 
//                    Id = (Guid)dis.Key.BaseCategoryDiscriminatorId,
//                    Name = dis.Key.BaseCategoryDiscriminatorName,
//                    Groups = categories.Where(c=>c.ParentId==null).Select(c => new CategoryGroupVM
//                    {
//                        CategoryGroupName = c.Name,
//                        CategoryGroupId = c.Id,
//                        SubCategories = categories.Where(a=>c.Id == a.ParentId && a.BaseCategoryDiscriminatorId == dis.Key.BaseCategoryDiscriminatorId).Select(a=>new CategoryGroupItemVM
//                        ( 
//                            a.Name,
//                            a.Id
//                        ))
//                    })
                
//                });
            
//            }
            
//            return result;
//        }
//    }
//}
