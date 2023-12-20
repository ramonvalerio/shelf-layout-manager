using ShelfLayoutManager.Core.Domain.Cabinets;
using ShelfLayoutManager.Core.Domain.Lanes;
using ShelfLayoutManager.Core.Domain.Rows;
using ShelfLayoutManager.Core.ValueObjects;

namespace ShelfLayoutManager.Core.Application.Cabinets
{
    public class CabinetApplication : ICabinetApplication
    {
        private readonly ICabinetRepository _cabinetRepository;
        private readonly IRowRepository _rowRepository;
        private readonly ILaneRepository _laneRepository;

        public CabinetApplication(ICabinetRepository cabinetRepository,
            IRowRepository rowRepository,
            ILaneRepository laneRepository)
        {
            _cabinetRepository = cabinetRepository;
            _rowRepository = rowRepository;
            _laneRepository = laneRepository;
        }

        public async Task<List<Cabinet>> GetCabinets()
        {
            var cabinets = await _cabinetRepository.GetAllAsync();

            foreach (var cabinet in cabinets)
            {
                var cabinetRows = await _rowRepository.GetAllFromCabinet(cabinet.Number);

                if (cabinet.Rows is null)
                    continue;

                cabinet.Rows.AddRange(cabinetRows);

                foreach (var row in cabinet.Rows)
                {
                    var rowLanes = await _laneRepository.GetAllByFromCabinetRow(cabinet.Number, row.Number);
                    row.Lanes.AddRange(rowLanes);
                }
            }

            return cabinets;
        }

        public async Task<Cabinet> GetCabinetByNumber(int number)
        {
            return await _cabinetRepository.GetByIdAsync(number);
        }

        public async Task<Cabinet> CreateCabinet(CreateCabinetCommand command)
        {
            var position = new Position { X = command.X, Y = command.Y, Z = command.Z };
            var size = new Size { Width = command.Width, Height = command.Height, Depth = command.Depth };
            var newCabinet = new Cabinet(command.Number, position, size);

            return await _cabinetRepository.Create(newCabinet);
        }
    }
}
