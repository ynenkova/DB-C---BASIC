namespace MusicHub.Data
{
    using Microsoft.EntityFrameworkCore;
    using MusicHub.Data.Models;

    public class MusicHubDbContext : DbContext
    {
        public MusicHubDbContext()
        {
        }

        public MusicHubDbContext(DbContextOptions options)
            : base(options)
        {
        }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Performer> Performers { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<Writer> Writers { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<SongPerformer> SongsPerformers { get; set; }
        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            
            builder.Entity<SongPerformer>(sp =>
            {
                sp.HasKey(x => new { x.SongId, x.PerformerId });
                sp.HasOne(x => x.Song)
                    .WithMany(y => y.SongPerformers)
                    .HasForeignKey(x => x.SongId)
                    .OnDelete(DeleteBehavior.Restrict);
                sp.HasOne(x => x.Performer)
                    .WithMany(y => y.PerformerSongs)
                    .HasForeignKey(x => x.PerformerId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
            
        }
    }
}
