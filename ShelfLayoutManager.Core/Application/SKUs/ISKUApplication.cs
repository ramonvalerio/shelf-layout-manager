
using ShelfLayoutManager.Core.Domain.SKUs;

namespace ShelfLayoutManager.Core.Application.SKUs
{
    public interface ISKUApplication
    {
        Task<List<SKU>> GetSAllSku();
        Task<SKU> GetSkuByJanCode(string janCode);

        Task<SKU> CreateSku(SKU sku);

        Task<SKU> UpdateSku(string janCode, SKU sku);

        Task DeleteSku(string janCode);
    }
}