using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseInteractor.Repository
{
    /// <summary>
    /// Interface with Create Read Update Delete operations.
    /// </summary>
    /// <typeparam name="T">Model class.</typeparam>
    public interface IRepositoryAsync<T>
        where T : class
    {
        /// <summary>
        /// Creates a new model in database.
        /// </summary>
        /// <param name="model">Model, that should be created.</param>
        /// <returns>id of insered column.</returns>
        Task<int> CreateAsync(T model);

        /// <summary>
        /// Reads model from database by id.
        /// </summary>
        /// <param name="id">Id of model in database.</param>
        /// <returns>Object of model class.</returns>
        Task<T> GetByIdAsync(int id);

        /// <summary>
        /// Updates model in database.
        /// </summary>
        /// <param name="model">New model.</param>
        Task UpdateAsync(T model);

        /// <summary>
        /// Deletes model in database by id.
        /// </summary>
        /// <param name="id">Id of model that should be deleted.</param>
        Task DeleteAsync(int id);

        /// <summary>
        /// Gets all objects.
        /// </summary>
        /// <returns>Returns list of objects.</returns>
        IQueryable<T> GetAll();

        IQueryable<T> GetAll(Dictionary<string, object> properties);
    }
}
