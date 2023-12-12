using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using ShelfLayoutManager.Core.Domain.Cabinets;
using ShelfLayoutManager.Infrastructure.Identity;
using ShelfLayoutManager.Infrastructure.Logging;

namespace ShelfLayoutManager.Infrastructure.Data
{
    public class DataContext : IdentityDbContext<ApplicationUser>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            if (!Database.GetService<IRelationalDatabaseCreator>().Exists())
            {
                Database.EnsureCreated();
            }
        }

        public DbSet<Cabinet> Cabinets { get; private set; }
        public DbSet<Log> Logs { get; private set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Cabinet>().ToTable("TB_CABINET");
            builder.Entity<Log>().ToTable("TB_LOG");
        }
    }
}