using Recape.Data.Repository.Servicos;
using Recape.Services.OrdensDeServico;

namespace Recape.Controllers;

[Route("OrdensDeServico/api/")]
[Authorize]
[ApiController]
public class OrdensDeServicoApiController : ControllerBase
{
    private readonly IServicoRepository servicoRepository;
    private readonly IOrdemDeServicoService ordemDeServicoService;

    public OrdensDeServicoApiController(
        IServicoRepository servicoRepository,
        IOrdemDeServicoService ordemDeServicoService)
    {
        this.servicoRepository = servicoRepository;
        this.ordemDeServicoService = ordemDeServicoService;
    }

    [HttpGet("valorServico/{servicoId}")]
    public IActionResult GetValorDoServico(int servicoId)
    {
        var valor = servicoRepository.GetValorPorServicoId(servicoId);

        return Ok(valor);
    }

    [HttpPost("cancelar/{ordemId}")]
    public IActionResult CancelarOS(int ordemId)
    {
        var sucesso = ordemDeServicoService.CancelarOS(ordemId);

        if (sucesso)
            return Ok("json");

        return StatusCode(500);
    }
}
