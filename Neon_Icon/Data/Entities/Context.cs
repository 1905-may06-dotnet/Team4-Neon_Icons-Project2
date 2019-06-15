using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Data.Entities
{
    public partial class Context : DbContext
    {
        public Context()
        {
        }

        public Context(DbContextOptions<DbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Locations> Locations { get; set; }
        public virtual DbSet<Preferences> Preferences { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Weather> Weather { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(DbConnection.Connection);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<Locations>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Location)
                    .HasColumnName("location")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Preferences>((Action<Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Preferences>>)((Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Preferences> entity) =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property((System.Linq.Expressions.Expression<Func<Preferences, string>>)(e => (string)e.Genre)).HasColumnName("genre_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.WeatherId).HasColumnName("weather_id");

               

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Preferences)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Preferenc__user___534D60F1");

                entity.HasOne(d => d.Weather)
                    .WithMany(p => p.Preferences)
                    .HasForeignKey(d => d.WeatherId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Preferenc__weath__5441852A");
            }));

            modelBuilder.Entity<Users>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.LocationId).HasColumnName("location_id");

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasMaxLength(50);

                entity.Property(e => e.Username)
                    .HasColumnName("username")
                    .HasMaxLength(50);

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.LocationId)
                    .HasConstraintName("FK__Users__location___4BAC3F29");
            });

            modelBuilder.Entity<Weather>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DefaultGenre).HasColumnName("default_genre");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(50);

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasMaxLength(50);

                
            });
        }
    }
}
