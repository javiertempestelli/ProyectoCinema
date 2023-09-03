using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCinema
{
    public class Sala
    {
        public int SalaId { get; set; }
        public string Nombre { get; set; }
        public int Capacidad { get; set; }
        public ICollection<Funcion> Funciones { get; set; }
    }
}
