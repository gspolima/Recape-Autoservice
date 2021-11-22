using Recape.ViewModels;
using System.Collections.Generic;

namespace Recape.Services.OrdensDeServico
{
    public interface IOrdemDeServicoService
    {
        ConfirmacaoEmailViewModel GetDadosOrdemDeServicoParaEmail(string clienteId);
        List<OrdemDeServicoViewModel> GetOrdensDeServico(string clienteId);
        bool InserirOrdem(string clienteId, NovaOrdemDeServicoViewModel viewModel);
        bool verificarDisponibilidadeHorario(int servicoId, string data, int horarioId);
    }
}
