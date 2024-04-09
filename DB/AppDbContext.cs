using Microsoft.EntityFrameworkCore;

namespace Lab9.DB
{
    public class AppDbContext : DbContext
    {

        public DbSet<MusicTrack> Tracks { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseNpgsql("Host=localhost;Port=5432;Database=MusicCollectionDB;Username=postgres;Password=postgres");

    }
}
