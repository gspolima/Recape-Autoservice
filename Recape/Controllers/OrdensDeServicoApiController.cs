using Recape.Services.OrdensDeServico;
using Recape.Services.Servicos;

namespace Recape.Controllers;

[Route("OrdensDeServico/api/")]
[Authorize]
[ApiController]
public class OrdensDeServicoApiController : ControllerBase
{
    private readonly IServicoService servicoService;
    private readonly IOrdemDeServicoService ordemDeServicoService;

    public OrdensDeServicoApiController(
        IServicoService servicoService,
        IOrdemDeServicoService ordemDeServicoService)
    {
        this.servicoService = servicoService;
        this.ordemDeServicoService = ordemDeServicoService;
    }

    [HttpGet("valorServico/{servicoId}")]
    public IActionResult GetValorDoServico(int servicoId)
    {
        var valor = servicoService.GetValorPorServicoId(servicoId);

        return Ok(valor);
    }

    [HttpGet("listaServico/{tipoVeiculo}")]
    public IActionResult GetListaDeServicosParaVeiculo(string tipoVeiculo)
    {
        try
        {
            var servicos = servicoService.GetListaDeServicos(tipoVeiculo);
            return Ok(servicos);
        }
        catch (Exception exception)
        {
            return StatusCode(500, exception.Message);
        }

    }

    [HttpPost("cancelar/{ordemId}")]
    public IActionResult CancelarOS(int ordemId)
    {
        var sucesso = ordemDeServicoService.CancelarOS(ordemId);

        if (sucesso)
            return Ok();

        return StatusCode(500);
    }
}
