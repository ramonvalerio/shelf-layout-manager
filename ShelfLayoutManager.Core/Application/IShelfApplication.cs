using ShelfLayoutManager.Core.Domain.Cabinets;

namespace ShelfLayoutManager.Core.Application
{
    public interface IShelfApplication
    {
        Task<List<Cabinet>> GetCabinets();

        Task<Cabinet> GetCabinetByNumber(int number);
    }
}
