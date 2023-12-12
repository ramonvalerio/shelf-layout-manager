using Microsoft.EntityFrameworkCore;
using ShelfLayoutManager.Core.Domain.Cabinets;
using ShelfLayoutManager.Infrastructure.Data;

namespace ShelfLayoutManager.Core.Repository
{
    public class CabinetRepository : ICabinetRepository
    {
        private readonly DataContext _context;

        public CabinetRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Cabinet>> GetAll()
        {
            return await _context.Cabinets.ToListAsync();
        }
    }
}