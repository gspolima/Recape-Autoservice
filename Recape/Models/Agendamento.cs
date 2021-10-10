using Microsoft.AspNetCore.Identity;
using System;

namespace Recape.Models
{
    public class Agendamento
    {
        public int Id { get; set; }
        public DateTime DataHorario { get; set; }
        public IdentityUser Paciente { get; set; }
        public string PacienteId { get; set; }
        public Medico Medico { get; set; }
        public int MedicoId { get; set; }
    }
}
