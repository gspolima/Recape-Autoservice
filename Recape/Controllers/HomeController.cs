using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Recape.Data.Repository.Comentarios;
using Recape.ViewModels;
using System.Diagnostics;
using System.Linq;

namespace Recape.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IComentarioRepository comentarioRepository;

        public HomeController(
            ILogger<HomeController> logger,
            IComentarioRepository comentarioRepository)
        {
            _logger = logger;
            this.comentarioRepository = comentarioRepository;
        }

        public IActionResult Index()
        {
            var comentarios = comentarioRepository.GetComentarios()
                .Select(c => new ComentarioViewModel()
                {
                    Cliente = c.OrdemDeServico.Cliente.UserName,
                    Servico = c.OrdemDeServico.Servico.Nome,
                    Texto = c.Texto,
                    Data = c.OrdemDeServico.Data
                })
                .OrderBy(c => c.Texto.Length)
                .ToList();

            return View(comentarios);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
