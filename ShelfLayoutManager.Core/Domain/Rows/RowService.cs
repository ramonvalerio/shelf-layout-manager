using ShelfLayoutManager.Core.Domain.Cabinets;
using ShelfLayoutManager.Core.Domain.Exceptions;

namespace ShelfLayoutManager.Core.Domain.Rows
{
    public class RowService : IRowService
    {
        private readonly ICabinetRepository _cabinetRepository;
        private readonly IRowRepository _rowRepository;

        public RowService(ICabinetRepository cabinetRepository, IRowRepository rowRepository)
        {
            _cabinetRepository = cabinetRepository;
            _rowRepository = rowRepository;
        }

        public async Task Create(Row row)
        {
            var cabinet = await _cabinetRepository.GetByIdAsync(row.CabinetNumber);
            var rows = await _rowRepository.GetAllFromCabinet(cabinet.Number);

            // 1 - Get the Max current row height
            var sumCurrentRowsHeight = rows.Sum(x => x.Size.Height);
            var newCurrentRowsHeight = sumCurrentRowsHeight + row.Size.Height;

            // 2 - Check the size to add on the cabinet
            if (cabinet.Size.Height < newCurrentRowsHeight)
                throw new BusinessException($"The row height {row.Size.Height} is bigger than available cabinet height {cabinet.Size.Height}.");

            // 3 - Define the next number
            var lastRow = rows.MaxBy(x => x.Number);
            row.Number = lastRow.Number + 1;

            // 4 - Define the next position to be added
            row.PositionZ = lastRow.PositionZ + 50;
            
            // 5 - Define the cabinet number
            row.CabinetNumber = cabinet.Number;

            await _rowRepository.Create(row);
        }
    }
}