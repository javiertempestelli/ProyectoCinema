using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCinema
{
    public class Ticket
    {
        public Guid TicketId { get; set; }
        public string Usuario { get; set; } 

        public ICollection<Funcion> Funciones { get; set; }


    }
}
