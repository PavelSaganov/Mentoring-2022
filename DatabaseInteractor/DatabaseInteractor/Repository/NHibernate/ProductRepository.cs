using DatabaseInteractor.Models;
using NHibernate;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseInteractor.Repository.NHibernate
{
    public class ProductRepository : IRepositoryAsync<Product>
    {
        private ISession session;

        public ProductRepository(ISession session)
        {
            this.session = session;
        }

        public async Task<int> CreateAsync(Product model)
        {
            var idOfCreated = await session.SaveAsync(model);

            return (int)idOfCreated;
        }

        public async Task DeleteAsync(int id)
        {
            var item = await GetByIdAsync(id);
            await session.DeleteAsync(item);
        }

        public IQueryable<Product> GetAll()
        {
            return session.Query<Product>();
        }

        public IQueryable<Product> GetAll(Dictionary<string, object> properties)
        {
            return session.Query<Product>();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await session.GetAsync<Product>(id);
        }

        public async Task UpdateAsync(Product model)
        {
            await session.UpdateAsync(model);
        }
    }
}
