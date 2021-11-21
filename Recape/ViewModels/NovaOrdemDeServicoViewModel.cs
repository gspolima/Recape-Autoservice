using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Recape.ViewModels
{
    public class NovaOrdemDeServicoViewModel : DataViewModel
    {
        public SelectList Servicos { get; set; }

        [Required(ErrorMessage = "Um serviço deve ser selecionado")]
        public int ServicoId { get; set; }

        public SelectList Horarios { get; set; }

        [Required(ErrorMessage = "Um horário deve ser selecionado")]
        public int HorarioId { get; set; }

        public bool ExisteConflito { get; set; }
    }
}
