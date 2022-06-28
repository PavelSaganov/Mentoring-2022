using DatabaseInteractor.Models;
using NHibernate;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseInteractor.Repository.NHibernate
{
    public class OrderRepository : IRepositoryAsync<Order>
    {
        private ISessionFactory factory;

        public OrderRepository(ISessionFactory factory)
        {
                this.factory = factory;
        }

        public async Task<int> CreateAsync(Order model)
        {
            using (var session = factory.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                var idOfCreated = await session.SaveAsync(model);
                
                return (int)idOfCreated;
            }
        }

        public async Task DeleteAsync(int id)
        {
            using (var session = factory.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                var item = await GetByIdAsync(id);
                await session.DeleteAsync(item);
                await transaction.CommitAsync();
            }
        }

        public IQueryable<Order> GetAll()
        {
            using var session = factory.OpenSession();
            return session.Query<Order>();
        }

        public IQueryable<Order> GetAll(Dictionary<string, object> properties)
        {
            using var session = factory.OpenSession();
            return session.Query<Order>();
        }

        public async Task<Order> GetByIdAsync(int id)
        {
            using (var session = factory.OpenSession())
                return await session.GetAsync<Order>(id);
        }

        public async Task UpdateAsync(Order model)
        {
            using (var session = factory.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                await session.UpdateAsync(model);
                await transaction.CommitAsync();
            }
        }
    }
}
