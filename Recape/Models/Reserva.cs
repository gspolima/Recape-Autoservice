namespace Recape.Models
{
    public class Reserva
    {
        public int Id { get; set; }
        public Poltrona Poltrona { get; set; }
        public int PoltronaId { get; set; }
        public Usuario Cliente { get; set; }
        public string ClienteId { get; set; }
    }
}
