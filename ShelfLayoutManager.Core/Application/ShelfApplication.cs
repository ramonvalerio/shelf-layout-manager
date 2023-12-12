using ShelfLayoutManager.Core.Domain.Cabinets;
using ShelfLayoutManager.Core.Domain.Lanes;
using ShelfLayoutManager.Core.Domain.Rows;

namespace ShelfLayoutManager.Core.Application
{
    public class ShelfApplication : IShelfApplication
    {
        private readonly ICabinetRepository _cabinetRepository;
        private readonly IRowRepository _rowRepository;
        private readonly ILaneRepository _laneRepository;
        
        public ShelfApplication(ICabinetRepository cabinetRepository,
            IRowRepository rowRepository,
            ILaneRepository laneRepository)
        {
            _cabinetRepository = cabinetRepository;
            _rowRepository = rowRepository;
            _laneRepository = laneRepository;
        }

        public async Task<List<Cabinet>> GetCabinets()
        {
            return await _cabinetRepository.GetAll();
        }

        public async Task<List<Row>> GetRows()
        {
            return await _rowRepository.GetAll();
        }

        public async Task<List<Lane>> GetLanes()
        {
            return await _laneRepository.GetAll();
        }
    }
}
