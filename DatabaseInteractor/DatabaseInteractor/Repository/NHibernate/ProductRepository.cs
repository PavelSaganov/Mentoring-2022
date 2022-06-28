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
            using (var session = factory.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                var idOfCreated = await session.SaveAsync(model);
                await transaction.CommitAsync();
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

        public IQueryable<Product> GetAll()
        {
            using (var session = factory.OpenSession())
                return session.Query<Product>();
        }

        public IQueryable<Product> GetAll(Dictionary<string, object> properties)
        {
            using (var session = factory.OpenSession())
                return session.Query<Product>();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            using (var session = factory.OpenSession())
                return await session.GetAsync<Product>(id);
        }

        public async Task UpdateAsync(Product model)
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
