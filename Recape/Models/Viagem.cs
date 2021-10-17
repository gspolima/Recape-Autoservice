using System;
using System.Collections.Generic;

namespace Recape.Models
{
    public class Viagem
    {
        public int Id { get; set; }
        public string Origem { get; set; }
        public string Destino { get; set; }
        public double Preco { get; set; }
        public DateTime DataPartida { get; set; }
        public float DuracaoEmHoras { get; set; }
        public List<Poltrona> Poltronas { get; set; } = new List<Poltrona>();
    }
}
