using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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


            // define timestamp
            modelBuilder.Entity<Player>()
                    .Property(u => u.CreatedAt)
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

            modelBuilder.Entity<Player>()
                .Property(u => u.UpdatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");
        }


    }
}
