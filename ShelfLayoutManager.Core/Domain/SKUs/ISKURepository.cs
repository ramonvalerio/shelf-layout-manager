namespace ShelfLayoutManager.Core.Domain.Skus
{
    public interface ISkuRepository : IReadBaseRepository<Sku>
    {
        Task<Sku> Create(Sku sku);

        Task<Sku> Update(Sku sku);

        Task Delete(string janCode);
    }
}