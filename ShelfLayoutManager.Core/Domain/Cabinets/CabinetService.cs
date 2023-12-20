
using ShelfLayoutManager.Core.ValueObjects;

namespace ShelfLayoutManager.Core.Domain.Cabinets
{
    public class CabinetService : ICabinetService
    {
        private readonly ICabinetRepository _cabinetRepository;

        public CabinetService(ICabinetRepository cabinetRepository)
        {
            _cabinetRepository = cabinetRepository;
        }

        public async Task<Cabinet> Create()
        {
            var cabinets = await _cabinetRepository.GetAllAsync();
            var cabinet = new Cabinet();

            if (cabinets.Any())
            {
                var lastCabinet = cabinets.LastOrDefault();
                var position = new Position
                {
                    X = lastCabinet.Position.X + 5,
                    Y = lastCabinet.Position.Y + 5,
                    Z = lastCabinet.Position.Z + 5
                };

                var size = new Size
                {
                    Width = lastCabinet.Size.Width + 5,
                    Depth = lastCabinet.Size.Depth + 5,
                    Height = lastCabinet.Size.Height + 5
                };

                cabinet.Position = position;
                cabinet.Size = size;
                cabinet.Number = lastCabinet.Number + 1;
            }
            else
            {
                cabinet.Position.X = 10;
                cabinet.Position.Y = 20;
                cabinet.Position.Z = 0;

                cabinet.Size.Width = 100;
                cabinet.Size.Depth = 50;
                cabinet.Size.Height = 200;
                cabinet.Number = 1;
            }

            return await _cabinetRepository.Create(cabinet);
        }
    }
}