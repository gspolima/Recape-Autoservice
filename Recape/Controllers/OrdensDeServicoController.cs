using Microsoft.AspNetCore.Mvc.Rendering;
using Recape.Data.Repository.Horarios;
using Recape.Data.Repository.Servicos;
using Recape.Services.Email;
using Recape.Services.OrdensDeServico;

namespace Recape.Controllers;

[Authorize]
public class OrdensDeServicoController : Controller
{
    private readonly IServicoRepository servicoRepository;
    private readonly IOrdemDeServicoService ordemService;
    private readonly IHorarioRepository horarioRepository;
    private readonly IEmailService emailService;
    private readonly UserManager<Usuario> userManager;

    public OrdensDeServicoController(
        IServicoRepository servicoRepository,
        IOrdemDeServicoService ordemService,
        IHorarioRepository horarioRepository,
        IEmailService emailService,
        UserManager<Usuario> userManager)
    {
        this.servicoRepository = servicoRepository;
        this.ordemService = ordemService;
        this.horarioRepository = horarioRepository;
        this.emailService = emailService;
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
        PopularListas(viewModel);

        return View(viewModel);
    }

    [HttpPost]
    public async Task<ActionResult> CriarOrdem(NovaOrdemDeServicoViewModel viewModel)
    {
        if (!ModelState.IsValid)
        {
            PopularListas(viewModel);
            return View("CriarOrdem", viewModel);
        }

        var existeConflitoDeData = ordemService.verificarDisponibilidade(
            viewModel.ServicoId,
            viewModel.Data,
            viewModel.HorarioId);

        if (existeConflitoDeData)
        {
            ModelState.AddModelError(
                "ExisteConflito",
                "Horário já reservado para o serviço e data selecionados. Escolha outro horário.");
        }

        if (!TryValidateModel(ModelState))
        {
            PopularListas(viewModel);
            return View("CriarOrdem", viewModel);
        }

        var usuarioLogado = userManager.GetUserId(User);

        var sucesso = ordemService.InserirOrdem(usuarioLogado, viewModel);

        if (sucesso)
        {
            var dadosEmail = ordemService.GetDadosOrdemDeServicoParaEmail(usuarioLogado);
            var corpoEmail = emailService.FormatarCorpoEmail(dadosEmail);

            var emailConfirmacao = new EmailAutomatico()
            {
                Destinatario = userManager.GetUserName(User),
                Assunto = $"Confirmação da Ordem de Serviço #{dadosEmail.Id}",
                Corpo = corpoEmail
            };

            var enviado = await emailService.EnviarEmailAsync(emailConfirmacao);

            if (enviado)
                return RedirectToAction("ListarOrdens");

            return StatusCode(500);
        }

        return StatusCode(500);
    }


    private SelectList PopularListaHorarios()
    {
        var horarios = horarioRepository.GetHorarios()
            .Select(h => new
            {
                h.Id,
                h.HoraDoDia
            })
            .ToList();

        return new SelectList(horarios, "Id", "HoraDoDia");
    }

    private SelectList PopularListaTiposVeiculo()
    {
        var tipos = new List<TipoVeiculoViewModel>()
        {
            new TipoVeiculoViewModel()
            {
                Tipo = "Carro",
                NomeDeExibicao =  "Carro"
            },
            new TipoVeiculoViewModel()
            {
                Tipo = "Moto",
                NomeDeExibicao =  "Moto"
            }
        };

        return new SelectList(tipos, "Tipo", "NomeDeExibicao");
    }

    private void PopularListas(NovaOrdemDeServicoViewModel viewModel)
    {
        viewModel.TiposVeiculo = PopularListaTiposVeiculo();
        viewModel.Horarios = PopularListaHorarios();
    }
}
