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
            return await _laneRepository.GetAllByJanCode(janCode);
        }

        public async Task<List<Lane>> GetLanesByJanCodeFromCabinet(int cabinetNumber, string janCode)
        {
            return await _laneRepository.GetAllByJanCodeFromCabinet(cabinetNumber, janCode);
        }

        public async Task<List<Lane>> GetLanesByJanCodeFromCabinetRow(int cabinetNumber, int rowNumber, string janCode)
        {
            return await _laneRepository.GetAllByJanCodeFromCabinetRow(cabinetNumber, rowNumber, janCode);
        }

        public async Task<Lane> GetLaneByNumberFromCabinetRow(int cabinetNumber, int rowNumber, int number)
        {
            return await _laneRepository.GetByNumberFromCabinetRow(cabinetNumber, rowNumber, number);
        }

        public async Task CreateLaneFromCabinetRow(int cabinetNumber, int rowNumber, Lane lane)
        {
            lane.RowCabinetNumber = cabinetNumber;
            lane.RowNumber = rowNumber;

            await _laneRepository.CreateFromCabinetRow(cabinetNumber, rowNumber, lane);
        }

        public async Task UpdateLaneFromCabinetRow(int cabinetNumber, int rowNumber, Lane lane)
        {
            lane.RowCabinetNumber = cabinetNumber;
            lane.RowNumber = rowNumber;

            await _laneRepository.UpdateFromCabinetRow(cabinetNumber, rowNumber, lane);
        }

        public async Task DeleteLaneFromCabinetRow(int cabinetNumber, int rowNumber, int number)
        {
            await _laneRepository.DeleteFromCabinetRow(cabinetNumber, rowNumber, number);
        }
    }
}
