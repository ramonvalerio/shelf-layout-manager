using Microsoft.EntityFrameworkCore;
using ShelfLayoutManager.Core.Domain.Cabinets;
using ShelfLayoutManager.Core.Domain.Exceptions;
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

        public async Task<List<Cabinet>> GetAll()
        {
            return await _context.Cabinets.ToListAsync();
        }

        public async Task<Cabinet> Create(Cabinet cabinet)
        {
            var result = await _context.Cabinets.AddAsync(cabinet);
            await _context.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<Cabinet> Update(Cabinet updatedCabinet)
        {
            var existingCabinet = await _context.Cabinets.FindAsync(updatedCabinet.Number);

            if (existingCabinet == null)
                throw new BusinessException($"Cabinet {updatedCabinet.Number} not found.");

            existingCabinet.Position = updatedCabinet.Position;
            existingCabinet.Size = updatedCabinet.Size;
            await _context.SaveChangesAsync();

            return existingCabinet;
        }

        public async Task Delete()
        {
            var entity = await _context.Cabinets.LastOrDefaultAsync();

            if (entity == null)
                throw new KeyNotFoundException("Cabinet not found.");

            _context.Cabinets.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}