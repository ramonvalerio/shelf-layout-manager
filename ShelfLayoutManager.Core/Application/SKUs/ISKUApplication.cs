
using ShelfLayoutManager.Core.Domain.SKUs;

namespace ShelfLayoutManager.Core.Application.SKUs
{
    public interface ISKUApplication
    {
        Task<List<SKU>> GetSAllSku();
        Task<SKU> GetSkuByJanCode(int janCode);
    }
}