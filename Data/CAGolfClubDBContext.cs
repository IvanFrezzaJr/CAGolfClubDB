using Microsoft.EntityFrameworkCore;
using CAGolfClubDB.Models;

namespace CAGolfClubDB.Data
{
    public class CAGolfClubDBContext : DbContext
    {
        public CAGolfClubDBContext(DbContextOptions<CAGolfClubDBContext> options)
            : base(options)
        {
        }

        public DbSet<CAGolfClubDB.Models.Player> Player { get; set; } = default!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // User definition
            modelBuilder.Entity<Player>()
                .HasKey(u => u.Id);

            // Booking definition
            modelBuilder.Entity<Booking>()
                .HasKey(b => b.Id);

            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Player)
                .WithMany(u => u.Bookings)
                .HasForeignKey(b => b.PlayerId)
                .OnDelete(DeleteBehavior.Restrict);


            // define timestamp
            modelBuilder.Entity<Player>()
                    .Property(u => u.CreatedAt)
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

            modelBuilder.Entity<Player>()
                .Property(u => u.UpdatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");


            modelBuilder.Entity<Booking>()
                .Property(b => b.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            modelBuilder.Entity<Booking>()
                .Property(b => b.UpdatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");
        }
        public DbSet<CAGolfClubDB.Models.Booking> Booking { get; set; } = default!;


    }
}
