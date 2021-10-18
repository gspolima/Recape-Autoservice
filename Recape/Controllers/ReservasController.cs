using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Recape.Data.Repository;
using Recape.ViewModels;
using System.Collections.Generic;

namespace Recape.Controllers
{
    [Authorize]
    public class ReservasController : Controller
    {
        private readonly IReservaRepository reservaRepository;
        private readonly UserManager<IdentityUser> userManager;

        public ReservasController(
            IReservaRepository reservaRepository,
            UserManager<IdentityUser> userManager)
        {
            this.reservaRepository = reservaRepository;
            this.userManager = userManager;
        }


        public IActionResult ListarReservas()
        {
            var usuarioId = userManager.GetUserId(User);
            var reservas = reservaRepository.GetReservas(usuarioId);

            var viewModel = new List<ReservaViewModel>();

            foreach (var reserva in reservas)
            {
                viewModel.Add(new ReservaViewModel()
                {
                    Id = reserva.Id,
                    Cliente = reserva.Cliente,
                    Poltrona = reserva.Poltrona,
                    DataPartida = reserva.Poltrona.Viagem.DataPartida.ToString("dd/MM/yyyy"),
                    HorarioPartida = reserva.Poltrona.Viagem.DataPartida.ToString("HH:mm")
                });
            }

            return View(viewModel);
        }
    }
}
