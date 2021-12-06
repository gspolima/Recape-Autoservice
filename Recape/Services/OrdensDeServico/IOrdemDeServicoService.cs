namespace Recape.Services.OrdensDeServico;

public interface IOrdemDeServicoService
{
    OrdemDeServicoViewModel GetOrdemDeServicoPorId(int id);
    ConfirmacaoEmailViewModel GetDadosOrdemDeServicoParaEmail(string clienteId);
    List<OrdemDeServicoViewModel> GetOrdensDeServico(string clienteId);
    bool InserirOrdem(string clienteId, NovaOrdemDeServicoViewModel viewModel);
    bool verificarDisponibilidade(int servicoId, string data, int horarioId);
    bool AtualizarStatusAoAvaliar(int id);
    bool CancelarOS(int id);
}
