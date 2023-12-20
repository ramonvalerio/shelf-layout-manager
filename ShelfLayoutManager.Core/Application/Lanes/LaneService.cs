using ShelfLayoutManager.Core.Domain.Exceptions;
using ShelfLayoutManager.Core.Domain.Lanes;
using ShelfLayoutManager.Core.Domain.Rows;

namespace ShelfLayoutManager.Core.Application.Lanes
{
    public class LaneService : ILaneService
    {
        private readonly ILaneRepository _laneRepository;
        private readonly IRowRepository _rowRepository;

        public LaneService(ILaneRepository laneRepository, IRowRepository rowRepository)
        {
            _laneRepository = laneRepository;
            _rowRepository = rowRepository;
        }

        public async Task<Lane> CreateFromCabinetRow(Lane lane)
        {
            var row = await _rowRepository.GetByNumberFromCabinet(lane.RowCabinetNumber, lane.RowNumber);

            if (row == null)
                throw new NotFoundException($"Row with CabinetNumber {lane.RowCabinetNumber} and RowNumber {lane.RowNumber} not found.");

            var lanes = await _laneRepository.GetAllFromCabinetRow(lane.RowCabinetNumber, lane.RowNumber);
            if (lanes.Any())
            {
                // 1 - Define position X
                var lastLane = lanes.MaxBy(x => x.Number);
                lane.Number = lastLane.Number + 1;

                // 2 - Define the next position to be added
                lane.PositionX = lastLane.PositionX + 5;
            }
            else
            {
                lane.PositionX = 5;
            }

            return await _laneRepository.CreateFromCabinetRow(lane);
        }
    }
}
