using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatabaseInteractor.Models;
using NHibernate;

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
            var session = GetOrCreateSession();

            using (ITransaction transaction = session.BeginTransaction())
            {
                var idOfCreated = await session.SaveAsync(model);

                return (int)idOfCreated;
            }
        }

        public async Task DeleteAsync(int id)
        {
            var session = GetOrCreateSession();

            using (ITransaction transaction = session.BeginTransaction())
            {
                var item = await GetByIdAsync(id);
                await session.DeleteAsync(item);
                await transaction.CommitAsync();
            }
        }

        public IQueryable<Order> GetAll()
        {
            var session = GetOrCreateSession();

            return session.Query<Order>();
        }

        public IQueryable<Order> GetAll(Dictionary<string, object> properties)
        {
            var session = GetOrCreateSession();

            var query = "EXEC FilterBy " + string.Join(", ", properties.Select(p => $"@{p.Key}=:{p.Key}"));

            var result = session.CreateSQLQuery(query)
                .AddEntity(typeof(Order))
                .SetParameter("Status", 1)
                .SetParameter("ProductId", 2)
                .List<Order>();

            return result.AsQueryable();
        }

        private ISession GetOrCreateSession()
        {
            var session = GetOrCreateSession();

            return session;
        }

        public async Task<Order> GetByIdAsync(int id)
        {
            var session = GetOrCreateSession();

            return await session.GetAsync<Order>(id);
        }

        public async Task UpdateAsync(Order model)
        {
            var session = GetOrCreateSession();

            using (ITransaction transaction = session.BeginTransaction())
            {
                await session.UpdateAsync(model);
                await transaction.CommitAsync();
            }
        }
    }
}
