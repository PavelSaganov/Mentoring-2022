using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using DatabaseInteractor.Models;
using DatabaseInteractor.Models.Enums;

namespace DatabaseInteractor.Repository.EFRepository
{
    public class OrderRepository : IRepositoryAsync<Order>
    {
        private readonly ProductContext _dbContext;

        public OrderRepository(ProductContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> CreateAsync(Order model)
        {
            await _dbContext.Orders.AddAsync(model);
            await _dbContext.SaveChangesAsync();
            return model.Id;
        }

        public async Task DeleteAsync(int id)
        {
            _dbContext.Orders.Remove(await _dbContext.Orders.FirstOrDefaultAsync(a => a.Id == id));
            await _dbContext.SaveChangesAsync();
        }

        public IQueryable<Order> GetAll()
        {
            return _dbContext.Orders.AsQueryable();
        }

        public IQueryable<Order> GetAll(Dictionary<string, object> properties)
        {
            throw new NotImplementedException();
        }

        public async Task<Order> GetByIdAsync(int id)
        {
            return await _dbContext.Orders.FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task UpdateAsync(Order model)
        {
            _dbContext.Orders.Update(model);
            await _dbContext.SaveChangesAsync();
        }
    }
}
