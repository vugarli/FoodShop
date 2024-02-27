using FoodShop.Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodShop.Domain.Entities
{
    public enum AccountType
    { 
        Customer,
        Seller
    }

    public abstract class ApplicationUser : Entity
    {
        protected ApplicationUser(string email,Guid Id)
            :base(Id)
        {
            Email = email;
        }
        public string Email { get; set; }
        public AccountType AccountType { get; set; }
        public Guid IdentityId { get; set; }
    }


    public class ApplicationSellerUser : ApplicationUser
    {
        public ApplicationSellerUser(string Email,Guid Id)
            :base(Email,Id)
        {
            
        }
        public ICollection<Product> Products { get; set; }
        public ICollection<ProductEntry> ProductEntries { get; set; }
    }

    public class ApplicationCustomerUser : ApplicationUser
    {
        public ApplicationCustomerUser(string Email, Guid Id)
            :base(Email,Id)                { }
    }


}
