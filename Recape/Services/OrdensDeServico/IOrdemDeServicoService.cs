using Recape.ViewModels;
using System.Collections.Generic;

namespace Recape.Services.OrdensDeServico
{
    public interface IOrdemDeServicoService
    {
        List<OrdemDeServicoViewModel> GetOrdensDeServico(string clienteId);
        bool InserirOrdem(string clienteId, NovaOrdemDeServicoViewModel viewModel);
    }
}
