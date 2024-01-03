using FoodShop.Application.Abstractions;
using FoodShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodShop.Infrastructure.Repositories
{
    public class BaseCategoryDiscriminatorRepository : IBaseCategoryDiscriminatorRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public BaseCategoryDiscriminatorRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateBaseCategoryDiscriminatorAsync(BaseCategoryDiscriminator baseCategoryDiscr)
        {
            await _dbContext.Set<BaseCategoryDiscriminator>().AddAsync(baseCategoryDiscr);
        }

        public async Task DeleteBaseCategoryDiscriminatorByIdAsync(Guid id)
        {
            await _dbContext.Set<BaseCategoryDiscriminator>().Where(c => c.Id == id).ExecuteDeleteAsync();
        }

        public async Task<BaseCategoryDiscriminator> GetBaseCategoryDiscriminatorByIdAsync(Guid id)
        {
            var res = await _dbContext.Set<BaseCategoryDiscriminator>().FirstOrDefaultAsync(c => c.Id == id);
            return res;
        }

        public async Task<IEnumerable<BaseCategoryDiscriminator>> GetBaseCategoryDiscriminatorsAsync()
        {
            var res = await _dbContext.Set<BaseCategoryDiscriminator>().ToListAsync();
            return res;
        }

        public async Task<int> GetBaseCategoryDiscriminatorsCountAsync()
        {
            var res = await _dbContext.Set<BaseCategoryDiscriminator>().CountAsync();
            return res;
        }

        public async Task<BaseCategoryDiscriminator> UpdateBaseCategoryDiscriminatorAsync(BaseCategoryDiscriminator baseCategoryDiscr)
        {
            _dbContext.Attach(baseCategoryDiscr);
            _dbContext.Entry(baseCategoryDiscr).State = EntityState.Modified;
            return baseCategoryDiscr;
        }
    }
}
