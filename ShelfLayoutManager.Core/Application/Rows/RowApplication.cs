using ShelfLayoutManager.Core.Domain.Rows;

namespace ShelfLayoutManager.Core.Application.Rows
{
    public class RowApplication : IRowApplication
    {
        private readonly IRowRepository _rowRepository;

        public RowApplication(IRowRepository rowRepository)
        {
            _rowRepository = rowRepository;
        }

        public async Task<List<Row>> GetRows()
        {
            return await _rowRepository.GetAllAsync();
        }

        public async Task<List<Row>> GetRowsByCabinetNumber(string cabinetNumber)
        {
            throw new NotImplementedException();
        }

        public async Task<Row> GetRowByCabinetNumber(string cabinetNumber, string number)
        {
            throw new NotImplementedException();
        }

        public async Task CreateRow(string cabinetNumber, Row row)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateRow(string cabinetNumber, Row row)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteRow(string cabinetNumber, string number)
        {
            throw new NotImplementedException();
        }
    }
}