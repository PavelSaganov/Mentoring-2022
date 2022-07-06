using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatabaseInteractor.Models;
using NHibernate;

namespace DatabaseInteractor.Repository.NHibernate
{
    public class ProductRepository : IRepositoryAsync<Product>
    {
        private ISessionFactory factory;

        public ProductRepository(ISessionFactory factory)
        {
            this.factory = factory;
        }

        public async Task<int> CreateAsync(Product model)
        {
            var session = GetOrCreateSession();

            using (ITransaction transaction = session.BeginTransaction())
            {
                var idOfCreated = await session.SaveAsync(model);
                await transaction.CommitAsync();
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

        public IQueryable<Product> GetAll()
        {
            var session = GetOrCreateSession();

            return session.Query<Product>();
        }

        public IQueryable<Product> GetAll(Dictionary<string, object> properties)
        {
            var session = GetOrCreateSession();

            return session.Query<Product>();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            var session = GetOrCreateSession();

            return await session.GetAsync<Product>(id);
        }

        public async Task UpdateAsync(Product model)
        {
            var session = GetOrCreateSession();

            using (ITransaction transaction = session.BeginTransaction())
            {
                await session.UpdateAsync(model);
                await transaction.CommitAsync();
            }
        }

        private ISession GetOrCreateSession()
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

            return session;
        }
    }
}
