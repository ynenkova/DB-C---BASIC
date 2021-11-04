using Microsoft.EntityFrameworkCore;
using P03_FootballBetting.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace P03_FootballBetting.Data
{
   public class FootballBettingContext:DbContext
    {
        public FootballBettingContext()
        {

        }
        public FootballBettingContext(DbContextOptions options)
             : base(options)
        {

        }
        public DbSet<Bet> Bets { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<PlayerStatistic> PlayerStatistics { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Town> Towns { get; set; }
        public DbSet<User> Users { get; set; }

        protected override  void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=LAPTOP-EJ1MT1A4;Database=FootballBetting;Integrated Security=True;");
            }
        }
        
        protected override  void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Team>(team =>
            {
                team.HasOne(t => t.PrimaryKitColor)
                .WithMany(c => c.PrimaryKitTeams)
                .HasForeignKey(x => x.PrimaryKitColorId)
                .OnDelete(DeleteBehavior.Restrict);

                team.HasOne(t => t.SecondaryKitColor)
                .WithMany(c => c.SecondaryKitTeams)
                .HasForeignKey(t => t.SecondaryKitColorId)
                .OnDelete(DeleteBehavior.Restrict);

                team.HasOne(t => t.Town)
                .WithMany(town => town.Teams)
                .HasForeignKey(t => t.TownId);
                
            });
            builder.Entity<Town>(town =>
            {
                town.HasOne(t => t.Country).WithMany(c => c.Towns).HasForeignKey(x => x.CountryId);

            });
            builder.Entity<PlayerStatistic>(ps =>
            {
                ps.HasKey(x => new { x.GameId,x.PlayerId });
                ps.HasOne(p => p.Player).WithMany(ps => ps.PlayerStatistics).HasForeignKey(ps => ps.PlayerId).OnDelete(DeleteBehavior.Restrict);
                ps.HasOne(p => p.Game).WithMany(ps => ps.PlayerStatistics).HasForeignKey(ps => ps.GameId).OnDelete(DeleteBehavior.Restrict);
            });
            builder.Entity<Game>(game =>
            {
                game.HasOne(t => t.HomeTeam).WithMany(c => c.HomeGames).HasForeignKey(x => x.HomeTeamId).OnDelete(DeleteBehavior.Restrict);
                game.HasOne(t => t.AwayTeam).WithMany(c => c.AwayGames).HasForeignKey(x => x.AwayTeamId).OnDelete(DeleteBehavior.Restrict);

            });
            builder.Entity<Player>(player =>
            {
                player.HasOne(p => p.Team).WithMany(c => c.Players).HasForeignKey(x => x.TeamId).OnDelete(DeleteBehavior.Restrict);
                player.HasOne(p => p.Position).WithMany(c => c.Players).HasForeignKey(x => x.PositionId).OnDelete(DeleteBehavior.Restrict);

            });
            builder.Entity<Bet>(bet =>
            {
                bet.HasOne(u => u.User).WithMany(bet => bet.Bets).HasForeignKey(u => u.UserId).OnDelete(DeleteBehavior.Restrict);
                bet.HasOne(u => u.Game).WithMany(bet => bet.Bets).HasForeignKey(u => u.GameId).OnDelete(DeleteBehavior.Restrict);

            });
        }
    }
}
