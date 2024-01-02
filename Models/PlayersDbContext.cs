using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace project1.Models;

public partial class PlayersDbContext : DbContext
{
    public PlayersDbContext()
    {
    }

    public PlayersDbContext(DbContextOptions<PlayersDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Player> Players { get; set; }

    public virtual DbSet<Team> Teams { get; set; }

    public virtual DbSet<Team1> Team1s { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("server=SOUMYA;database=Emp_Dept;trusted_connection=true;TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Player>(entity =>
        {
            entity.HasKey(e => e.PlayerId).HasName("PK__Player__4A4E74C8F072D73C");

            entity.ToTable("Player");

            entity.Property(e => e.PlayerId).ValueGeneratedNever();
            entity.Property(e => e.PlayerName).HasMaxLength(50);
            entity.Property(e => e.PlayerType).HasMaxLength(50);

            entity.HasOne(d => d.PlayerTeamNavigation).WithMany(p => p.Players)
                .HasForeignKey(d => d.PlayerTeam)
                .HasConstraintName("FK__Player__PlayerTe__44FF419A");
        });

        modelBuilder.Entity<Team>(entity =>
        {
            entity.HasKey(e => e.TeamId).HasName("PK__team__123AE799CD21AEBB");

            entity.ToTable("team");

            entity.HasIndex(e => e.TeamName, "UQ__team__4E21CAACE434915B").IsUnique();

            entity.Property(e => e.TeamId).ValueGeneratedNever();
            entity.Property(e => e.TeamName).HasMaxLength(50);
        });

        modelBuilder.Entity<Team1>(entity =>
        {
            entity.HasKey(e => e.TeamId).HasName("PK__Team1__123AE79947E4C62D");

            entity.ToTable("Team1");

            entity.HasIndex(e => e.TeamName, "UQ__Team1__4E21CAACB2942E31").IsUnique();

            entity.Property(e => e.TeamId).ValueGeneratedNever();
            entity.Property(e => e.TeamName).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
