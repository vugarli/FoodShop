﻿namespace FoodShop.Admin.WebApp.Client.Pages.Categories.ViewModels
{
    public class VM_CreateCategory
    {
        public Guid? ParentId { get; set; }
        public Guid? BaseDiscriminatorId { get; set; }
        public IEnumerable<Guid> Variations { get; set; }
        public string Name { get; set; }
    }
}
