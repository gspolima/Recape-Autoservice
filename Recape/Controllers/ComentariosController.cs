using Recape.Data.Repository.Comentarios;
using Recape.Services.OrdensDeServico;

namespace Recape.Controllers;

[Authorize]
public class ComentariosController : Controller
{
    private readonly IOrdemDeServicoService ordemService;
    private readonly IComentarioRepository comentarioRepository;

    public ComentariosController(
        IOrdemDeServicoService ordemDeServicoService,
        IComentarioRepository comentarioRepository)
    {
        this.ordemService = ordemDeServicoService;
        this.comentarioRepository = comentarioRepository;
    }

    public IActionResult DeixarComentario(int ordemId)
    {
        var ordem = ordemService.GetOrdemDeServicoPorId(ordemId);
        var viewModel = new DeixarComentarioViewModel()
        {
            ServicoId = ordem.Id,
            Servico = ordem.Servico,
            Data = ordem.Data,
            Horario = ordem.Horario
        };


        return View(viewModel);
    }

    [HttpPost]
    public IActionResult DeixarComentario(DeixarComentarioViewModel comentarioViewModel)
    {
        if (!ModelState.IsValid)
        {
            var ordem = ordemService.GetOrdemDeServicoPorId(comentarioViewModel.ServicoId);
            comentarioViewModel.ServicoId = ordem.Id;
            comentarioViewModel.Servico = ordem.Servico;
            comentarioViewModel.Data = ordem.Data;
            comentarioViewModel.Horario = ordem.Horario;

            return View("DeixarComentario", ModelState);
        }

        var comentario = new Comentario()
        {
            Texto = comentarioViewModel.TextoComentario,
            OrdemDeServicoId = comentarioViewModel.ServicoId
        };

        var sucesso = comentarioRepository.Insert(comentario);

        if (sucesso)
        {
            ordemService.AtualizarOSAvaliada(comentarioViewModel.ServicoId, true);
            return RedirectToAction("ListarOrdens", "OrdensDeServico");
        }

        return StatusCode(500);
    }
}
