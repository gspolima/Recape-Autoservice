using Recape.Data.Repository.OrdensDeServico;
using System.Globalization;

namespace Recape.Services.OrdensDeServico;

public class OrdemDeServicoService : IOrdemDeServicoService
{
    private readonly IOrdemDeServicoRepository ordemRepository;

    public OrdemDeServicoService(IOrdemDeServicoRepository ordemRepository)
    {
        this.ordemRepository = ordemRepository;
    }

    public OrdemDeServicoViewModel GetOrdemDeServicoPorId(int id)
    {
        var ordem = ordemRepository.GetOrdemPorId(id)
            .Select(o => new OrdemDeServicoViewModel()
            {
                Id = o.Id,
                Servico = o.Servico.Nome,
                Valor = Convert.ToDecimal(o.Total),
                Data = o.Data.ToString("dd/MM/yyyy"),
                Horario = o.Horario.HoraDoDia.ToString("HH:mm")
            })
            .FirstOrDefault();

        return ordem;
    }

    public ConfirmacaoEmailViewModel GetDadosOrdemDeServicoParaEmail(string clienteId)
    {
        var dados = ordemRepository.GetOrdemPorCliente(clienteId)
            .Select(o => new ConfirmacaoEmailViewModel
            {
                Id = o.Id,
                NomeCliente = o.Cliente.NomeCompleto,
                EmailCliente = o.Cliente.Email,
                Data = o.Data.ToString("dd/MM/yyyy"),
                Horario = o.Horario.HoraDoDia.ToString("HH:mm"),
                Total = o.Total,
                Servico = o.Servico.Nome
            })
            .OrderByDescending(c => c.Id)
            .FirstOrDefault();

        return dados;
    }

    public List<OrdemDeServicoViewModel> GetOrdensDeServico(string clienteId)
    {
        var viewModel = ordemRepository.GetOrdensPorCliente(clienteId)
            .Include(o => o.Servico)
            .Include(o => o.Horario)
            .Select(o => new OrdemDeServicoViewModel()
            {
                Id = o.Id,
                Servico = o.Servico.Nome,
                Valor = o.Servico.Valor,
                Data = o.Data.ToString("dd/MM/yyyy"),
                Horario = o.Horario.HoraDoDia.ToString("HH:mm"),
                Status = o.Status
            })
            .ToList();

        viewModel.
            OrderBy(o => DateOnly.TryParse(
                o.Data,
                new CultureInfo("pt-BR"),
                DateTimeStyles.None,
                out var result));

        return viewModel;
    }

    public bool InserirOrdem(string clienteId, NovaOrdemDeServicoViewModel viewModel)
    {
        var ordem = new OrdemDeServico()
        {
            Status = Situacao.Aberto,
            ClienteId = clienteId,
            Data = viewModel.GetData(),
            ServicoId = viewModel.ServicoId,
            HorarioId = viewModel.HorarioId,
            Total = viewModel.Valor,
            Veiculo = new Veiculo()
            {
                Placa = viewModel.Placa.ToUpper(),
                Modelo = viewModel.Modelo,
                ProprietarioId = clienteId,
                Tipo = Enum.Parse<TipoVeiculo>(viewModel.TipoSelecionado)
            }
        };

        var sucesso = ordemRepository.Insert(ordem);

        return sucesso;
    }

    public bool verificarDisponibilidade(int servicoId, string data, int horarioId)
    {
        var dataFormatada = DateOnly.ParseExact(data, "yyyy-MM-dd");
        var existe = ordemRepository.Exists(servicoId, dataFormatada, horarioId);

        return existe;
    }

    public bool AtualizarStatusAoAvaliar(int id)
    {
        var ordem = ordemRepository.GetOrdemPorId(id)
            .Select(o => new OrdemDeServico()
            {
                Id = o.Id,
                ClienteId = o.ClienteId,
                Data = o.Data,
                ServicoId = o.ServicoId,
                HorarioId = o.HorarioId,
                Total = o.Total,
                Status = o.Status

            })
            .FirstOrDefault();

        if (ordem.Status == Situacao.Avaliado)
            return false;

        ordem.Status = Situacao.Avaliado;

        return ordemRepository.Update(ordem);
    }

    public bool CancelarOS(int id)
    {
        var ordem = ordemRepository.GetOrdemPorId(id)
            .Select(o => new OrdemDeServico()
            {
                Id = o.Id,
                ClienteId = o.ClienteId,
                Data = o.Data,
                ServicoId = o.ServicoId,
                HorarioId = o.HorarioId,
                Total = o.Total,
                Status = o.Status
            })
            .FirstOrDefault();

        if (ordem.Status == Situacao.Cancelado)
            return false;

        ordem.Status = Situacao.Cancelado;

        return ordemRepository.Update(ordem);
    }
}
