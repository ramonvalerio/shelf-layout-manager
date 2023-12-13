using ShelfLayoutManager.Core.Domain.Skus;
using ShelfLayoutManager.Core.Services;

namespace ShelfLayoutManager.Core.Application.Skus
{
    public class SkuApplication : ISkuApplication
    {
        private readonly ISkuRepository _skuRepository;
        private readonly IJanCodeValidatorService _janCodeValidatorService;

        public SkuApplication(ISkuRepository skuRepository, IJanCodeValidatorService janCodeValidatorService)
        {
            _skuRepository = skuRepository;
            _janCodeValidatorService = janCodeValidatorService;
        }

        public async Task<List<Sku>> GetSAllSku()
        {
            return await _skuRepository.GetAllAsync();
        }

        public async Task<Sku> GetSkuByJanCode(string janCode)
        {
            return await _skuRepository.GetByIdAsync(janCode);
        }

        public async Task<Sku> CreateSku(Sku sku)
        {
            if (!_janCodeValidatorService.IsValidJanCode(sku.JanCode))
                throw new FormatException($"The JAN Code provided is invalid: '{sku.JanCode}'.");

            return await _skuRepository.Create(sku);
        }

        public async Task<Sku> UpdateSku(string janCode, Sku newSku)
        {
            var oldSku = await _skuRepository.GetByIdAsync(janCode);
            oldSku.JanCode = newSku.JanCode;
            oldSku.Name = newSku.Name;
            oldSku.X = newSku.X;
            oldSku.Y = newSku.Y;
            oldSku.Z = newSku.Z;
            oldSku.ImageURL = newSku.ImageURL;
            oldSku.Size = newSku.Size;
            oldSku.TimeStamp = DateTime.Now.Ticks;
            oldSku.Shape = newSku.Shape;

            return await _skuRepository.Update(newSku);
        }

        public async Task DeleteSku(string janCode)
        {
            await _skuRepository.Delete(janCode);
        }
    }
}