using ShelfLayoutManager.Infrastructure.Data;

namespace ShelfLayoutManager.Infrastructure.Services
{
    public class DbSeedService
    {
        private readonly DataContext _context;
        private readonly JsonService _jsonService;

        public DbSeedService(DataContext context)
        {
            _context = context;
            _jsonService = new JsonService();
        }

        public void InitializeAsync()
        {
            if (!_context.Cabinets.Any())
            {
                var data = _jsonService.LoadDataFromJson();
                _context.Cabinets.AddRange(data.Cabinets);
                _context.SaveChanges();
            }
        }
    }
}