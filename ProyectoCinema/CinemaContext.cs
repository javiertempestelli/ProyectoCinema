using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCinema
{
    public class CinemaContext : DbContext
    {
        public DbSet<Genero> Generos { get; set; }
        public DbSet<Pelicula> Peliculas { get; set; }
        public DbSet<Sala> Salas { get; set; }
        public DbSet<Funcion> Funciones { get; set; }  
        public DbSet<Ticket> Tickets { get; set; }

        public CinemaContext(DbContextOptions<CinemaContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuraciones de modelos y relaciones
            modelBuilder.Entity<Genero>()
              .HasMany(g => g.Peliculas)
              .WithOne(p => p.Genero)
              .HasForeignKey(p => p.GeneroId);

            // Relación entre Sala y Funcion (uno a muchos)
            modelBuilder.Entity<Sala>()
                .HasMany(s => s.Funciones)
                .WithOne(f => f.Sala)
                .HasForeignKey(f => f.Sala);

            // Relación entre Funcion y Pelicula (muchos a uno)
            modelBuilder.Entity<Funcion>()
                .HasOne(f => f.Pelicula)
                .WithMany(p => p.Funciones)
                .HasForeignKey(f => f.Pelicula);

            // Relación entre Funcion y Ticket (uno a uno)
            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.Funcion)
                .WithMany(f => f.Tickets)
                .HasForeignKey(t => t.Funcion);

            // Más configuraciones y relaciones aquí...

            // Carga de datos iniciales
            LoadData(modelBuilder);
            SaveChanges();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=CineDB;Trusted_Connection=True;TrustServerCertificate=True");
        }



        // Método para cargar datos iniciales
        private void LoadData(ModelBuilder modelBuilder)
        {
            // Carga de datos de ejemplo para Salas
            modelBuilder.Entity<Sala>().HasData(
                new Sala { SalaId = 1, Nombre = "Sala 1", Capacidad = 5 },
                new Sala { SalaId = 2, Nombre = "Sala 2", Capacidad = 15 },
                new Sala { SalaId = 3, Nombre = "Sala 2", Capacidad = 35 }
                // Agrega más salas aquí...
            );

            //// Carga de datos de generos

            //modelBuilder.Entity<Genero>().HasData(
            //    new Genero { GeneroId = 1, Nombre = "Acción" },
            //    new Genero { GeneroId = 2, Nombre = "Aventuras" },
            //    new Genero { GeneroId = 3, Nombre = "Ciencia Ficcion" },
            //    new Genero { GeneroId = 4, Nombre = "Comedia" },
            //    new Genero { GeneroId = 5, Nombre = "Documental" },
            //    new Genero { GeneroId = 6, Nombre = "Drama" },
            //    new Genero { GeneroId = 7, Nombre = "Fantasia" },
            //    new Genero { GeneroId = 8, Nombre = "Musical" },
            //    new Genero { GeneroId = 9, Nombre = "Suspenso" },
            //    new Genero { GeneroId = 10, Nombre = "Terror" }
            //// Agrega más géneros aquí...
            //);

            //Cargar las peliculas de la cartelera

            //modelBuilder.Entity<Pelicula>().HasData(
            //    new Pelicula { PeliculaId = 1,  Titulo = "	Mad Max: Furia en el Camino	"   , GeneroId = 1, Sonopsis = "	Caos postapocalíptico en busca de libertad.	", Poster = "	https://m.media-amazon.com/images/M/MV5BYzg1N2E1M2YtYTA4Ny00NDY2LWI5ZDEtYjg3YWNmZWRmZmJhXkEyXkFqcGdeQXVyMTYzMDM0NTU@._V1_FMjpg_UX1200_.jpg	", Trailer = "	https://youtu.be/hEJnMQG9ev8?si=o4s7L-Mt6N3wkssF	" },
            //    new Pelicula { PeliculaId = 2,  Titulo = "	John Wick	"                   , GeneroId = 1, Sonopsis = "	Asesino busca venganza en mundo criminal.	", Poster = "	https://m.media-amazon.com/images/M/MV5BYzg1N2E1M2YtYTA4Ny00NDY2LWI5ZDEtYjg3YWNmZWRmZmJhXkEyXkFqcGdeQXVyMTYzMDM0NTU@._V1_FMjpg_UX1200_.jpg	", Trailer = "	https://youtu.be/hEJnMQG9ev8?si=o4s7L-Mt6N3wkssF	" },
            //    new Pelicula { PeliculaId = 3,  Titulo = "	Indiana Jones y la Última Cruzada	", GeneroId = 2, Sonopsis = "	Aventura en busca del Santo Grial.	", Poster = "	https://m.media-amazon.com/images/M/MV5BYzg1N2E1M2YtYTA4Ny00NDY2LWI5ZDEtYjg3YWNmZWRmZmJhXkEyXkFqcGdeQXVyMTYzMDM0NTU@._V1_FMjpg_UX1200_.jpg	", Trailer = "	https://youtu.be/hEJnMQG9ev8?si=o4s7L-Mt6N3wkssF	" },
            //    new Pelicula { PeliculaId = 4,  Titulo = "	Piratas del Caribe"             , GeneroId = 2, Sonopsis = "	Piratas buscan tesoro maldito.	", Poster = "	https://m.media-amazon.com/images/M/MV5BYzg1N2E1M2YtYTA4Ny00NDY2LWI5ZDEtYjg3YWNmZWRmZmJhXkEyXkFqcGdeQXVyMTYzMDM0NTU@._V1_FMjpg_UX1200_.jpg	", Trailer = "	https://youtu.be/hEJnMQG9ev8?si=o4s7L-Mt6N3wkssF	" },
            //    new Pelicula { PeliculaId = 5,  Titulo = "	Blade Runner 2049	", GeneroId = 3, Sonopsis = "	Detective busca replicante desaparecida.	", Poster = "	https://m.media-amazon.com/images/M/MV5BYzg1N2E1M2YtYTA4Ny00NDY2LWI5ZDEtYjg3YWNmZWRmZmJhXkEyXkFqcGdeQXVyMTYzMDM0NTU@._V1_FMjpg_UX1200_.jpg	", Trailer = "	https://youtu.be/hEJnMQG9ev8?si=o4s7L-Mt6N3wkssF	" },
            //    new Pelicula { PeliculaId = 6,  Titulo = "	Matrix	", GeneroId = 3, Sonopsis = "	Realidad alterna en mundo virtual.	", Poster = "	https://m.media-amazon.com/images/M/MV5BYzg1N2E1M2YtYTA4Ny00NDY2LWI5ZDEtYjg3YWNmZWRmZmJhXkEyXkFqcGdeQXVyMTYzMDM0NTU@._V1_FMjpg_UX1200_.jpg	", Trailer = "	https://youtu.be/hEJnMQG9ev8?si=o4s7L-Mt6N3wkssF	" },
            //    new Pelicula { PeliculaId = 7,  Titulo = "	El Gran Hotel Budapest	", GeneroId = 4, Sonopsis = "	Cazarrecompensas lucha contra máquinas.	", Poster = "	https://m.media-amazon.com/images/M/MV5BYzg1N2E1M2YtYTA4Ny00NDY2LWI5ZDEtYjg3YWNmZWRmZmJhXkEyXkFqcGdeQXVyMTYzMDM0NTU@._V1_FMjpg_UX1200_.jpg	", Trailer = "	https://youtu.be/hEJnMQG9ev8?si=o4s7L-Mt6N3wkssF	" },
            //    new Pelicula { PeliculaId = 8,  Titulo = "	Súper Cool	", GeneroId = 4, Sonopsis = "	Conspiración en sueños compartidos.	", Poster = "	https://m.media-amazon.com/images/M/MV5BYzg1N2E1M2YtYTA4Ny00NDY2LWI5ZDEtYjg3YWNmZWRmZmJhXkEyXkFqcGdeQXVyMTYzMDM0NTU@._V1_FMjpg_UX1200_.jpg	", Trailer = "	https://youtu.be/hEJnMQG9ev8?si=o4s7L-Mt6N3wkssF	" },
            //    new Pelicula { PeliculaId = 9,  Titulo = "	Blackfish	", GeneroId = 5, Sonopsis = "	Comedia caótica en hotel lujoso.	", Poster = "	https://m.media-amazon.com/images/M/MV5BYzg1N2E1M2YtYTA4Ny00NDY2LWI5ZDEtYjg3YWNmZWRmZmJhXkEyXkFqcGdeQXVyMTYzMDM0NTU@._V1_FMjpg_UX1200_.jpg	", Trailer = "	https://youtu.be/hEJnMQG9ev8?si=o4s7L-Mt6N3wkssF	" },
            //    new Pelicula { PeliculaId = 10, Titulo = "	Marcha de los Pingüinos	", GeneroId = 5, Sonopsis = "	Amigos se embarcan en desventuras.	", Poster = "	https://m.media-amazon.com/images/M/MV5BYzg1N2E1M2YtYTA4Ny00NDY2LWI5ZDEtYjg3YWNmZWRmZmJhXkEyXkFqcGdeQXVyMTYzMDM0NTU@._V1_FMjpg_UX1200_.jpg	", Trailer = "	https://youtu.be/hEJnMQG9ev8?si=o4s7L-Mt6N3wkssF	" },
            //    new Pelicula { PeliculaId = 11, Titulo = "	Sueño de Fuga	", GeneroId = 6, Sonopsis = "	Revelación de maltrato a orcas.	", Poster = "	https://m.media-amazon.com/images/M/MV5BYzg1N2E1M2YtYTA4Ny00NDY2LWI5ZDEtYjg3YWNmZWRmZmJhXkEyXkFqcGdeQXVyMTYzMDM0NTU@._V1_FMjpg_UX1200_.jpg	", Trailer = "	https://youtu.be/hEJnMQG9ev8?si=o4s7L-Mt6N3wkssF	" },
            //    new Pelicula { PeliculaId = 12, Titulo = "	Forrest Gump	", GeneroId = 6, Sonopsis = "	Viaje de pingüinos antárticos.	", Poster = "	https://m.media-amazon.com/images/M/MV5BYzg1N2E1M2YtYTA4Ny00NDY2LWI5ZDEtYjg3YWNmZWRmZmJhXkEyXkFqcGdeQXVyMTYzMDM0NTU@._V1_FMjpg_UX1200_.jpg	", Trailer = "	https://youtu.be/hEJnMQG9ev8?si=o4s7L-Mt6N3wkssF	" },
            //    new Pelicula { PeliculaId = 13, Titulo = "	El Laberinto del Fauno	", GeneroId = 7, Sonopsis = "	Evasión de prisión cambia vidas.	", Poster = "	https://m.media-amazon.com/images/M/MV5BYzg1N2E1M2YtYTA4Ny00NDY2LWI5ZDEtYjg3YWNmZWRmZmJhXkEyXkFqcGdeQXVyMTYzMDM0NTU@._V1_FMjpg_UX1200_.jpg	", Trailer = "	https://youtu.be/hEJnMQG9ev8?si=o4s7L-Mt6N3wkssF	" },
            //    new Pelicula { PeliculaId = 14, Titulo = "	Stardust	", GeneroId = 7, Sonopsis = "	Historia de vida llena de acontecimientos.	", Poster = "	https://m.media-amazon.com/images/M/MV5BYzg1N2E1M2YtYTA4Ny00NDY2LWI5ZDEtYjg3YWNmZWRmZmJhXkEyXkFqcGdeQXVyMTYzMDM0NTU@._V1_FMjpg_UX1200_.jpg	", Trailer = "	https://youtu.be/hEJnMQG9ev8?si=o4s7L-Mt6N3wkssF	" },
            //    new Pelicula { PeliculaId = 15, Titulo = "	Sonrisas y Lágrimas	", GeneroId = 8, Sonopsis = "	Viaje mágico por reino fantástico.	", Poster = "	https://m.media-amazon.com/images/M/MV5BYzg1N2E1M2YtYTA4Ny00NDY2LWI5ZDEtYjg3YWNmZWRmZmJhXkEyXkFqcGdeQXVyMTYzMDM0NTU@._V1_FMjpg_UX1200_.jpg	", Trailer = "	https://youtu.be/hEJnMQG9ev8?si=o4s7L-Mt6N3wkssF	" },
            //    new Pelicula { PeliculaId = 16, Titulo = "	Moulin Rouge	", GeneroId = 8, Sonopsis = "	Aventuras en busca de estrella mágica.	", Poster = "	https://m.media-amazon.com/images/M/MV5BYzg1N2E1M2YtYTA4Ny00NDY2LWI5ZDEtYjg3YWNmZWRmZmJhXkEyXkFqcGdeQXVyMTYzMDM0NTU@._V1_FMjpg_UX1200_.jpg	", Trailer = "	https://youtu.be/hEJnMQG9ev8?si=o4s7L-Mt6N3wkssF	" },
            //    new Pelicula { PeliculaId = 17, Titulo = "	El Sexto Sentido	", GeneroId = 9, Sonopsis = "	Novicia cambia familia austera.	", Poster = "	https://m.media-amazon.com/images/M/MV5BYzg1N2E1M2YtYTA4Ny00NDY2LWI5ZDEtYjg3YWNmZWRmZmJhXkEyXkFqcGdeQXVyMTYzMDM0NTU@._V1_FMjpg_UX1200_.jpg	", Trailer = "	https://youtu.be/hEJnMQG9ev8?si=o4s7L-Mt6N3wkssF	" },
            //    new Pelicula { PeliculaId = 18, Titulo = "	Perdida	", GeneroId = 9, Sonopsis = "	Bohemia y amor en París.	", Poster = "	https://m.media-amazon.com/images/M/MV5BYzg1N2E1M2YtYTA4Ny00NDY2LWI5ZDEtYjg3YWNmZWRmZmJhXkEyXkFqcGdeQXVyMTYzMDM0NTU@._V1_FMjpg_UX1200_.jpg	", Trailer = "	https://youtu.be/hEJnMQG9ev8?si=o4s7L-Mt6N3wkssF	" },
            //    new Pelicula { PeliculaId = 19, Titulo = "	El Exorcista	", GeneroId = 10, Sonopsis = "	Niño ve muertos, busca respuestas.	", Poster = "	https://m.media-amazon.com/images/M/MV5BYzg1N2E1M2YtYTA4Ny00NDY2LWI5ZDEtYjg3YWNmZWRmZmJhXkEyXkFqcGdeQXVyMTYzMDM0NTU@._V1_FMjpg_UX1200_.jpg	", Trailer = "	https://youtu.be/hEJnMQG9ev8?si=o4s7L-Mt6N3wkssF	" },
            //    new Pelicula { PeliculaId = 20, Titulo = "	¡Huye!	", GeneroId = 10, Sonopsis = "	Búsqueda del enigma y horror.	", Poster = "	https://m.media-amazon.com/images/M/MV5BYzg1N2E1M2YtYTA4Ny00NDY2LWI5ZDEtYjg3YWNmZWRmZmJhXkEyXkFqcGdeQXVyMTYzMDM0NTU@._V1_FMjpg_UX1200_.jpg	", Trailer = "	https://youtu.be/hEJnMQG9ev8?si=o4s7L-Mt6N3wkssF	" }

            //// Agrega más películas aquí...
            //);

            // Más datos de ejemplo aquí...

        }
    }
}
