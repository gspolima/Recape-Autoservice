using Microsoft.AspNetCore.Mvc;
using Recape.Data.Repository;
using Recape.ViewModels;

namespace Recape.Controllers
{
    public class ViagensController : Controller
    {
        private readonly IViagemRepository viagemRepository;

        public ViagensController(IViagemRepository viagemRepository)
        {
            this.viagemRepository = viagemRepository;
        }

        public IActionResult InserirPoltronas()
        {
            var viewModel = new InserirPoltronasViewModel()
            {
                bancoDeDadosSemeado = true,
            };

            var poltronasInseridas = viagemRepository.InserirPoltronas();

            if (poltronasInseridas != 0)
            {
                viewModel.bancoDeDadosSemeado = false;
                viewModel.sucessoOperacao = true;
                viewModel.poltronasInseridas = poltronasInseridas;
            }

            return View(viewModel);
        }
    }
}
