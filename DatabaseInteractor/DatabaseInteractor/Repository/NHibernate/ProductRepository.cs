using DatabaseInteractor.Models;
using NHibernate;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
                await transaction.CommitAsync();
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

        public IQueryable<Product> GetAll()
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

            return session.Query<Product>();
        }

        public IQueryable<Product> GetAll(Dictionary<string, object> properties)
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

            return session.Query<Product>();
        }

        public async Task<Product> GetByIdAsync(int id)
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

            return await session.GetAsync<Product>(id);
        }

        public async Task UpdateAsync(Product model)
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
