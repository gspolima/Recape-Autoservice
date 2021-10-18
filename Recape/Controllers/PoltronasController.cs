using Microsoft.AspNetCore.Mvc;
using Recape.Data.Repository;
using Recape.ViewModels;
using System.Linq;

namespace Recape.Controllers
{
    public class PoltronasController : Controller
    {
        private readonly IPoltronaRepository poltronaRepository;
        private readonly IViagemRepository viagemRepository;

        public PoltronasController(
            IPoltronaRepository poltronaRepository,
            IViagemRepository viagemRepository)
        {
            this.poltronaRepository = poltronaRepository;
            this.viagemRepository = viagemRepository;
        }

        public IActionResult ListarPoltronas(int viagemId)
        {
            var viagem = viagemRepository.GetViagem(viagemId);
            var poltronas = poltronaRepository
                .GetPoltronas(viagemId)
                .OrderBy(p => p.Numero)
                .ToList();

            var viewModel = new ListarPoltronasViewModel()
            {
                PrecoUnitario = viagem.Preco,
                Poltronas = poltronas
            };

            return View(viewModel);
        }
    }
}
