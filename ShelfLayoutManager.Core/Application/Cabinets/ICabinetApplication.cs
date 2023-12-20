using ShelfLayoutManager.Core.Domain.Cabinets;

namespace ShelfLayoutManager.Core.Application.Cabinets
{
    public interface ICabinetApplication
    {
        Task<List<Cabinet>> GetCabinets();

        Task<Cabinet> GetCabinetByNumber(int number);
        Task<Cabinet> CreateCabinet(CreateCabinetCommand command);
    }
}
