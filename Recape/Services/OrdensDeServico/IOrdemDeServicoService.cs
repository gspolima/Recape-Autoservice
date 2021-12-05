using Recape.ViewModels;

namespace Recape.Services.OrdensDeServico;

public interface IOrdemDeServicoService
{
    OrdemDeServicoViewModel GetOrdemDeServicoPorId(int id);
    ConfirmacaoEmailViewModel GetDadosOrdemDeServicoParaEmail(string clienteId);
    List<OrdemDeServicoViewModel> GetOrdensDeServico(string clienteId);
    bool InserirOrdem(string clienteId, NovaOrdemDeServicoViewModel viewModel);
    bool verificarDisponibilidadeHorario(int servicoId, string data, int horarioId);
    bool AtualizarOSAvaliada(int id, bool avaliado);
    bool CancelarOS(int id);
}
