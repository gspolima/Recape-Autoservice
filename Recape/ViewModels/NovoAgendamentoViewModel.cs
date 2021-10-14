using Microsoft.AspNetCore.Mvc.Rendering;
using Recape.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Recape.ViewModels
{
    public class NovoAgendamentoViewModel
    {
        public List<SelectListItem> MedicosEspecialidades { get; set; }

        [Required(ErrorMessage = "A data é obrigatória")]
        [DataFutura(ErrorMessage = "Apenas uma data no futuro pode ser informada")]
        public string Data { get; set; }

        [Required(ErrorMessage = "Um horário deve ser selecionado")]
        public string Horario { get; set; }

        [Required(ErrorMessage = "Um médico deve ser selecionado")]
        public int MedicoId { get; set; }

        public string UsuarioId { get; set; }
        public DateTime GetDataHorario() => DateTime.Parse(String.Format($"{Data} {Horario}"));
    }
}
