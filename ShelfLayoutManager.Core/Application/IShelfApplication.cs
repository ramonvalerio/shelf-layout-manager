using ShelfLayoutManager.Core.Domain.Cabinets;
using ShelfLayoutManager.Core.Domain.Lanes;
using ShelfLayoutManager.Core.Domain.Rows;

namespace ShelfLayoutManager.Core.Application
{
    public interface IShelfApplication
    {
        Task<List<Cabinet>> GetCabinets();

        Task<List<Row>> GetRows();

        Task<List<Lane>> GetLanes();
    }
}
