using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SoccerPlayer.DataAccess.EF.Models;

#nullable disable

namespace SoccerPlayer.DataAccess.EF.Context
{
    public partial class SoccerPlayerContext : DbContext
    {
        public SoccerPlayerContext()
        {
        }

        public SoccerPlayerContext(DbContextOptions<SoccerPlayerContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Player> Players { get; set; }
        public virtual DbSet<Team> Teams { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=tcp:skituka.database.windows.net,1433;Initial Catalog=SoccerPlayer;Persist Security Info=False;User ID=skituka;Password=Reussi&bien14;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Player>(entity =>
            {
                entity.Property(e => e.PlayerId).HasColumnName("PlayerID");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Position)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Team)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.TeamNavigation)
                    .WithMany(p => p.Players)
                    .HasForeignKey(d => d.TeamId)
                    .HasConstraintName("FK_Players_Players");
            });

            modelBuilder.Entity<Team>(entity =>
            {
                entity.Property(e => e.TeamBestPlayer)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.TeamCaptain)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.TeamCoach)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.TeamName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TeamStadiumName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
