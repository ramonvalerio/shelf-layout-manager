using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using ShelfLayoutManager.Core.Domain.Cabinets;
using ShelfLayoutManager.Core.Domain.Lanes;
using ShelfLayoutManager.Core.Domain.Rows;
using ShelfLayoutManager.Core.Domain.SKUs;
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
        public DbSet<SKU> SKUs { get; private set; }
        public DbSet<Log> Logs { get; private set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Cabinet>().ToTable("TB_CABINET").HasKey(c => c.Id);
            builder.Entity<Cabinet>().OwnsOne(c => c.Position);
            builder.Entity<Cabinet>().OwnsOne(c => c.Size);

            builder.Entity<Row>().ToTable("TB_ROW").HasKey(c => c.Id);
            builder.Entity<Row>().OwnsOne(c => c.Size);

            builder.Entity<Lane>().ToTable("TB_LANE").HasKey(c => c.Id);

            builder.Entity<SKU>().ToTable("TB_SKU").HasKey(c => c.JanCode);

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

            var csvService = new CSVService();

        }
    }
}