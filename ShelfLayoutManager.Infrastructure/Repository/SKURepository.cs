using ShelfLayoutManager.Core.Domain.SKUs;
using ShelfLayoutManager.Infrastructure.Data;

namespace ShelfLayoutManager.Infrastructure.Repository
{
    public class SKURepository : ReadBaseRepository<SKU>, ISKURepository
    {
        private readonly DataContext _context;

        public SKURepository(DataContext context) : base(context)
        {
            _context = context;
        }
    }
}