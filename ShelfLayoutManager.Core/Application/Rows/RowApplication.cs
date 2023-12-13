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

        public Task<List<Row>> GetRowsByCabinetNumber(string cabinetNumber)
        {
            throw new NotImplementedException();
        }

        public Task<Row> GetRowByCabinetNumber(string cabinetNumber, string number)
        {
            throw new NotImplementedException();
        }

        public Task CreateRow(string cabinetNumber, Row row)
        {
            throw new NotImplementedException();
        }

        public Task UpdateRow(string cabinetNumber, Row row)
        {
            throw new NotImplementedException();
        }

        public Task DeleteRow(string cabinetNumber, string number)
        {
            throw new NotImplementedException();
        }
    }
}