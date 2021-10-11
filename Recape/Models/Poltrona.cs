namespace Recape.Models
{
    public class Poltrona
    {
        public int Id { get; set; }
        public byte Numero { get; set; }
        public bool Disponivel { get; set; }
        public Viagem Viagem { get; set; }
        public int ViagemId { get; set; }
    }
}
