using ShelfLayoutManager.Core.Domain.Lanes;
using ShelfLayoutManager.Infrastructure.Data;

namespace ShelfLayoutManager.Infrastructure.Repository
{
    public class LaneRepository : ReadBaseRepository<Lane>, ILaneRepository
    {
        private readonly DataContext _context;

        public LaneRepository(DataContext context) : base(context)
        {
            _context = context;
        }
    }
}