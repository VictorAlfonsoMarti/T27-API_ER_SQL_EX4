using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace T27_API_ER_SQL_EX4.Model
{
    public class APIContext : DbContext
    {
        // IMPORTAMOS LAS OPCIONES DE DbContext
        public APIContext(DbContextOptions<APIContext> options) : base(options) { }

        // ATRIBUTOS, GETTERS Y SETTERS
        public virtual DbSet<Equipo> Equipos { get; set; }
        public virtual DbSet<Investigador> Investigadores { get; set; }
        public virtual DbSet<Facultad> Facultades { get; set; }
        public virtual DbSet<Reserva> Reservas { get; set; }

        // DEFINIMOS LOS MEDOLOS DE LA BASE DE DATOS
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Equipo>(equipo =>
            {
                // NOMBRE DE LA TABLA
                equipo.ToTable("Equipos");

                // PROPIEDADES DE COLUMNA
                equipo.Property(e => e.NumSerie)
                    .HasColumnName("NumSerie")
                    .HasMaxLength(4)
                    .IsUnicode(false);
                equipo.Property(e => e.Nombre)
                    .HasColumnName("Nombre")
                    .HasMaxLength(100)
                    .IsUnicode(false);
                equipo.Property(e => e.Facultad)
                    .HasColumnName("Facultad");

                // DEFINICIÓN DE CLAVES
                equipo.HasKey(k => k.NumSerie);

                // RELACIONES Y CLAVES FORÁNEAS
                equipo.HasOne(r => r.Facultades)
                    .WithMany(m => m.Equipos)
                    .HasForeignKey(k => k.Facultad)
                    .HasConstraintName("Facultad_fk");
            });

            modelBuilder.Entity<Investigador>(investigador =>
            {
                // NOMBRE DE LA TABLA
                investigador.ToTable("Investigadores");

                // PROPIEDADES DE COLUMNA
                investigador.Property(e => e.Dni)
                    .HasColumnName("DNI")
                    .HasMaxLength(8)
                    .IsUnicode(false);
                investigador.Property(e => e.NomApels)
                    .HasColumnName("NomApels")
                    .HasMaxLength(255)
                    .IsUnicode(false);
                investigador.Property(e => e.Facultad)
                    .HasColumnName("Facultad");

                // DEFINICIÓN DE CLAVES
                investigador.HasKey(k => k.Dni);

                // RELACIONES Y CLAVES FORÁNEAS
                investigador.HasOne(r => r.Facultades)
                    .WithMany(m => m.Investigadores)
                    .HasForeignKey(k => k.Facultad)
                    .HasConstraintName("Facultad_fk");
            });

            modelBuilder.Entity<Facultad>(facultad =>
            {
                // NOMBRE DE LA TABLA
                facultad.ToTable("Facultad");

                // PROPIEDADES DE COLUMNA
                facultad.Property(e => e.Codigo)
                    .HasColumnName("Codigo");
                facultad.Property(e => e.Nombre)
                    .HasColumnName("Nombre")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                // DEFINICIÓN DE CLAVES
                facultad.HasKey(k => k.Codigo);
            });

            modelBuilder.Entity<Reserva>(reserva =>
            {
                // NOMBRE DE LA TABLA
                reserva.ToTable("Reserva");

                // PROPIEDADES DE COLUMNA
                reserva.Property(e => e.Dni)
                    .HasColumnName("DNI")
                    .HasMaxLength(8)
                    .IsUnicode(false);
                reserva.Property(e => e.NumSerie)
                    .HasColumnName("NumSerie")
                    .HasMaxLength(4)
                    .IsUnicode(false);
                reserva.Property(e => e.Comienzo)
                    .HasColumnName("Comienzo");
                reserva.Property(e => e.Fin)
                    .HasColumnName("Fin");

                // DEFINICIÓN DE CLAVES
                reserva.HasKey(k => new { k.Dni, k.NumSerie });

                // RELACIONES Y CLAVES FORÁNEAS
                reserva.HasOne(r => r.Investigadores)
                    .WithMany(m => m.Reservas)
                    .HasForeignKey(k => k.Dni)
                    .HasConstraintName("Investigadores_fk");
                reserva.HasOne(r => r.Equipos)
                    .WithMany(m => m.Reservas)
                    .HasForeignKey(k => k.NumSerie)
                    .HasConstraintName("NumSerie_fk");
            });
        }
    }
}
