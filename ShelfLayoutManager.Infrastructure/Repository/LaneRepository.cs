using Microsoft.EntityFrameworkCore;
using ShelfLayoutManager.Core.Domain.Lanes;
using ShelfLayoutManager.Infrastructure.Data;

namespace ShelfLayoutManager.Infrastructure.Repository
{
    public class LaneRepository : ILaneRepository
    {
        private readonly DataContext _context;

        public LaneRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Lane>> GetAll()
        {
            return await _context.Lanes.ToListAsync();
        }

        public async Task<Lane> GetById(int id)
        {
            return await _context.Lanes.SingleOrDefaultAsync(x => x.Number == id);
        }
    }
}