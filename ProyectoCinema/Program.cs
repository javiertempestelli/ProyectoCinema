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
//                    Console.Clear(); // Limpiar la consola antes de mostrar el menú

                    Console.WriteLine("╔══════════════════════════════════════════╗");
                    Console.WriteLine("║           ¡Bienvenido a tu Cine!         ║");
                    Console.WriteLine("║                                          ║");
                    Console.WriteLine("║              Menú de Opciones            ║");
                    Console.WriteLine("║                                          ║");
                    Console.WriteLine("║  1. Cargar una nueva 'funcion'           ║");
                    Console.WriteLine("║  2. Ver todas las funciones              ║");
                    Console.WriteLine("║                                          ║");
                    Console.WriteLine("║  Presione 'Q' para salir                 ║");
                    Console.WriteLine("╚══════════════════════════════════════════╝");
                    Console.Write("Seleccione una opción: ");

                    char option = Char.ToUpper(Console.ReadKey().KeyChar);
                    Console.WriteLine();

                    switch (option)
                    {
                        case '1':
                            Console.WriteLine("Acá vamos a tirar un prompt");
                            break;

                        case '2':
                            Console.WriteLine("aca va el listado con todas las funciones segun dia o pelicula");
                            break;

                        default:
                            Console.WriteLine("Opción no válida. Por favor, seleccione una opción válida.");
                            break;
                    }
                
                }
            }

        }
    }
}




