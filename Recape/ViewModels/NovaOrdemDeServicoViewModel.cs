using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Recape.ViewModels
{
    public class NovaOrdemDeServicoViewModel : DataHorarioViewModel
    {
        public SelectList Servicos { get; set; }

        [Required(ErrorMessage = "Um serviço deve ser selecionado")]
        public int ServicoId { get; set; }
    }
}
