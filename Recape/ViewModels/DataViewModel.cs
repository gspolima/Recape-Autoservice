using Recape.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace Recape.ViewModels
{
    public class DataViewModel
    {
        [Required(ErrorMessage = "A data é obrigatória")]
        [DataFutura(ErrorMessage = "Apenas uma data no futuro pode ser informada")]
        public string Data { get; set; }

        public DateOnly GetData() => DateOnly.ParseExact(Data, "yyyy-MM-dd");
    }
}
