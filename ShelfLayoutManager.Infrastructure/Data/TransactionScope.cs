using ShelfLayoutManager.Core.Domain;

namespace ShelfLayoutManager.Infrastructure.Data
{
    public class TransactionScope : ITransactionScope
    {
        private readonly Func<Task> _commit;
        private readonly Func<Exception, Task> _rollback;
        private bool _completed;

        public TransactionScope(Func<Task> commit, Func<Exception, Task> rollback)
        {
            _commit = commit;
            _rollback = rollback;
        }

        public async Task CompleteAsync()
        {
            await _commit();
            _completed = true;
        }

        public async void Dispose()
        {
            if (!_completed)
            {
                await _rollback(null);
            }
        }
    }
}