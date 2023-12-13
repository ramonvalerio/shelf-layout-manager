using ShelfLayoutManager.Core.Domain.Cabinets;

namespace ShelfLayoutManager.Core.Application.Shelfs
{
    public interface ICabinetApplication
    {
        Task<List<Cabinet>> GetCabinets();

        Task<Cabinet> GetCabinetByNumber(int number);
    }
}
