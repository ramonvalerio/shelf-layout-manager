namespace ShelfLayoutManager.Core.Domain.Rows
{
    public interface IRowRepository : IReadBaseRepository<Row>
    {
        Task<List<Row>> GetAllFromCabinet(int cabinetNumber);
        Task<Row> GetByNumberFromCabinet(int cabinetNumber, int number);
        Task CreateFromCabinet(int cabinetNumber, Row row);
        Task UpdateFromCabinet(int cabinetNumber, Row row);
        Task DeleteByNumberFromCabinet(int cabinetNumber, int number);
    }
}