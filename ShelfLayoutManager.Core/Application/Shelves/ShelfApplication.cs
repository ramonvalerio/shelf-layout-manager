﻿using ShelfLayoutManager.Core.Domain.Cabinets;
using ShelfLayoutManager.Core.Domain.Lanes;
using ShelfLayoutManager.Core.Domain.Rows;
using ShelfLayoutManager.Core.Domain.Shelves;

namespace ShelfLayoutManager.Core.Application.Shelves
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

        public async Task<Shelf> GetShelf()
        {
            var cabinets = await _cabinetRepository.GetAllAsync();

            foreach (var cabinet in cabinets)
            {
                var cabinetRows = await _rowRepository.GetAllFromCabinet(cabinet.Number);

                if (cabinet.Rows is null)
                    continue;

                cabinet.Rows.AddRange(cabinetRows);

                foreach (var row in cabinet.Rows)
                {
                    var rowLanes = await _laneRepository.GetAllByFromCabinetRow(cabinet.Number, row.Number);
                    row.Lanes.AddRange(rowLanes);
                }
            }

            var shelf = new Shelf(cabinets);

            return shelf;
        }
    }
}
