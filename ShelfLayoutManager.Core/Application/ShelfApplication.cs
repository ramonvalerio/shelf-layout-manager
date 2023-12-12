using ShelfLayoutManager.Core.Domain.Cabinets;

namespace ShelfLayoutManager.Core.Application
{
    public class ShelfApplication : IShelfApplication
    {
        private readonly ICabinetRepository _cabinetRepository;

        public ShelfApplication(ICabinetRepository cabinetRepository)
        {
            _cabinetRepository = cabinetRepository;
        }

        public async Task<List<Cabinet>> GetCabinets()
        {
            return await _cabinetRepository.GetAll();
        }
    }
}
