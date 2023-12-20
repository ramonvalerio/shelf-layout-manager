using Microsoft.EntityFrameworkCore;
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

        public async Task<List<Row>> GetAllFromCabinet(int cabinetNumber)
        {
            return await _context.Rows.Where(x => x.CabinetNumber == cabinetNumber).ToListAsync();
        }

        public async Task<Row> GetByNumberFromCabinet(int cabinetNumber, int number)
        {
            return await _context.Rows
                         .Where(x => x.CabinetNumber == cabinetNumber && x.Number == number)
                         .FirstOrDefaultAsync();
        }

        public async Task Create(Row row)
        {
            _context.Rows.Add(row);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateFromCabinet(int cabinetNumber, Row row)
        {
            row.CabinetNumber = cabinetNumber;
            _context.Rows.Update(row);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteByNumberFromCabinet(int cabinetNumber, int number)
        {
            var row = await _context.Rows.FirstOrDefaultAsync(r => r.CabinetNumber == cabinetNumber && r.Number == number);

            if (row == null)
                throw new Exception("Row not found.");

            _context.Rows.Remove(row);
            await _context.SaveChangesAsync();
        }
    }
}