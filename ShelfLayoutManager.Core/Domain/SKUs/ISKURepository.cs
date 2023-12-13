namespace ShelfLayoutManager.Core.Domain.SKUs
{
    public interface ISKURepository : IReadBaseRepository<SKU>
    {
        Task<SKU> Create(SKU sku);

        Task<SKU> Update(SKU sku);

        Task Delete(string janCode);
    }
}