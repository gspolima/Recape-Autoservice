using Recape.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace Recape.ViewModels
{
    public class DataHorarioViewModel
    {
        [Required(ErrorMessage = "A data é obrigatória")]
        [DataFutura(ErrorMessage = "Apenas uma data no futuro pode ser informada")]
        public string Data { get; set; }

        [Required(ErrorMessage = "Um horário deve ser selecionado")]
        public string Horario { get; set; }

        public DateTime GetDataHorario() => DateTime.Parse(string.Format($"{Data} {Horario}"));
    }
}
