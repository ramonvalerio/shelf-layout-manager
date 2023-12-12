namespace ShelfLayoutManager.Core.Domain.Rows
{
    public interface IRowRepository
    {
        Task<List<Row>> GetAll();
    }
}