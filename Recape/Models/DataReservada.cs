using System;

namespace Recape.Models
{
    public class DataReservada
    {
        public int Id { get; set; }
        public DateTime DataHorario { get; set; }
        public OrdemDeServico OrdemDeServico { get; set; }
        public int OrdemDeServicoId { get; set; }
    }
}