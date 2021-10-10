using Microsoft.AspNetCore.Identity;
using Recape.Models;

namespace Recape.ViewModels
{
    public class AgendamentoViewModel
    {
        public int Id { get; set; }
        public IdentityUser Paciente { get; set; }
        public Medico Medico { get; set; }
        public string Data { get; set; }
        public string Horario { get; set; }
    }
}
