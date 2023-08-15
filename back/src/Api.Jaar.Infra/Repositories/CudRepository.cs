using Api.Jaar.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Jaar.Infra.Repositories
{
    public class CudRepository : ICudRepository
    {
        private readonly DataContext _context;

        public CudRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<bool> AddAsync<T>(T entity) where T : class
        {
            _context.Add(entity);
            return (await _context.SaveChangesAsync()) > 0;
        }

        public async Task<bool> DeleteAsync<T>(T entity) where T : class
        {
            _context.Remove(entity);
            return (await _context.SaveChangesAsync()) > 0;
        }

        public async Task<bool> UpdateAsync<T>(T entity) where T : class
        {
            _context.Update(entity);
            return (await _context.SaveChangesAsync()) > 0;
        }

        public async Task<IList<T>> GetAllAsync<T>() where T : class
        {
            return await _context.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<T> GetByIdAsync<T>(int id) where T : class
        {
            return await _context.Set<T>().FindAsync(id);
        }
    }
}