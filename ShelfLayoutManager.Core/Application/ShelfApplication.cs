using ShelfLayoutManager.Core.Domain.Cabinets;
using ShelfLayoutManager.Core.Domain.Lanes;
using ShelfLayoutManager.Core.Domain.Rows;
using ShelfLayoutManager.Core.Domain.Shelves;

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

        public async Task<Cabinet> GetCabinetByNumber(int number)
        {
            return await _cabinetRepository.GetByIdAsync(number);
        }

        public async Task<Shelf> GetShelf()
        {
            var cabinets = await _cabinetRepository.GetAllAsync();
            var rows = await _rowRepository.GetAllAsync();
            var lanes = await _laneRepository.GetAllAsync();

            foreach (var cabinet in cabinets)
            {
                var cabinetRows = rows.Where(x => x.CabinetId == cabinet.Id).ToList();
                cabinet.Rows.AddRange(cabinetRows);

                foreach (var row in cabinet.Rows)
                {
                    var rowLanes = row.Lanes.Where(x => x.RowId == row.Id).ToList();
                    row.Lanes.AddRange(rowLanes);
                }
            }

            return new Shelf(cabinets);
        }
    }
}
