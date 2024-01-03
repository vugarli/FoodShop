using FoodShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodShop.Application.Abstractions
{
    public interface IBaseCategoryDiscriminatorRepository
    {
        public Task<IEnumerable<BaseCategoryDiscriminator>> GetBaseCategoryDiscriminatorsAsync();
        public Task<BaseCategoryDiscriminator> GetBaseCategoryDiscriminatorByIdAsync(Guid id);
        public Task<BaseCategoryDiscriminator> UpdateBaseCategoryDiscriminatorAsync(BaseCategoryDiscriminator category);
        public Task DeleteBaseCategoryDiscriminatorByIdAsync(Guid id);
        public Task CreateBaseCategoryDiscriminatorAsync(BaseCategoryDiscriminator category);

        public Task<int> GetBaseCategoryDiscriminatorsCountAsync();

    }
}
