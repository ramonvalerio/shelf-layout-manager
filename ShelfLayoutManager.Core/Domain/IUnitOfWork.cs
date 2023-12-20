namespace ShelfLayoutManager.Core.Domain
{
    public interface IUnitOfWork
    {
        Task<ITransactionScope> BeginTransactionAsync();
    }
}
