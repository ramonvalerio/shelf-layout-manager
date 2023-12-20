namespace ShelfLayoutManager.Core.Domain
{
    public interface ITransactionScope : IDisposable
    {
        Task CompleteAsync();
    }
}