using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Emit;

namespace ProyectoCinema
{
    public class CinemaContext : DbContext
    {
        public DbSet<Genero> Generos { get; set; }
        public DbSet<Pelicula> Peliculas { get; set; }
        public DbSet<Sala> Salas { get; set; }
        public DbSet<Funcion> Funciones { get; set; }  
        public DbSet<Ticket> Tickets { get; set; }

        //public CinemaContext(DbContextOptions<CinemaContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //// Configuraciones de modelos y relaciones
            modelBuilder.Entity<Genero>()
              .HasMany(g => g.Peliculas)
              .WithOne(p => p.Genero)
              .HasForeignKey(p => p.GeneroId);

            //// Relación entre Sala y Funcion (uno a muchos)
            modelBuilder.Entity<Sala>()
                .HasMany(s => s.Funciones)
                .WithOne(f => f.Sala)
                .HasForeignKey(f => f.SalaId);

            //// Relación entre Funcion y Pelicula (muchos a uno)
            modelBuilder.Entity<Funcion>()
                .HasOne(f => f.Pelicula)
                .WithMany(p => p.Funciones)
                .HasForeignKey(f => f.PeliculaId);

            // Relación entre Funcion y Ticket (uno a uno)
            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.Funcion)
                .WithMany(f => f.Tickets)
                .HasForeignKey(t => t.FuncionId);

            // Más configuraciones y relaciones aquí...

            // Carga de datos iniciales

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=CineDB;Trusted_Connection=True;TrustServerCertificate=True");
        }

    }
 }

