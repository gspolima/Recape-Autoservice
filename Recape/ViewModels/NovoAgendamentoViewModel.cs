using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Recape.ViewModels
{
    public class NovoAgendamentoViewModel : DataViewModel
    {
        public List<SelectListItem> MedicosEspecialidades { get; set; }

        [Required(ErrorMessage = "Um médico deve ser selecionado")]
        public int MedicoId { get; set; }

        [Required(ErrorMessage = "Um horário deve ser selecionado")]
        public string Horario { get; set; }

        public TimeOnly GetHorario() => TimeOnly.ParseExact(Horario, "hh:mm");
    }
}
