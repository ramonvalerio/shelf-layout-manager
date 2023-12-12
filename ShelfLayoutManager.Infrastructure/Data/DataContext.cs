using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using ShelfLayoutManager.Core.Domain.Cabinets;
using ShelfLayoutManager.Core.Domain.Lanes;
using ShelfLayoutManager.Core.Domain.Rows;
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
                Database.Migrate();
            }
        }

        public DbSet<Cabinet> Cabinets { get; private set; }
        public DbSet<Row> Rows { get; private set; }
        public DbSet<Lane> Lanes { get; private set; }
        public DbSet<Log> Logs { get; private set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Cabinet>().ToTable("TB_CABINET").HasKey(c => c.Number);
            builder.Entity<Cabinet>().OwnsOne(c => c.Position);
            builder.Entity<Cabinet>().OwnsOne(c => c.Size);

            builder.Entity<Row>().ToTable("TB_ROW").HasKey(c => c.Number);
            builder.Entity<Row>().OwnsOne(c => c.Size);

            builder.Entity<Lane>().ToTable("TB_LANE").HasKey(c => c.Number);
            builder.Entity<Log>().ToTable("TB_LOG");
        }
    }
}