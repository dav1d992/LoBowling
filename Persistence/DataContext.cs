using System;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<BowlingGame> BowlingGames { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Frame> Frames { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Frame>(x => x.HasKey(y =>
                new { y.UserId, y.BowlingGameId, y.FrameNumber }));

            builder.Entity<Frame>()
                .HasOne(x => x.User)
                .WithMany(x => x.Frames)
                .HasForeignKey(x => x.UserId);

            builder.Entity<Frame>()
                .HasOne(x => x.BowlingGame)
                .WithMany(x => x.Frames)
                .HasForeignKey(x => x.BowlingGameId);
        }

    }
}