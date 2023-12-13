using ShelfLayoutManager.Core.Domain.Skus;
using ShelfLayoutManager.Infrastructure.Data;

namespace ShelfLayoutManager.Infrastructure.Repository
{
    public class SKURepository : ReadBaseRepository<Sku>, ISkuRepository
    {
        private readonly DataContext _context;

        public SKURepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Sku> Create(Sku sku)
        {
            try
            {
                _context.SKUs.Add(sku);
                await _context.SaveChangesAsync();
                return sku;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<Sku> Update(Sku sku)
        {
            try
            {
                _context.SKUs.Update(sku);
                await _context.SaveChangesAsync();
                return sku;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task Delete(string janCode)
        {
            try
            {
                var sku = await _context.SKUs.FindAsync(janCode);

                if (sku == null)
                    throw new KeyNotFoundException("SKU not found.");

                _context.SKUs.Remove(sku);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}