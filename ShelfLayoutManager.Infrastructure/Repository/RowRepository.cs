using Microsoft.EntityFrameworkCore;
using ShelfLayoutManager.Core.Domain.Rows;
using ShelfLayoutManager.Infrastructure.Data;

namespace ShelfLayoutManager.Infrastructure.Repository
{
    public class RowRepository : IRowRepository
    {
        private readonly DataContext _context;

        public RowRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Row>> GetAll()
        {
            return await _context.Rows.ToListAsync();
        }

        public async Task<Row> GetById(int id)
        {
            return await _context.Rows.SingleOrDefaultAsync(x => x.Number == id);
        }
    }
}