using ShelfLayoutManager.Core.Domain.Rows;
using ShelfLayoutManager.Core.ValueObjects;

namespace ShelfLayoutManager.Core.Application.Rows
{
    public class RowApplication : IRowApplication
    {
        private readonly IRowRepository _rowRepository;
        private readonly IRowService _rowService;

        public RowApplication(IRowRepository rowRepository, IRowService rowService)
        {
            _rowRepository = rowRepository;
            _rowService = rowService;
        }

        public async Task<List<Row>> GetRows()
        {
            return await _rowRepository.GetAllAsync();
        }

        public async Task<List<Row>> GetRowsByCabinetNumber(int cabinetNumber)
        {
            return await _rowRepository.GetAllFromCabinet(cabinetNumber);
        }

        public async Task<Row> GetRowByCabinetNumber(int cabinetNumber, int number)
        {
            return await _rowRepository.GetByNumberFromCabinet(cabinetNumber, number);
        }

        public async Task CreateRow(int cabinetNumber, RowCommand command)
        {
            var row = new Row
            {
                CabinetNumber = cabinetNumber,
                Size = new RowSize(command.Height)
            };

            await _rowService.Create(row);
        }

        public async Task UpdateRow(int cabinetNumber, Row row)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteRow(int cabinetNumber, int number)
        {
            throw new NotImplementedException();
        }
    }
}