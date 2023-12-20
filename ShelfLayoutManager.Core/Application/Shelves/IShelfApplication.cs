using ShelfLayoutManager.Core.Domain.Shelves;

namespace ShelfLayoutManager.Core.Application.Shelves
{
    public interface IShelfApplication
    {
        Task<Shelf> GetShelf();
        Task<Shelf> GetShelfByCabinetNumber(int cabinetNumber);
    }
}