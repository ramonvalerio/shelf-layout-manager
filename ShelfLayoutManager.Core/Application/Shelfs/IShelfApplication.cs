using ShelfLayoutManager.Core.Domain.Cabinets;
using ShelfLayoutManager.Core.Domain.Shelves;

namespace ShelfLayoutManager.Core.Application.Shelfs
{
    public interface IShelfApplication
    {
        Task<Shelf> GetShelf();

        Task<Cabinet> GetCabinetByNumber(int number);
    }
}
