using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Recape.ViewModels
{
    public class NovoAgendamentoViewModel : DataHorarioViewModel
    {
        public List<SelectListItem> MedicosEspecialidades { get; set; }

        [Required(ErrorMessage = "Um médico deve ser selecionado")]
        public int MedicoId { get; set; }
    }
}
