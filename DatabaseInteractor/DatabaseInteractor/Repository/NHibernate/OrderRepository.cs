using DatabaseInteractor.Models;
using NHibernate;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            ISession session;
            try
            {
                session = factory.GetCurrentSession();
            }
            catch
            {
                session = factory.OpenSession();
            }

            using (ITransaction transaction = session.BeginTransaction())
            {
                var idOfCreated = await session.SaveAsync(model);

                return (int)idOfCreated;
            }
        }

        public async Task DeleteAsync(int id)
        {
            ISession session;
            try
            {
                session = factory.GetCurrentSession();
            }
            catch
            {
                session = factory.OpenSession();
            }

            using (ITransaction transaction = session.BeginTransaction())
            {
                var item = await GetByIdAsync(id);
                await session.DeleteAsync(item);
                await transaction.CommitAsync();
            }
        }

        public IQueryable<Order> GetAll()
        {
            ISession session;
            try
            {
                session = factory.GetCurrentSession();
            }
            catch
            {
                session = factory.OpenSession();
            }

            return session.Query<Order>();
        }

        public IQueryable<Order> GetAll(Dictionary<string, object> properties)
        {
            ISession session;
            try
            {
                session = factory.GetCurrentSession();
            }
            catch
            {
                session = factory.OpenSession();
            }

            var queryStringBuilder = new StringBuilder("EXEC FilterBy");

            var sqlQuery = session.CreateSQLQuery("EXEC FilterBy");

            foreach (var prop in properties)
            {
                sqlQuery.SetParameter(prop.Key, prop.Value);
            }

            var result = sqlQuery.Enumerable<Order>().AsQueryable();

            return result;
        }

        public async Task<Order> GetByIdAsync(int id)
        {
            ISession session;
            try
            {
                session = factory.GetCurrentSession();
            }
            catch
            {
                session = factory.OpenSession();
            }

            return await session.GetAsync<Order>(id);
        }

        public async Task UpdateAsync(Order model)
        {
            ISession session;
            try
            {
                session = factory.GetCurrentSession();
            }
            catch
            {
                session = factory.OpenSession();
            }

            using (ITransaction transaction = session.BeginTransaction())
            {
                await session.UpdateAsync(model);
                await transaction.CommitAsync();
            }
        }
    }
}
