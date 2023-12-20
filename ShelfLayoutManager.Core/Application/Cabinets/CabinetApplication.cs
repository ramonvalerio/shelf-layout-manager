using ShelfLayoutManager.Core.Domain.Cabinets;
using ShelfLayoutManager.Core.Domain.Exceptions;
using ShelfLayoutManager.Core.ValueObjects;

namespace ShelfLayoutManager.Core.Application.Cabinets
{
    public class CabinetApplication : ICabinetApplication
    {
        private readonly ICabinetRepository _cabinetRepository;
        private readonly ICabinetService _cabinetService;

        public CabinetApplication(ICabinetRepository cabinetRepository, ICabinetService cabinetService)
        {
            _cabinetRepository = cabinetRepository;
            _cabinetService = cabinetService;
        }

        public async Task<List<Cabinet>> GetCabinets()
        {
            return await _cabinetRepository.GetAllAsync();
        }

        public async Task<Cabinet> GetCabinetByNumber(int number)
        {
            return await _cabinetRepository.GetByIdAsync(number);
        }

        public async Task<Cabinet> CreateCabinet()
        {
            return await _cabinetService.Create();
        }

        public async Task<Cabinet> UpdateCabinet(int number, UpdateCabinetCommand command)
        {
            if (number < 0)
                throw new NotFoundException("Invalid Cabinet number.");

            var existentCabinetNumber = await _cabinetRepository.GetByIdAsync(number);

            if (existentCabinetNumber == null)
                throw new BusinessException($"Cabinet number {number} not exist.");

            var position = new Position { X = command.X, Y = command.Y, Z = command.Z };
            var size = new Size { Width = command.Width, Height = command.Height, Depth = command.Depth };
            var updatedCabinet = new Cabinet(number, position, size);

            return await _cabinetRepository.Update(updatedCabinet);
        }

        public async Task DeleteCabinetByNumber(int number)
        {
            await _cabinetRepository.Delete(number);
        }
    }
}
