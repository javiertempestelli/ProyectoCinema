using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.Reflection;

namespace ProyectoCinema
{
    public class Program
    {
        static void Main(string[] args)
        {
            using (var context = new CinemaContext())
            {
                while (true)
                {
                    Console.Clear(); // Limpiar la consola antes de mostrar el menú

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
                            Console.WriteLine("Acá vamos a tirar un prompt");
                            break;

                        case '2':
                            Console.WriteLine("aca va el listado con todas " +
                                                "las dunciones segun dia o pelicula");
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



            }

        }
    }
}




