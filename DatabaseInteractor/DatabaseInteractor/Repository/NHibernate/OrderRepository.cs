using DatabaseInteractor.Models;
using NHibernate;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseInteractor.Repository.NHibernate
{
    public class OrderRepository : IRepositoryAsync<Order>
    {
        private ISession session;

        public OrderRepository(ISession session)
        {
            this.session = session;
        }

        public async Task<int> CreateAsync(Order model)
        {
            var idOfCreated = await session.SaveAsync(model);

            return (int)idOfCreated;
        }

        public async Task DeleteAsync(int id)
        {
            var item = await GetByIdAsync(id);
            await session.DeleteAsync(item);
        }

        public IQueryable<Order> GetAll()
        {
            return session.Query<Order>();
        }

        public IQueryable<Order> GetAll(Dictionary<string, object> properties)
        {
            return session.Query<Order>();
        }

        public async Task<Order> GetByIdAsync(int id)
        {
            return await session.GetAsync<Order>(id);
        }

        public async Task UpdateAsync(Order model)
        {
            await session.UpdateAsync(model);
        }
    }
}
