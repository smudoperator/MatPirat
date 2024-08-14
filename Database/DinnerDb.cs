using Dinners2.Dtos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Dinners2.Database
{
    public class DinnerDb : DbContext
    {
        public DinnerDb(DbContextOptions<DinnerDb> options) : base(options)
        {
        }

        public DbSet<DinnerDto> Dinners { get; set; }

        // Old setup
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlite("Data Source=dinners.db");
        //}

        // Setup for storing SqLite properly on Cloud Services
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=D:\\home\\site\\wwwroot\\data\\dinners.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var valueComparer = new ValueComparer<List<string>>(
            (c1, c2) => c1.SequenceEqual(c2),
            c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
            c => c.ToList());

            modelBuilder.Entity<DinnerDto>()
                .Property(d => d.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<DinnerDto>()
                .Property(d => d.Ingredients)
                .HasConversion(
                v => string.Join(',', v),
                v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList())
                .Metadata.SetValueComparer(valueComparer);

            modelBuilder.Entity<DinnerDto>()
                .Property(d => d.Tags)
                .HasConversion(
                    v => string.Join(',', v),
                    v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList())
                .Metadata.SetValueComparer(valueComparer);
        }
    }
}
