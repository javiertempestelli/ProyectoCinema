using ProyectoCinema;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Microsoft.Extensions.Configuration;

namespace ProyectoCinema
{
    public class Program
    {
        static void Main(string[] args)
        {
            using (var context = new CinemaContext())
            {
                Console.WriteLine("Se crean las instancias de los Generos");

                //var gener1  = new Genero() { GeneroId= 1,   Nombre = "Acción" };
                //var gener2  = new Genero() { GeneroId = 2,  Nombre = "Aventuras" };
                //var gener3  = new Genero() { GeneroId = 3,  Nombre = "Ciencia Ficción" };
                //var gener4  = new Genero() { GeneroId = 4,  Nombre = "Comedia" };
                //var gener5  = new Genero() { GeneroId = 5,  Nombre = "Documental" };
                //var gener6  = new Genero() { GeneroId = 6,  Nombre = "Drama" };
                //var gener7  = new Genero() { GeneroId = 7,  Nombre = "Fantasia" };
                //var gener8  = new Genero() { GeneroId = 8,  Nombre = "Musical" };
                //var gener9  = new Genero() { GeneroId = 9,  Nombre = "Suspenso" };
                //var gener10 = new Genero() { GeneroId = 10, Nombre = "Terror" };

                var gener1 = new Genero() { Nombre = "Acción" };
                var gener2 = new Genero() { Nombre = "Aventuras" };
                var gener3 = new Genero() { Nombre = "Ciencia Ficción" };
                var gener4 = new Genero() { Nombre = "Comedia" };
                var gener5 = new Genero() { Nombre = "Documental" };
                var gener6 = new Genero() { Nombre = "Drama" };
                var gener7 = new Genero() { Nombre = "Fantasia" };
                var gener8 = new Genero() { Nombre = "Musical" };
                var gener9 = new Genero() { Nombre = "Suspenso" };
                var gener10 = new Genero() { Nombre = "Terror" };



                Console.WriteLine("Se crean las instancias de las Peliculas");
                var peli01 = new Pelicula() { Titulo = "Mad Max: Furia en el Camino", GeneroId = 1, Poster = "img1.jpg", Sonopsis = "Caos postapocalíptico en busca de libertad", Trailer = "trailer1.mp4" };
                var peli02 = new Pelicula() { Titulo = "John Wick", GeneroId = 1, Poster = "img2.jpg", Sonopsis = "Asesino busca venganza en mundo criminal", Trailer = "trailer2.mp4" };
                var peli03 = new Pelicula() { Titulo = "Indiana Jones y la Última Cruzada", GeneroId = 2, Poster = "img3.jpg", Sonopsis = "Aventura en busca del Santo Grial", Trailer = "trailer3.mp4" };
                var peli04 = new Pelicula() { Titulo = "Piratas del Caribe: La Maldición del Perla Negra", GeneroId = 2, Poster = "img4.jpg", Sonopsis = "Piratas buscan tesoro maldito", Trailer = "trailer4.mp4" };
                var peli05 = new Pelicula() { Titulo = "Blade Runner 2049", GeneroId = 3, Poster = "img5.jpg", Sonopsis = "Detective busca replicante desaparecida", Trailer = "trailer5.mp4" };
                var peli06 = new Pelicula() { Titulo = "Matrix", GeneroId = 3, Poster = "img6.jpg", Sonopsis = "Realidad alterna en mundo virtual", Trailer = "trailer6.mp4" };
                var peli07 = new Pelicula() { Titulo = "El Gran Hotel Budapest", GeneroId = 4, Poster = "img7.jpg", Sonopsis = "Comedia caótica en hotel lujoso", Trailer = "trailer7.mp4" };
                var peli08 = new Pelicula() { Titulo = "Súper Cool", GeneroId = 4, Poster = "img8.jpg", Sonopsis = "Amigos se embarcan en desventuras", Trailer = "trailer8.mp4" };
                var peli09 = new Pelicula() { Titulo = "Blackfish", GeneroId = 5, Poster = "img9.jpg", Sonopsis = "Revelación de maltrato a orcas", Trailer = "trailer9.mp4" };
                var peli10 = new Pelicula() { Titulo = "Marcha de los Pingüinos", GeneroId = 5, Poster = "img10.jpg", Sonopsis = "Viaje de pingüinos antárticos", Trailer = "trailer10.mp4" };
                var peli11 = new Pelicula() { Titulo = "Sueño de Fuga", GeneroId = 6, Poster = "img11.jpg", Sonopsis = "Evasión de prisión cambia vidas", Trailer = "trailer11.mp4" };
                var peli12 = new Pelicula() { Titulo = "Forrest Gump", GeneroId = 6, Poster = "img12.jpg", Sonopsis = "Historia de vida llena de acontecimientos", Trailer = "trailer12.mp4" };
                var peli13 = new Pelicula() { Titulo = "El Laberinto del Fauno", GeneroId = 7, Poster = "img13.jpg", Sonopsis = "Viaje mágico por reino fantástico", Trailer = "trailer13.mp4" };
                var peli14 = new Pelicula() { Titulo = "Stardust", GeneroId = 7, Poster = "img14.jpg", Sonopsis = "Aventuras en busca de estrella mágica", Trailer = "trailer14.mp4" };
                var peli15 = new Pelicula() { Titulo = "Sonrisas y Lágrimas", GeneroId = 8, Poster = "img15.jpg", Sonopsis = "Novicia cambia familia austera", Trailer = "trailer15.mp4" };
                var peli16 = new Pelicula() { Titulo = "Moulin Rouge", GeneroId = 8, Poster = "img16.jpg", Sonopsis = "Bohemia y amor en París", Trailer = "trailer16.mp4" };
                var peli17 = new Pelicula() { Titulo = "El Sexto Sentido", GeneroId = 9, Poster = "img17.jpg", Sonopsis = "Niño ve muertos, busca respuestas", Trailer = "trailer17.mp4" };
                var peli18 = new Pelicula() { Titulo = "Perdida", GeneroId = 9, Poster = "img18.jpg", Sonopsis = "Intriga racial en suburbios estadounidenses", Trailer = "trailer18.mp4" };
                var peli19 = new Pelicula() { Titulo = "El Exorcista", GeneroId = 10, Poster = "img19.jpg", Sonopsis = "Poseída por demonio, exorcismo necesario", Trailer = "trailer19.mp4" };
                var peli20 = new Pelicula() { Titulo = "¡Huye!", GeneroId = 10, Poster = "img20.jpg", Sonopsis = "Lucha por escapar de hechos tenebrosos", Trailer = "trailer20.mp4" };
                // ... Repite el patrón para las demás películas

                Console.WriteLine("Se crean las instancias de las Salas");

                var sala01 = new Sala() { Nombre = "Sala 1", Capacidad = 5 };
                var sala02 = new Sala() { Nombre = "Sala 2", Capacidad = 15 };
                var sala03 = new Sala() { Nombre = "Sala 3", Capacidad = 35 };


                // Verificar si ya existe el género, peliculas y las salas antes de agregarlas


                context.Generos.Add(gener1);
                context.Generos.Add(gener2);
                context.Generos.Add(gener3);
                context.Generos.Add(gener4);
                context.Generos.Add(gener5);
                context.Generos.Add(gener6);
                context.Generos.Add(gener7);
                context.Generos.Add(gener8);
                context.Generos.Add(gener9);
                context.Generos.Add(gener10);
                Console.WriteLine("Se agregaron los Generos");

 //               context.SaveChanges();

                Console.WriteLine("Se guardaron los Generos");
                context.Peliculas.Add(peli01);
                context.Peliculas.Add(peli02);
                context.Peliculas.Add(peli03);
                context.Peliculas.Add(peli04);
                context.Peliculas.Add(peli05);
                context.Peliculas.Add(peli06);
                context.Peliculas.Add(peli07);
                context.Peliculas.Add(peli08);
                context.Peliculas.Add(peli09);
                context.Peliculas.Add(peli10);
                context.Peliculas.Add(peli11);
                context.Peliculas.Add(peli12);
                context.Peliculas.Add(peli13);
                context.Peliculas.Add(peli14);
                context.Peliculas.Add(peli15);
                context.Peliculas.Add(peli16);
                context.Peliculas.Add(peli17);
                context.Peliculas.Add(peli18);
                context.Peliculas.Add(peli19);
                context.Peliculas.Add(peli20);
 //               context.SaveChanges();
                context.Salas.Add(sala01);
                context.Salas.Add(sala02);
                context.Salas.Add(sala03);
                context.SaveChanges();

                while (true)
                {
 //                   Console.Clear(); // Limpiar la consola antes de mostrar el menú

                    Console.WriteLine("╔════════════════════════════════════════╗");
                    Console.WriteLine("║           ¡Bienvenido al Cine!         ║");
                    Console.WriteLine("║                                        ║");
                    Console.WriteLine("║              Menú de Opciones          ║");
                    Console.WriteLine("║                                        ║");
                    Console.WriteLine("║  1. Cargar una nueva 'funcion'         ║");
                    Console.WriteLine("║  2. Ver todas las funciones            ║");
                    Console.WriteLine("║                                        ║");
                    Console.WriteLine("║  Presione 'Q' para salir               ║");
                    Console.WriteLine("╚════════════════════════════════════════╝");
                    Console.Write("Seleccione una opción: ");

                    char option = Char.ToUpper(Console.ReadKey().KeyChar);
                    Console.WriteLine();

                    switch (option)
                    {
                        case '1':
                            CrearNuevaFuncion(context);
                            break;

                        case '2':
                            VerTodasLasFunciones(context);
                            break;

                        default:
                            Console.WriteLine("Opción no válida. Por favor, seleccione una opción válida.");
                            break;
                    }
                }

                static void CrearNuevaFuncion(CinemaContext context)
                {
                    Console.WriteLine("Creación de nueva función:");

                    // Solicitar los datos al usuario
                    Console.Write("Fecha (yyyy-MM-dd): ");
                    if (!DateTime.TryParse(Console.ReadLine(), out DateTime fecha))
                    {
                        Console.WriteLine("Fecha no válida.");

                        Console.WriteLine(fecha.ToString() + "es el cuando");
                        return;
                    }
                    Console.WriteLine(fecha.ToString() + "es el cuando");

                    Console.Write("Hora (HH:mm): ");
                    if (!DateTime.TryParse(Console.ReadLine(), out DateTime hora))
                    {
                        Console.WriteLine("Hora no válida.");

                        
                        return;
                    }
                    Console.WriteLine(hora.ToString() + "es el cuando");
                    Console.Write("Sala Id: ");
                    if (!int.TryParse(Console.ReadLine(), out int salaId))
                    {
                        Console.WriteLine("Sala Id no válido.");
                        return;
                    }
                    Console.WriteLine(salaId.ToString() + "es el donde");
                    Console.Write("Pelicula Id: ");
                    if (!int.TryParse(Console.ReadLine(), out int peliculaId))
                    {
                        Console.WriteLine("Pelicula Id no válido.");
                        return;
                    }
                    Console.WriteLine(peliculaId.ToString() + "es el que");
                    // Verificar si la sala y la película existen
                    var sala = context.Salas.Find(salaId);
                    if (sala == null)
                    {
                        Console.WriteLine("Sala no encontrada.");
                        return;
                    }

                    var pelicula = context.Peliculas.Find(peliculaId);
                    if (pelicula == null)
                    {
                        Console.WriteLine("Pelicula no encontrada.");
                        return;
                    }
                    Console.WriteLine(pelicula.PeliculaId + "es el que");

                    Console.WriteLine("Se verificaron Sala y Pelicula como existentes.");

                    // Crear la nueva función
                    var nuevaFuncion = new Funcion
                    {
                        SalaId = salaId,
                        Sala = sala,
                        Fecha = fecha,
                        Horario = hora,
                        PeliculaId = peliculaId,
                        Pelicula = pelicula
                    };
                    Console.WriteLine("Se creó el objeto NuevaFuncion");
                    context.Funciones.Add(nuevaFuncion);
                    context.SaveChanges();

                    Console.WriteLine("Nueva función creada exitosamente.");
                }



                static void VerTodasLasFunciones(CinemaContext context)
                {
                    Console.WriteLine("Veamos todas las funciones disponibles.");
                    var funciones = context.Funciones.ToList();
                    foreach (var funcion in funciones)
                    {
                        Console.WriteLine(funciones);
                        Console.WriteLine($"FuncionId: {funcion.FuncionId}, Pelicula: {funcion.Pelicula.Titulo},Sala: {funcion.Sala.Nombre}");
                        // Puedes imprimir más detalles de la función según sea necesario
                    }

                    Console.WriteLine("Veamos todas las funciones disponibles.");
                }
            }

        }
    }
}
