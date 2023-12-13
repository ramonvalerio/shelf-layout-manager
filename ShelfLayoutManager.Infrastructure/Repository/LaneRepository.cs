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

        public async Task<List<Lane>> GetAllByFromCabinetRow(int cabinetNumber, int rowNumber)
        {
            return await _context.Lanes
                .Where(x => x.RowCabinetNumber == cabinetNumber && x.RowNumber == rowNumber)
                .ToListAsync();
        }

        public Task<List<Lane>> GetAllByJanCode(string janCode)
        {
            throw new NotImplementedException();
        }

        public Task<List<Lane>> GetAllByJanCodeFromCabinet(int cabinetNumber, string janCode)
        {
            throw new NotImplementedException();
        }

        public Task<List<Lane>> GetAllByJanCodeFromCabinetRow(int cabinetNumber, int rowNumber, string janCode)
        {
            throw new NotImplementedException();
        }

        public Task<Lane> GetByNumberFromCabinetRow(int cabinetNumber, int rowNumber, int number)
        {
            throw new NotImplementedException();
        }

        public Task CreateFromCabinetRow(int cabinetNumber, int rowNumber, Lane lane)
        {
            throw new NotImplementedException();
        }

        public Task UpdateFromCabinetRow(int cabinetNumber, int rowNumber, Lane lane)
        {
            throw new NotImplementedException();
        }

        public Task DeleteFromCabinetRow(int cabinetNumber, int rowNumber, int number)
        {
            throw new NotImplementedException();
        }
    }
}