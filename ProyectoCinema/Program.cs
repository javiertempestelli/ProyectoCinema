﻿using Microsoft.Extensions.Configuration;

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
                    Console.WriteLine("║  3. Buscar por dia/pelicula              ║");
                    Console.WriteLine("║                                          ║");
                    Console.WriteLine("║  Presione 'Q' para salir                 ║");
                    Console.WriteLine("╚══════════════════════════════════════════╝");
                    Console.Write("Seleccione una opción: ");

                    //Capturo el input por teclado
                    char option = Char.ToUpper(Console.ReadKey().KeyChar);
                    Console.WriteLine();

                    switch (option)
                    {
                        case '2':


                            // El usuario presiona "2", se listan todas las funciones disponibles
                            // Se instancia un objeto funcionService que sabe todo lo que puede hacer
                            var funciones = funcionService.GetAllFunciones();

                            if (funciones.Any())
                            {
                                foreach (var funcion in funciones)
                                {
                                    Console.WriteLine("--------------------------------------------");
                                    Console.WriteLine($"Funcion N°: {funcion.FuncionId}, Fecha: {funcion.Fecha.ToString("yyyy-MM-dd")}, Hora: {funcion.Horario.ToString("HH:mm:ss")}");
                                    string nombredelasala = funcionService.GetSalaNombreById(funcion.SalaId);
                                    string nombredelgenero = funcionService.GetGeneroNombreById(funcion.PeliculaId);
                                    string nombredelapelicula = funcionService.GetPeliculaTituloById(funcion.PeliculaId);
                                    Console.WriteLine($"{nombredelasala}, Película: {nombredelapelicula}, Genero: {nombredelgenero}");
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
                            // Alta de una FUNCION
                            var nuevaFuncion = new Funcion();

                            Console.Write("Fecha (YYYY-MM-DD): ");
                            DateTime fecha;
                            while (true)
                            {
                                try
                                {   //Si puedo parsear el input a DateTime, sale como fecha
                                    if (DateTime.TryParse(Console.ReadLine(), out fecha))
                                        break;
                                    else
                                        throw new Exception("Fecha no válida. Ingrese una fecha en el formato YYYY-MM-DD.");
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                            }
                            nuevaFuncion.Fecha = fecha;

                            Console.Write("Horario (HH:mm:ss): ");
                            DateTime horario;
                            while (true)
                            {
                                try
                                {
                                    if (DateTime.TryParse(Console.ReadLine(), out horario))
                                        break;
                                    else
                                        throw new Exception("Horario no válido. Ingrese un horario en el formato HH:mm:ss.");
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                            }
                            nuevaFuncion.Horario = horario;

                            // Listar las peliculas para su seleccion
                            var peliculas = funcionService.GetAllPeliculas();
                            Console.WriteLine("Peliculas disponibles:");
                            foreach (var pelicula in peliculas)
                            {
                                Console.WriteLine($"ID: {pelicula.PeliculaId}, Título: {pelicula.Titulo}");
                            }

                            int peliculaId;
                            while (true)
                            {
                                try
                                {
                                    Console.Write("Seleccione la película (ID): ");
                                    if (int.TryParse(Console.ReadLine(), out peliculaId))
                                    {
                                        if (peliculas.Any(p => p.PeliculaId == peliculaId))
                                            break;
                                        else
                                            throw new Exception("ID de película no válido. Seleccione un ID válido.");
                                    }
                                    else
                                    {
                                        throw new Exception("ID de película no válido. Ingrese un número.");
                                    }
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
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
                            string generoNombre = funcionService.GetGeneroNombreById(nuevaFuncion.PeliculaId);
                            Console.WriteLine($"Película: {peliculaTitulo}, Genero: {generoNombre}, Sala: {salaNombre}");
                            Console.WriteLine("--------------------------------------------");

                            // Se debe confirmar el alta con un resumen de los elementos seleccionados

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

                        case '3':
                            // Listar funciones por día y/o título de película
                            Console.Write("Ingrese la fecha (YYYY-MM-DD) (deje en blanco para listar todas las fechas): ");
                            string fechaStr = Console.ReadLine();
                            DateTime? fechaFiltro = null;

                            if (!string.IsNullOrEmpty(fechaStr) && DateTime.TryParse(fechaStr, out DateTime fechaSeleccionada))
                            {
                                fechaFiltro = fechaSeleccionada;
                            }

                            Console.Write("Ingrese el título de la película (deje en blanco para listar todas las películas): ");
                            string tituloPeliculaFiltro = Console.ReadLine();
                            
                            var funcionesFiltradas = funcionService.GetFuncionesPorFechaYPelicula(fechaFiltro, tituloPeliculaFiltro);

                            foreach (var funcion in funcionesFiltradas)
                            {
                                Console.WriteLine($"ID: {funcion.FuncionId}, Fecha: {funcion.Fecha}, Hora: {funcion.Horario}");
                                Console.WriteLine($"Pelicula: {funcion.Pelicula.Titulo}, Sala: {funcion.Sala.Nombre}");
                                // Muestra otros detalles de la función según tu modelo de datos
                            }
                            break;
                    }



                }
            }
        }
    }
}

