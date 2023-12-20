using Microsoft.EntityFrameworkCore;
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

        public async Task<List<Lane>> GetAllFromCabinetRow(int cabinetNumber, int rowNumber)
        {
            return await _context.Lanes
                .Where(x => x.RowCabinetNumber == cabinetNumber && x.RowNumber == rowNumber)
                .ToListAsync();
        }

        public async Task<List<Lane>> GetAllByJanCode(string janCode)
        {
            return await _context.Lanes.Where(x => x.JanCode == janCode).ToListAsync();
        }

        public async Task<List<Lane>> GetAllByJanCodeFromCabinet(int cabinetNumber, string janCode)
        {
            return await _context.Lanes
            .Where(x => x.RowCabinetNumber == cabinetNumber && x.JanCode == janCode)
            .ToListAsync();
        }

        public async Task<List<Lane>> GetAllByJanCodeFromCabinetRow(int cabinetNumber, int rowNumber, string janCode)
        {
            return await _context.Lanes
            .Where(x => x.RowCabinetNumber == cabinetNumber && x.RowNumber == rowNumber && x.JanCode == janCode)
            .ToListAsync();
        }

        public async Task<Lane> GetByNumberFromCabinetRow(int cabinetNumber, int rowNumber, int number)
        {
            return await _context.Lanes.FirstOrDefaultAsync(
                x => x.RowCabinetNumber == cabinetNumber 
                && x.RowNumber == rowNumber 
                && x.Number == number);
        }

        public async Task<Lane> CreateFromCabinetRow(Lane lane)
        {
            var result = await _context.Lanes.AddAsync(lane);
            await _context.SaveChangesAsync();

            return result.Entity;
        }

        public async Task UpdateFromCabinetRow(int cabinetNumber, int rowNumber, int number, Lane lane)
        {
            var existingLane = await _context.Lanes
            .FirstOrDefaultAsync(x => x.RowCabinetNumber == cabinetNumber && x.RowNumber == rowNumber && x.Number == number);

            if (existingLane == null)
                throw new Exception("Lane not found");

            existingLane.JanCode = lane.JanCode;
            existingLane.Quantity = lane.Quantity;
            existingLane.PositionX = lane.PositionX;

            _context.Lanes.Update(existingLane);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteFromCabinetRow(int cabinetNumber, int rowNumber, int number)
        {
            var lane = await _context.Lanes
            .FirstOrDefaultAsync(x => x.RowCabinetNumber == cabinetNumber && x.RowNumber == rowNumber && x.Number == number);

            if (lane == null)
                throw new Exception("Lane not found");

            _context.Lanes.Remove(lane);
            await _context.SaveChangesAsync();
        }
    }
}