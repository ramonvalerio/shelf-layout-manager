using ShelfLayoutManager.Core.Domain.Lanes;

namespace ShelfLayoutManager.Core.Application.Lanes
{
    public interface ILaneService
    {
        Task<Lane> CreateFromCabinetRow(Lane lane);
    }
}