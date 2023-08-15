using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Jaar.Domain.Repositories
{
    public interface ICudRepository
    {
        Task<bool> AddAsync<T>(T entity) where T : class;

        Task<bool> UpdateAsync<T>(T entity) where T : class;

        Task<bool> DeleteAsync<T>(T entity) where T : class;

        Task<IList<T>> GetAllAsync<T>() where T : class;

        Task<T> GetByIdAsync<T>(int id) where T : class;
    }
}