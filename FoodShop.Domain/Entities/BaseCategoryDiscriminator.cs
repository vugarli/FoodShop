using FoodShop.Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodShop.Domain.Entities
{
	public class BaseCategoryDiscriminator : Entity
	{
        public string Name { get; set; }
		public BaseCategoryDiscriminator(Guid id, string Name) : base(id)
		{
			this.Name = Name;
		}

        public IEnumerable<Category> Categories { get; set; }
    }
}
