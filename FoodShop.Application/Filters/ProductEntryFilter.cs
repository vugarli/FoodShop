using FoodShop.Application.Categories.Commands.CreateCategory;
using FoodShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodShop.Application.Filters
{
    public class ProductEntryFilter : IFilter<ProductEntry>
    {
        public string? Category { get; set; }
        public string? SubCategory { get; set; }
        public string? Gender { get; set; }
        public int? MinPrice { get; set; }
        public int? MaxPrice { get; set; }
        
        public bool? LatestArrivals { get; set; }



        public IQueryable<ProductEntry> Filter(IQueryable<ProductEntry> query)
        {
            if (SubCategory != null)
                query = query.Where<ProductEntry>(pe => pe.Product.Category.Name == SubCategory);
            if (MinPrice != null)
                query = query.Where(pe => pe.Price >= MinPrice);
            if (MaxPrice != null)
                query = query.Where(pe => pe.Price <= MaxPrice);
            if (Gender != null)
                query = query.Where(pe => pe.Product.Category.BaseCategoryDiscriminator.Name == Gender);

            if (Category != null)
                query = query.Where(pe => pe.Product.Category.ParentCategory != null && pe.Product.Category.ParentCategory.Name == Category);

            if (LatestArrivals != null && LatestArrivals == true)
                query = query.OrderByDescending(pe => pe.CreatedAt).Take(8);

            return query;
        }
    }
}
