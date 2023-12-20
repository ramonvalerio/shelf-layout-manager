using ShelfLayoutManager.Core.Domain.Cabinets;
using ShelfLayoutManager.Core.Domain.Exceptions;
using ShelfLayoutManager.Core.ValueObjects;

namespace ShelfLayoutManager.Core.Application.Cabinets
{
    public class CabinetApplication : ICabinetApplication
    {
        private readonly ICabinetRepository _cabinetRepository;

        public CabinetApplication(ICabinetRepository cabinetRepository)
        {
            _cabinetRepository = cabinetRepository;
        }

        public async Task<List<Cabinet>> GetCabinets()
        {
            return await _cabinetRepository.GetAllAsync();
        }

        public async Task<Cabinet> GetCabinetByNumber(int number)
        {
            return await _cabinetRepository.GetByIdAsync(number);
        }

        public async Task<Cabinet> CreateCabinet(CreateCabinetCommand command)
        {
            if (!command.IsValid())
                throw new NotFoundException("Invalid Cabinet values.");

            var existentCabinetNumber = await _cabinetRepository.GetByIdAsync(command.Number);

            if (existentCabinetNumber != null)
                throw new BusinessException($"Cabinet number {command.Number} already exist.");

            var position = new Position { X = command.X, Y = command.Y, Z = command.Z };
            var size = new Size { Width = command.Width, Height = command.Height, Depth = command.Depth };
            var newCabinet = new Cabinet(command.Number, position, size);

            return await _cabinetRepository.Create(newCabinet);
        }
    }
}
