namespace ShelfLayoutManager.Core.Domain.Cabinets
{
    public interface ICabinetRepository
    {
        Task<List<Cabinet>> GetAll();
        Task<Cabinet> GetById(int id);
    }
}