using EntityFramework.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace EntityFramework.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // DbSet'ler
        public DbSet<Ogrenci> Ogrenciler { get; set; }
        public DbSet<Ogretmen> Ogretmenler { get; set; }
        public DbSet<Kurs> Kurslar { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // DateOnly için PostgreSQL mapping
            modelBuilder.Entity<Ogretmen>()
                .Property(o => o.BaslamaTarihi)
                .HasColumnType("date");

            base.OnModelCreating(modelBuilder);
        }


    }
}

