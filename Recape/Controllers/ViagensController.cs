using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Recape.Data.Repository;
using Recape.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace Recape.Controllers
{
    [Authorize]
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

        [HttpGet]
        public IActionResult ListarViagens()
        {
            var viagens = viagemRepository.GetViagens()
                .Select(v =>
                    new
                    {
                        v.Id,
                        v.Origem,
                        v.Destino,
                        v.Preco,
                        v.DuracaoEmHoras,
                        Data = v.DataPartida.ToString("dd/MM/yyyy"),
                        Horario = v.DataPartida.ToString("HH:mm")
                    }
                )
                .ToList()
                .OrderBy(v => v.Data);

            var viewModel = new List<ListarViagensViewModel>();

            foreach (var viagem in viagens)
            {
                viewModel.Add(
                    new ListarViagensViewModel()
                    {
                        Id = viagem.Id,
                        Origem = viagem.Origem,
                        Destino = viagem.Destino,
                        Preco = viagem.Preco,
                        DuracaoEmHoras = viagem.DuracaoEmHoras,
                        DataSaida = viagem.Data,
                        HorarioSaida = viagem.Horario
                    }
                );
            }

            return View(viewModel);
        }
    }
}
