using ShelfLayoutManager.Core.Domain.Rows;

namespace ShelfLayoutManager.Core.Application.Rows
{
    public interface IRowApplication
    {
        Task<List<Row>> GetRows();
        Task<List<Row>> GetRowsByCabinetNumber(int cabinetNumber);
        Task<Row> GetRowByCabinetNumber(int cabinetNumber, int number);
        Task CreateRow(int cabinetNumber, RowCommand row);
        Task UpdateRow(int cabinetNumber, Row row);
        Task DeleteRow(int cabinetNumber, int number);
    }
}