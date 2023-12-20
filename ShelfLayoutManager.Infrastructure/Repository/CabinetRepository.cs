using ShelfLayoutManager.Core.Domain.Cabinets;
using ShelfLayoutManager.Infrastructure.Data;
using ShelfLayoutManager.Infrastructure.Repository;

namespace ShelfLayoutManager.Core.Repository
{
    public class CabinetRepository : ReadBaseRepository<Cabinet>, ICabinetRepository
    {
        private readonly DataContext _context;

        public CabinetRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Cabinet> Create(Cabinet cabinet)
        {
            var result = await _context.Cabinets.AddAsync(cabinet);
            await _context.SaveChangesAsync();

            return result.Entity;
        }
    }
}