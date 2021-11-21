using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Recape.Data.Repository.Servicos;

namespace Recape.Controllers
{
    [Route("OrdensDeServico/api/")]
    [Authorize]
    [ApiController]
    public class OrdensDeServicoApiController : ControllerBase
    {
        private readonly IServicoRepository servicoRepository;

        public OrdensDeServicoApiController(IServicoRepository servicoRepository)
        {
            this.servicoRepository = servicoRepository;
        }

        [HttpGet("valorServico/{servicoId}")]
        public IActionResult GetValorDoServico(int servicoId)
        {
            var valor = servicoRepository.GetValorPorServicoId(servicoId);

            return Ok(valor);
        }
    }
}
