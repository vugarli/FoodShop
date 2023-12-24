using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodShop.Domain.Entities
{
	public class VariationCategory
	{
		public VariationCategory(Guid categoryId, Guid variationId)
		{
			CategoryId = categoryId;
			VariationId = variationId;
		}

		public Category Category { get; set; }
        public Guid CategoryId { get; set; }

        public Guid VariationId { get; set; }
        public Variation Variation { get; set; }
    }
}
