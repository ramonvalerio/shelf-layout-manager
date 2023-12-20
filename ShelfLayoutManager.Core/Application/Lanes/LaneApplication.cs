using ShelfLayoutManager.Core.Domain;
using ShelfLayoutManager.Core.Domain.Exceptions;
using ShelfLayoutManager.Core.Domain.Lanes;

namespace ShelfLayoutManager.Core.Application.Lanes
{
    public class LaneApplication : ILaneApplication
    {
        private readonly ILaneRepository _laneRepository;
        private readonly IUnitOfWork _unitOfWork;

        public LaneApplication(ILaneRepository laneRepository, IUnitOfWork unitOfWork)
        {
            _laneRepository = laneRepository;
            _unitOfWork = unitOfWork;
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

        public async Task UpdateLaneFromCabinetRow(int cabinetNumber, int rowNumber, int number, Lane lane)
        {
            lane.RowCabinetNumber = cabinetNumber;
            lane.RowNumber = rowNumber;

            await _laneRepository.UpdateFromCabinetRow(cabinetNumber, rowNumber, number, lane);
        }

        public async Task DeleteLaneFromCabinetRow(int cabinetNumber, int rowNumber, int number)
        {
            await _laneRepository.DeleteFromCabinetRow(cabinetNumber, rowNumber, number);
        }

        public async Task MoveDrink(MoveDrinkCommand command)
        {
            using var scope = await _unitOfWork.BeginTransactionAsync();

            var fromLane = await _laneRepository.GetByNumberFromCabinetRow(
                            command.FromCabinetNumber, command.FromRowNumber, command.FromLaneNumber);

            var toLane = await _laneRepository.GetByNumberFromCabinetRow(
                command.ToCabinetNumber, command.ToRowNumber, command.ToLaneNumber);

            if (fromLane == null)
                throw new NotFoundException("Origem Lane not found.");

            if (toLane == null)
                throw new NotFoundException("Target destiny Lane not found.");

            if (fromLane.Quantity < command.Quantity)
                throw new BusinessException($"Insufficient quantity in the origin lane. Total available: {fromLane.Quantity}.");

            fromLane.Quantity -= command.Quantity;
            toLane.Quantity += command.Quantity;

            await _laneRepository.UpdateFromCabinetRow(fromLane.RowCabinetNumber, fromLane.RowNumber, fromLane.Number, fromLane);
            await _laneRepository.UpdateFromCabinetRow(toLane.RowCabinetNumber, toLane.RowNumber, toLane.Number, toLane);

            await scope.CompleteAsync();
        }
    }
}
