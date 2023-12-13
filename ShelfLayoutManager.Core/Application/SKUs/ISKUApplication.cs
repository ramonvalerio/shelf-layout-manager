
using ShelfLayoutManager.Core.Domain.Skus;

namespace ShelfLayoutManager.Core.Application.Skus
{
    public interface ISkuApplication
    {
        Task<List<Sku>> GetSkus();
        Task<Sku> GetSkuByJanCode(string janCode);
        Task<Sku> CreateSku(Sku sku);
        Task<Sku> UpdateSku(string janCode, Sku sku);
        Task DeleteSku(string janCode);
    }
}