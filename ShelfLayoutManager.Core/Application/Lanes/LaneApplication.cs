using ShelfLayoutManager.Core.Domain.Lanes;

namespace ShelfLayoutManager.Core.Application.Lanes
{
    public class LaneApplication : ILaneApplication
    {
        private readonly ILaneRepository _laneRepository;

        public LaneApplication(ILaneRepository laneRepository)
        {
            _laneRepository = laneRepository;
        }

        public async Task<List<Lane>> GetLanesByJanCode(string janCode)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Lane>> GetLanesByJanCodeFromCabinet(string cabinetNumber, string janCode)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Lane>> GetLanesByJanCodeFromCabinetRow(string cabinetNumber, string rowNumber, string janCode)
        {
            throw new NotImplementedException();
        }

        public async Task<Lane> GetLaneByNumberFromCabinetRow(string cabinetNumber, string rowNumber, string number)
        {
            throw new NotImplementedException();
        }

        public async Task CreateLaneFromCabinetRow(string cabinetNumber, string rowNumber, Lane lane)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateLaneFromCabinetRow(string cabinetNumber, string rowNumber, Lane lane)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteLaneFromCabinetRow(string cabinetNumber, string rowNumber, string number)
        {
            throw new NotImplementedException();
        }
    }
}
