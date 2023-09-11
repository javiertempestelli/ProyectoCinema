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

        public string GetGeneroNombreById(int peliculaId)
        {
            /* Recibe un generoId como parámetro y busca en la base de datos 
            el género correspondiente al ID proporcionado. 
            Si encuentra el género, devuelve su nombre; de lo contrario
            , devuelve un mensaje indicando que el género no se encontró. */
            var pelicula = _context.Peliculas.FirstOrDefault(p => p.PeliculaId == peliculaId);

            if (pelicula != null)
            {
                var genero = _context.Generos.FirstOrDefault(g => g.GeneroId == pelicula.GeneroId);

                if (genero != null)
                {
                    return genero.Nombre;
                }
                else
                {
                    // Manejar el caso en el que el ID del género no existe
                    return "¿Género NULL?";
                }
            }
            else
            {
                // Manejar el caso en el que el ID de la película no existe
                return "¿Película NULL?";
            }
        }


        public List<Funcion> GetFuncionesPorFechaYPelicula(DateTime? fecha, string tituloPelicula)
        {
            IQueryable<Funcion> query = _context.Funciones.Include(f => f.Pelicula).Include(f => f.Sala);

            if (fecha.HasValue)
            {
                query = query.Where(f => f.Fecha.Date == fecha.Value.Date);
            }

            if (!string.IsNullOrEmpty(tituloPelicula))
            {
                query = query.Where(f => f.Pelicula.Titulo.Contains(tituloPelicula));
            }

            return query.ToList();
        }

    }
}