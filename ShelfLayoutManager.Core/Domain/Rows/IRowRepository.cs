namespace ShelfLayoutManager.Core.Domain.Rows
{
    public interface IRowRepository
    {
        Task<List<Row>> GetAll();

        Task<Row> GetById(int id);
    }
}