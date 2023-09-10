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
