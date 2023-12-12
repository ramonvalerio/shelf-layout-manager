using Microsoft.EntityFrameworkCore;
using ShelfLayoutManager.Core.Domain;
using ShelfLayoutManager.Infrastructure.Data;

namespace ShelfLayoutManager.Infrastructure.Repository
{
    public class ReadBaseRepository<TEntity> : IReadBaseRepository<TEntity> where TEntity : class
    {
        private readonly DbSet<TEntity> _dbSet;

        public ReadBaseRepository(DataContext context)
        {
            _dbSet = context.Set<TEntity>();
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }
    }
}
