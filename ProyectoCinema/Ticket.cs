using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
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
        public int FuncionId { get; set; }
        public Funcion Funcion { get; set; }


    }
}
