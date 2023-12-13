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

        public async Task<SKU> CreateSku(SKU sku)
        {
            return await _skuRepository.Create(sku);
        }

        public async Task<SKU> UpdateSku(string janCode, SKU newSku)
        {
            var oldSku = await _skuRepository.GetByIdAsync(janCode);
            oldSku.JanCode = newSku.JanCode;
            oldSku.Name = newSku.Name;
            oldSku.X = newSku.X;
            oldSku.Y = newSku.Y;
            oldSku.Z = newSku.Z;
            oldSku.ImageURL = newSku.ImageURL;
            oldSku.Size = newSku.Size;
            oldSku.TimeStamp = newSku.TimeStamp;
            oldSku.Shape = newSku.Shape;

            return await _skuRepository.Update(newSku);
        }

        public async Task DeleteSku(string janCode)
        {
            await _skuRepository.Delete(janCode);
        }
    }
}