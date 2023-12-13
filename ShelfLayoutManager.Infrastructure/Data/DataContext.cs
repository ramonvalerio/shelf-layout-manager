using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using ShelfLayoutManager.Core.Domain.Cabinets;
using ShelfLayoutManager.Core.Domain.Lanes;
using ShelfLayoutManager.Core.Domain.Rows;
using ShelfLayoutManager.Core.Domain.Skus;
using ShelfLayoutManager.Infrastructure.Identity;
using ShelfLayoutManager.Infrastructure.Logging;
using ShelfLayoutManager.Infrastructure.Services;

namespace ShelfLayoutManager.Infrastructure.Data
{
    public class DataContext : IdentityDbContext<ApplicationUser>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            CreateDatabaseIfNotExists();
        }

        public DbSet<Cabinet> Cabinets { get; private set; }
        public DbSet<Row> Rows { get; private set; }
        public DbSet<Lane> Lanes { get; private set; }
        public DbSet<Sku> Skus { get; private set; }
        public DbSet<Log> Logs { get; private set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Cabinet>().ToTable("TB_CABINET").HasKey(x => x.Number);
            builder.Entity<Cabinet>().ToTable("TB_CABINET").Property(x => x.Number).ValueGeneratedNever();
            builder.Entity<Cabinet>().OwnsOne(x => x.Position);
            builder.Entity<Cabinet>().OwnsOne(x => x.Size);

            builder.Entity<Row>().ToTable("TB_ROW").HasKey(x => new { x.Number, x.CabinetNumber });
            builder.Entity<Row>().OwnsOne(x => x.Size);

            builder.Entity<Lane>().ToTable("TB_LANE").HasKey(x => new { x.Number, x.RowNumber, x.RowCabinetNumber });

            builder.Entity<Sku>().ToTable("TB_SKU").HasKey(x => x.JanCode);

            builder.Entity<Log>().ToTable("TB_LOG");
        }

        public void CreateDatabaseIfNotExists()
        {
            try
            {
                if (!Database.GetService<IRelationalDatabaseCreator>().Exists())
                {
                    Database.EnsureCreated();
                    Database.Migrate();
                    Seed();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Database Server not found.", ex);
            }
        }

        public void Seed()
        {
            var dbSeedService = new DbSeedService(this);
            dbSeedService.InitializeAsync();
        }
    }
}