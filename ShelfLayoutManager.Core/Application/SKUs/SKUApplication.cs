using ShelfLayoutManager.Core.Domain.SKUs;

namespace ShelfLayoutManager.Core.Application.SKUs
{
    public class SKUApplication : ISKUApplication
    {
        private readonly ISKURepository _skuRepository;

        public SKUApplication(ISKURepository skuRepository)
        {
            _skuRepository = skuRepository;
        }

        public async Task<List<SKU>> GetSAllSku()
        {
            return await _skuRepository.GetAllAsync();
        }

        public async Task<SKU> GetSkuByJanCode(string janCode)
        {
            return await _skuRepository.GetByIdAsync(janCode);
        }
    }
}