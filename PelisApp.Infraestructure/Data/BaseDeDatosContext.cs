using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using PelisApp.Domain.Entities;

#nullable disable

namespace PelisApp.Infraestructure.Data
{
    public partial class BaseDeDatosContext : DbContext
    {
        public BaseDeDatosContext()
        {
        }

        public BaseDeDatosContext(DbContextOptions<BaseDeDatosContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Pelicula> Peliculas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Pelicula>(entity =>
            {
                entity.HasKey(e => e.ID)
                    .HasName("PK_Peliculas");

                entity.Property(e => e.ID).ValueGeneratedOnAdd();

                entity.Property(e => e.Director)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FechaPublicacion)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Fecha_Publicacion");

                entity.Property(e => e.Genero)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Rating).HasColumnType("decimal(3, 2)");

                entity.Property(e => e.Titulo)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
