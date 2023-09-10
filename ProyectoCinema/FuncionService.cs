using Microsoft.EntityFrameworkCore;

namespace ProyectoCinema
{
    public class FuncionService
    {
        private readonly CinemaContext _context;

        public FuncionService(CinemaContext context)
        {
            this._context = context;
        }
        public void CreateFuncion(Funcion nuevaFuncion)
        {
            _context.Funciones.Add(nuevaFuncion);
            _context.SaveChanges();
        }

        public List<Funcion> GetAllFunciones()
        {
            return _context.Funciones.ToList();
        }

        public List<Pelicula> GetAllPeliculas()
        {
            return _context.Peliculas.ToList();
        }

        public List<Sala> GetAllSalas()
        {
            return _context.Salas.ToList();
        }
        public string GetPeliculaTituloById(int peliculaId)
        {
            // Utiliza tu DbContext para consultar la base de datos y obtener el título de la película
            var pelicula = _context.Peliculas.FirstOrDefault(p => p.PeliculaId == peliculaId);

            if (pelicula != null)
            {
                return pelicula.Titulo;
            }
            else
            {
                // Manejar el caso en el que el ID de la película no existe
                return "Película no encontrada";
            }
        }

        public string GetSalaNombreById(int salaId)
        {
            // Utiliza tu DbContext para consultar la base de datos y obtener el nombre de la sala
            var sala = _context.Salas.FirstOrDefault(s => s.SalaId == salaId);

            if (sala != null)
            {
                return sala.Nombre;
            }
            else
            {
                // Manejar el caso en el que el ID de la sala no existe
                return "Sala no encontrada";
            }
        }

    }

}