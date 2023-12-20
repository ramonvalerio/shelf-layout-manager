namespace ShelfLayoutManager.Core.Domain.Cabinets
{
    public interface ICabinetRepository : IReadBaseRepository<Cabinet>
    {
        Task<Cabinet> Create(Cabinet cabinet);
    }
}