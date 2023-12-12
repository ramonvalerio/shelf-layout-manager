using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShelfLayoutManager.Infrastructure.Identity;
using ShelfLayoutManager.Infrastructure.Logging;

namespace ShelfLayoutManager.Infrastructure.Data
{
    public class DataContext : IdentityDbContext<ApplicationUser>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Log> Logs { get; private set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Log>().ToTable("TB_LOGS");
        }
    }
}