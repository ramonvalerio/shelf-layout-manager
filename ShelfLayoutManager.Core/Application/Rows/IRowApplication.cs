
using ShelfLayoutManager.Core.Domain.Rows;

namespace ShelfLayoutManager.Core.Application.Rows
{
    public interface IRowApplication
    {
        Task<List<Row>> GetRowsByCabinetNumber(string cabinetNumber);
        Task<Row> GetRowByCabinetNumber(string cabinetNumber, string number);
        Task CreateRow(string cabinetNumber, Row row);
        Task UpdateRow(string cabinetNumber, Row row);
        Task DeleteRow(string cabinetNumber, string number);
    }
}