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
        public DbSet<CAGolfClubDB.Models.Booking> Booking { get; set; } = default!;
        public DbSet<CAGolfClubDB.Models.BookingPlayer> BookingPlayer { get; set; } = default!;


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


            // BookingPlayer definition
            modelBuilder.Entity<BookingPlayer>()
                .HasKey(bu => bu.Id);

            modelBuilder.Entity<BookingPlayer>()
                .HasOne(bu => bu.Booking)
                .WithMany(b => b.BookingPlayers)
                .HasForeignKey(bu => bu.BookingId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<BookingPlayer>()
                .HasOne(bu => bu.Player)
                .WithMany(u => u.BookingPlayers)
                .HasForeignKey(bu => bu.PlayerId)
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

            modelBuilder.Entity<BookingPlayer>()
                .Property(bu => bu.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            modelBuilder.Entity<BookingPlayer>()
                .Property(bu => bu.UpdatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");
        }
        


    }
}
