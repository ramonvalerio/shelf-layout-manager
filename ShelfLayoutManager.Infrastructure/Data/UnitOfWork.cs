using ShelfLayoutManager.Core.Domain;

namespace ShelfLayoutManager.Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;

        public UnitOfWork(DataContext context)
        {
            _context = context;
        }

        public async Task<ITransactionScope> BeginTransactionAsync()
        {
            var transaction = await _context.Database.BeginTransactionAsync();
            return new TransactionScope(
                async () =>
                {
                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();
                },
                async (exception) =>
                {
                    await transaction.RollbackAsync();
                }
            );
        }
    }
}
