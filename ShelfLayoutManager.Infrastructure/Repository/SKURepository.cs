using ShelfLayoutManager.Core.Domain.Skus;
using ShelfLayoutManager.Infrastructure.Data;

namespace ShelfLayoutManager.Infrastructure.Repository
{
    public class SkuRepository : ReadBaseRepository<Sku>, ISkuRepository
    {
        private readonly DataContext _context;

        public SkuRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Sku> Create(Sku sku)
        {
            try
            {
                _context.Skus.Add(sku);
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
                _context.Skus.Update(sku);
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
                var sku = await _context.Skus.FindAsync(janCode);

                if (sku == null)
                    throw new KeyNotFoundException("Sku not found.");

                _context.Skus.Remove(sku);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}