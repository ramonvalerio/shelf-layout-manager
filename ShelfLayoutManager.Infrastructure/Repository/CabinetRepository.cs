using ShelfLayoutManager.Core.Domain.Cabinets;
using ShelfLayoutManager.Infrastructure.Data;
using ShelfLayoutManager.Infrastructure.Repository;

namespace ShelfLayoutManager.Core.Repository
{
    public class CabinetRepository : ReadBaseRepository<Cabinet>, ICabinetRepository
    {
        public CabinetRepository(DataContext context) : base(context)
        {
        }
    }
}