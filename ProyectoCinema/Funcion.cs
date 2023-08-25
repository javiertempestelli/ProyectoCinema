using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCinema
{
    public class Funcion
    {
        public int FuncionId { get; set; }

        public Sala Sala { get; set; }

        public DateTime Fecha { get; set; }

        public DateTime Horario { get; set; }

        public ICollection<Ticket> Tickets { get; set; }

        public Pelicula Pelicula { get; set; }
    }
}
