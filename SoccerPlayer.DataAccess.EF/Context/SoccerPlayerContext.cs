using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoccerPlayer.DataAccess.EF.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SoccerPlayer.DataAccess.EF.Context
{
    public partial class SoccerPlayerContext : DbContext
    {
        public SoccerPlayerContext ()
        {

        }

        public SoccerPlayerContext (DbContextOptions <SoccerPlayerContext > options )
            : base (options )
        {

        }

        public virtual DbSet <PlayerModel> PlayerModel { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlayerModel>(entity =>
            {
               entity.HasKey(e => e.PlayerID);

               entity.Property(e => e.PlayerID).HasColumnName("PlayerID");

               entity.Property(e => e.FirstName)
                   .IsRequired()
                   .HasMaxLength(255);

               entity.Property(e => e.LastName)
                   .IsRequired()
                   .HasMaxLength(100);

               entity.Property(e => e.Age)
                   .IsRequired()
                   .HasMaxLength(100);

               entity.Property(e => e.Team)
                   .IsRequired()
                   .HasMaxLength(25);

               entity.Property(e => e.Position)
                   .IsRequired()
                   .HasMaxLength(25);
            });

            OnModelCreatingPartial(modelBuilder);


        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }
}
