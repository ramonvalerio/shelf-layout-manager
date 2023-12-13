using ShelfLayoutManager.Infrastructure.Data;

namespace ShelfLayoutManager.Infrastructure.Services
{
    public class DbSeedService
    {
        private readonly DataContext _context;
        private readonly JsonService _jsonService;
        private readonly CSVService _csvService;

        public DbSeedService(DataContext context)
        {
            _context = context;
            _jsonService = new JsonService();
            _csvService = new CSVService();
        }

        public void InitializeAsync()
        {
            var jsonFilePath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "shelf.json");
            var csvFilePath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "sku.csv");

            if (!_context.Cabinets.Any())
            {
                var shelf = _jsonService.LoadDataFromJson(jsonFilePath);
                _context.Cabinets.AddRange(shelf.Cabinets);
                _context.SaveChanges();
            }

            if (!_context.SKUs.Any())
            {
                var skus = _csvService.ParseSkuCsv(csvFilePath);
                _context.SKUs.AddRange(skus);
                _context.SaveChanges();
            }
        }
    }
}