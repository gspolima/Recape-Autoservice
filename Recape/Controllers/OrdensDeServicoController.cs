using Microsoft.AspNetCore.Mvc.Rendering;
using Recape.Data.Repository.Horarios;
using Recape.Services.Email;
using Recape.Services.OrdensDeServico;
using Recape.Services.Veiculos;

namespace Recape.Controllers;

[Authorize]
public class OrdensDeServicoController : Controller
{
    private readonly IOrdemDeServicoService ordemService;
    private readonly IHorarioRepository horarioRepository;
    private readonly IEmailService emailService;
    private readonly IVeiculoService veiculoService;
    private readonly UserManager<Usuario> userManager;

    public OrdensDeServicoController(
        IOrdemDeServicoService ordemService,
        IHorarioRepository horarioRepository,
        IEmailService emailService,
        IVeiculoService veiculoService,
        UserManager<Usuario> userManager)
    {
        this.ordemService = ordemService;
        this.horarioRepository = horarioRepository;
        this.emailService = emailService;
        this.veiculoService = veiculoService;
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
        var usuarioLogadoId = GetIdUsuarioLogado();

        if (!ModelState.IsValid)
        {
            PopularListas(viewModel);
            return View("CriarOrdem", viewModel);
        }

        var veiculoJaPossuiOSEmAberto = ordemService
            .ExisteOSAbertaParaVeiculo(viewModel.VeiculoId);

        if (veiculoJaPossuiOSEmAberto)
        {
            ModelState.AddModelError(
                "VeiculoId",
                "Este veículo já possui uma ordem de serviço que está em aberto.");
        }

        var existeConflitoDeData = ordemService
            .verificarDisponibilidade(
                viewModel.ServicoId,
                viewModel.Data,
                viewModel.HorarioId);

        if (existeConflitoDeData)
        {
            ModelState.AddModelError(
                "ExisteConflitoDeHorario",
                "Horário já reservado para o serviço e data selecionados. Escolha outro horário.");
        }

        if (!string.IsNullOrEmpty(viewModel.Placa))
        {
            var veiculoJaExiste = veiculoService.VeiculoExiste(viewModel.Placa);

            if (veiculoJaExiste)
            {
                var pertenceAoUsuarioLogado = veiculoService
                    .VeiculoPertenceAoUsuario(viewModel.Placa, usuarioLogadoId);

                if (pertenceAoUsuarioLogado)
                {
                    ModelState.AddModelError(
                        "Placa",
                        "Este veículo já existe e pertence a você. Selecione-o na lista de veículos");
                }
                else
                {
                    ModelState.AddModelError(
                        "Placa",
                        "Este veículo pertence a outro cliente");
                }


            }
        }

        if (!TryValidateModel(ModelState))
        {
            PopularListas(viewModel);
            return View("CriarOrdem", viewModel);
        }

        var sucesso = ordemService
            .InserirOrdem(usuarioLogadoId, viewModel);

        if (sucesso)
        {
            var dadosEmail = ordemService
                .GetDadosOrdemDeServicoParaEmail(usuarioLogadoId);
            var corpoEmail = emailService
                .FormatarCorpoEmail(dadosEmail);

            var emailConfirmacao = new EmailAutomatico()
            {
                Destinatario = userManager.GetUserName(User),
                Assunto = $"Confirmação da Ordem de Serviço #{dadosEmail.Id}",
                Corpo = corpoEmail
            };

            var emailEnviado = await emailService
                .EnviarEmailAsync(emailConfirmacao);

            if (emailEnviado)
                return RedirectToAction("ListarOrdens");

            return StatusCode(500);
        }

        return StatusCode(500);
    }

    private SelectList CarregarListaVeiculosCadastrados()
    {
        var usuarioId = GetIdUsuarioLogado();
        if (veiculoService.UsuarioTemVeiculoCadastrado(usuarioId))
        {
            var veiculos = veiculoService.GetVeiculosPorProprietarioId(usuarioId);

            return new SelectList(veiculos, "Id", "TipoModeloPlaca");
        }

        var listaVazia = new List<VeiculoCadastradoViewModel>();
        return new SelectList(listaVazia);
    }

    private SelectList CarregarListaHorarios()
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

    private SelectList CarregarListaTiposVeiculo()
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
        viewModel.VeiculosCadastrados = CarregarListaVeiculosCadastrados();
        viewModel.TiposVeiculo = CarregarListaTiposVeiculo();
        viewModel.Horarios = CarregarListaHorarios();
    }

    private string GetIdUsuarioLogado()
    {
        return userManager.GetUserId(User);
    }
}
