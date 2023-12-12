namespace ShelfLayoutManager.Core.Domain
{
    public interface IReadBaseRepository<TEntity> where TEntity : class
    {
        Task<List<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(int id);
    }
}