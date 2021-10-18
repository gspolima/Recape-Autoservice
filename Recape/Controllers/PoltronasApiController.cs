using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Recape.Data.Repository;
using Recape.DTOs;
using Recape.Models;
using System.Collections.Generic;

namespace Recape.Controllers
{
    [Route("api/poltronas")]
    [Authorize]
    [ApiController]
    public class PoltronasApiController : ControllerBase
    {
        private readonly IPoltronaRepository poltronaRepository;
        private readonly IViagemRepository viagemRepository;
        private readonly IReservaRepository reservaRepository;
        private readonly UserManager<IdentityUser> userManager;

        public PoltronasApiController(
            IPoltronaRepository poltronaRepository,
            IViagemRepository viagemRepository,
            IReservaRepository reservaRepository,
            UserManager<IdentityUser> userManager)
        {
            this.poltronaRepository = poltronaRepository;
            this.viagemRepository = viagemRepository;
            this.reservaRepository = reservaRepository;
            this.userManager = userManager;
        }

        [Route("reservar")]
        [HttpPost]
        public IActionResult ReservarPoltronas([FromBody] List<PoltronaReservadaDto> selecionadas)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (selecionadas.Count != 0)
            {
                var reservas = new List<Reserva>();
                var usuarioId = userManager.GetUserId(User);

                foreach (var poltrona in selecionadas)
                {
                    var reserva = new Reserva()
                    {
                        PoltronaId = poltrona.Id,
                        ClienteId = usuarioId,
                    };
                    poltronaRepository.IndisponibilizarPoltrona(reserva.PoltronaId);

                    reservas.Add(reserva);
                }

                var criadas = reservaRepository.CriarReservas(reservas);
                if (criadas > 0)
                    return Ok($"{criadas} reservas criadas");

                return StatusCode(500, "Erro ao criar reservas");
            }

            return BadRequest();
        }
    }
}
