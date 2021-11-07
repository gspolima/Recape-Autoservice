using Microsoft.AspNetCore.Identity;

namespace Recape.Models
{
    public class OrdemDeServico
    {
        public int Id { get; set; }
        public Servico Servico { get; set; }
        public int ServicoId { get; set; }
        public IdentityUser Cliente { get; set; }
        public string ClienteId { get; set; }
        public DataReservada DataAgendada { get; set; }
    }
}
