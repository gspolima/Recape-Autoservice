using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Recape.Data.Repository;
using Recape.Models;
using Recape.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace Recape.Controllers
{
    [Authorize]
    public class AgendamentosController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly IAgendamentoRepository agendamentoRepository;
        private readonly IEspecialidadeRepository especialidadeRepository;
        private readonly IMedicoRepository medicoRepository;

        public AgendamentosController(
            UserManager<IdentityUser> userManager,
            IAgendamentoRepository agendamentoRepository,
            IEspecialidadeRepository especialidadeRepository,
            IMedicoRepository medicoRepository)
        {
            this.userManager = userManager;
            this.agendamentoRepository = agendamentoRepository;
            this.medicoRepository = medicoRepository;
            this.especialidadeRepository = especialidadeRepository;
        }

        public IActionResult ListarAgendamentos()
        {
            var usuarioId = userManager.GetUserId(User);
            var agendamentos = agendamentoRepository
                .GetAgendamentos(usuarioId)
                .Select(a => new
                {
                    a.Id,
                    a.DataHorario,
                    Medico = a.Medico.Nome,
                    Paciente = a.Paciente.UserName,
                    Especialidade = a.Medico.Especialidade.Nome

                })
                .ToList();

            var viewModel = new List<AgendamentoViewModel>();

            foreach (var agend in agendamentos)
            {
                viewModel.Add(
                    new AgendamentoViewModel()
                    {

                        Id = agend.Id,
                        Paciente = agend.Paciente,
                        Medico = agend.Medico,
                        Especialidade = agend.Especialidade,
                        Data = agend.DataHorario.ToString("dd/MM/yyyy"),
                        Horario = agend.DataHorario.ToString("HH:mm")
                    }); ;
            }

            return View(viewModel);
        }

        public ActionResult NovoAgendamento()
        {
            var viewModel = new NovoAgendamentoViewModel();
            viewModel.MedicosEspecialidades = CarregarListaMedicos();

            return View(viewModel);
        }

        private List<SelectListItem> CarregarListaMedicos()
        {
            return medicoRepository
                .GetMedicos()
                .Select(
                    m => new SelectListItem()
                    {
                        Value = m.Id.ToString(),
                        Text = $"{m.Nome} -- {m.Especialidade}"
                    })
                .ToList();
        }


        [HttpPost]
        public ActionResult NovoAgendamento(NovoAgendamentoViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.MedicosEspecialidades = CarregarListaMedicos();
                return View("NovoAgendamento", viewModel);
            }

            var agendamento = new Agendamento()
            {
                PacienteId = userManager.GetUserId(User),
                MedicoId = viewModel.MedicoId,
                DataHorario = viewModel.GetDataHorario(),
            };

            var sucesso = agendamentoRepository.CriarAgendamento(agendamento);
            if (sucesso)
                return RedirectToAction("ListarAgendamentos");

            return StatusCode(500);
        }
    }
}
