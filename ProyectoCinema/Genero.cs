using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCinema
{
    public class Genero
    {
        public int GeneroId { get; set; }
        public string Nombre { get; set; }
        public Genero() { }

        public ICollection<Pelicula> Peliculas { get; set;}
    }
}
