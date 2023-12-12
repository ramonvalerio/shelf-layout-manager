namespace ShelfLayoutManager.Core.Domain.Lanes
{
    public interface ILaneRepository
    {
        Task<List<Lane>> GetAll();

        Task<Lane> GetById(int id);
    }
}