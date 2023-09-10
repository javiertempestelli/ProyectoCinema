using Microsoft.Extensions.Configuration;

namespace ProyectoCinema
{
    public class Program
    {
        static void Main(string[] args)
        {

            var context = new CinemaContext();
            var funcionService = new FuncionService(context);
            {
                while (true)
                {
                    Console.Clear(); // Limpiar la consola antes de mostrar el menú

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
                        case '2':


                            // El usuario seleccionó "2", así que listamos todas las funciones
                            var funciones = funcionService.GetAllFunciones();

                            if (funciones.Any())
                            {
                                foreach (var funcion in funciones)
                                {
                                    Console.WriteLine("--------------------------------------------");
                                    Console.WriteLine($"Funcion N°: {funcion.FuncionId}, Fecha: {funcion.Fecha.ToString("yyyy-MM-dd")}, Hora: {funcion.Horario.ToString("HH:mm:ss")}");
                                    string nombredelasala = funcionService.GetSalaNombreById(funcion.SalaId);
                                    string nombredelapelicula = funcionService.GetPeliculaTituloById(funcion.PeliculaId);
                                    Console.WriteLine($"{nombredelasala}, Película: {nombredelapelicula}");
                                    Console.WriteLine("--------------------------------------------");
                                }
                            }
                            else
                            {
                                Console.WriteLine("No hay funciones disponibles.");
                                Thread.Sleep(2000); // Espera 2 segundos
                            }

                            Console.WriteLine("Presione cualquier tecla para volver a empezar...");
                            Console.ReadKey();
                            Console.Clear();
                            break;

                        case '1':
                            // Registrar nueva función
                            var nuevaFuncion = new Funcion();

                            Console.Write("Fecha (YYYY-MM-DD): ");
                            DateTime fecha;
                            while (!DateTime.TryParse(Console.ReadLine(), out fecha))
                            {
                                Console.WriteLine("Fecha no válida. Ingrese una fecha en el formato YYYY-MM-DD.");
                                Console.Write("Fecha (YYYY-MM-DD): ");
                            }
                            nuevaFuncion.Fecha = fecha;

                            Console.Write("Horario (HH:mm:ss): ");
                            DateTime horario;
                            while (!DateTime.TryParse(Console.ReadLine(), out horario))
                            {
                                Console.WriteLine("Horario no válido. Ingrese un horario en el formato HH:mm:ss.");
                                Console.Write("Horario (HH:mm:ss): ");
                            }
                            nuevaFuncion.Horario = horario;

                            // Obtener y mostrar una lista de películas disponibles
                            var peliculas = funcionService.GetAllPeliculas();
                            Console.WriteLine("Peliculas disponibles:");
                            foreach (var pelicula in peliculas)
                            {
                                Console.WriteLine($"ID: {pelicula.PeliculaId}, Título: {pelicula.Titulo}");
                            }

                            int peliculaId;
                            while (true)
                            {
                                Console.Write("Seleccione la película (ID): ");
                                if (int.TryParse(Console.ReadLine(), out peliculaId))
                                {
                                    if (peliculas.Any(p => p.PeliculaId == peliculaId))
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("ID de película no válido. Seleccione un ID válido.");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("ID de película no válido. Ingrese un número.");
                                }
                            }
                            nuevaFuncion.PeliculaId = peliculaId;

                            // Obtener y mostrar una lista de salas disponibles
                            var salas = funcionService.GetAllSalas();
                            Console.WriteLine("Salas disponibles:");
                            foreach (var sala in salas)
                            {
                                Console.WriteLine($"ID: {sala.SalaId}, Nombre: {sala.Nombre}");
                            }

                            int salaId;
                            while (true)
                            {
                                Console.Write("Seleccione la sala (ID): ");
                                if (int.TryParse(Console.ReadLine(), out salaId))
                                {
                                    if (salas.Any(s => s.SalaId == salaId))
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("ID de sala no válido. Seleccione un ID válido.");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("ID de sala no válido. Ingrese un número.");
                                }
                            }
                            nuevaFuncion.SalaId = salaId;
                            Console.WriteLine();
                            Console.WriteLine("--------------------------------------------");
                            Console.WriteLine("Resumen de la nueva función:");
                            Console.WriteLine($"Fecha: {nuevaFuncion.Fecha.ToString("yyyy-MM-dd")}, Horario: {nuevaFuncion.Horario.ToString("HH:mm:ss")}");
                            string peliculaTitulo = funcionService.GetPeliculaTituloById(nuevaFuncion.PeliculaId);
                            string salaNombre= funcionService.GetSalaNombreById(nuevaFuncion.SalaId);
                            Console.WriteLine($"Película: {peliculaTitulo}, Sala: {nuevaFuncion.SalaId}");
                            Console.WriteLine("--------------------------------------------");

                            char confirmacion;

                            do
                            {
                                Console.Write("¿Desea confirmar la creación de la nueva función? (S/N): ");
                                confirmacion = Char.ToUpper(Console.ReadKey().KeyChar);
                                Console.WriteLine();

                                if (confirmacion == 'S')
                                {
                                    // Llama al método para crear la nueva función
                                    funcionService.CreateFuncion(nuevaFuncion);
                                    Console.WriteLine("Nueva función registrada con éxito.");
                                    Console.WriteLine("Volviendo al menú principal");
                                    Thread.Sleep(2000); // Espera 2 segundos
                                }
                                else if (confirmacion != 'N')
                                {
                                    Console.WriteLine("Opción no válida. Por favor, ingrese 'S' para confirmar o 'N' para cancelar.");
                                }
                            } while (confirmacion != 'S' && confirmacion != 'N');


                            break;
                    }
                    

                }
            }
        }
    }
}

