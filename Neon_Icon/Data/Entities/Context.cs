﻿using System;
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

        public virtual DbSet<Preferences> Preferences { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Weather> Weather { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=pizzaboxserver.database.windows.net;Database=NeonIconsDb;user id=pizzapizza;Password=Pizza123;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

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

                entity.Property(e => e.Location).HasColumnName("location");

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasMaxLength(50);

                entity.Property(e => e.Username)
                    .HasColumnName("username")
                    .HasMaxLength(50);
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
