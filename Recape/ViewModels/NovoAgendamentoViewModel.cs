using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;

namespace Recape.ViewModels
{
    public class NovoAgendamentoViewModel
    {
        public List<SelectListItem> MedicosEspecialidades { get; set; }
        public string Data { get; set; }
        public string Horario { get; set; }

        public int MedicoId { get; set; }
        public string UsuarioId { get; set; }
        public DateTime GetDataHorario() => DateTime.Parse($"{Data} {Horario}");
    }
}
