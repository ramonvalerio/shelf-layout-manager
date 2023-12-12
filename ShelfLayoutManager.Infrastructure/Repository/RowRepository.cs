using ShelfLayoutManager.Core.Domain.Rows;
using ShelfLayoutManager.Infrastructure.Data;

namespace ShelfLayoutManager.Infrastructure.Repository
{
    public class RowRepository : ReadBaseRepository<Row>, IRowRepository
    {
        private readonly DataContext _context;

        public RowRepository(DataContext context) : base(context)
        {
            _context = context;
        }
    }
}