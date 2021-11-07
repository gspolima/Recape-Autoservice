using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Recape.Data.Repository.Servicos;
using Recape.Services.OrdensDeServico;
using Recape.ViewModels;
using System.Linq;

namespace Recape.Controllers
{
    [Authorize]
    public class OrdensDeServicoController : Controller
    {
        private readonly IServicoRepository servicoRepository;
        private readonly IOrdemDeServicoService ordemService;
        private readonly UserManager<IdentityUser> userManager;

        public OrdensDeServicoController(
            IServicoRepository servicoRepository,
            IOrdemDeServicoService ordemService,
            UserManager<IdentityUser> userManager)
        {
            this.servicoRepository = servicoRepository;
            this.ordemService = ordemService;
            this.userManager = userManager;
        }

        public IActionResult ListarOrdens()
        {
            var usuario = userManager.GetUserId(User);

            var ordens = ordemService.GetOrdensDeServico(usuario);

            return View(ordens);
        }

        public IActionResult CriarOrdem()
        {
            var viewModel = new NovaOrdemDeServicoViewModel();

            viewModel.Servicos = PopularListaServicos();

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult CriarOrdem(NovaOrdemDeServicoViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Servicos = PopularListaServicos();
                return View("CriarOrdem", viewModel);
            }

            var usuarioLogado = userManager.GetUserId(User);

            var sucesso = ordemService.InserirOrdem(usuarioLogado, viewModel);

            if (sucesso)
                return RedirectToAction("ListarOrdens");

            return StatusCode(500);

        }

        private SelectList PopularListaServicos()
        {
            var servicos = servicoRepository.GetServicos()
                .Select(s => new
                {
                    Id = s.Id,
                    Nome = s.Nome
                })
                .OrderBy(s => s.Nome)
                .ToList();

            return new SelectList(servicos, "Id", "Nome");
        }
    }
}
