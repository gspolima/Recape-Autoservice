using Recape.Models;
using System.Linq;

namespace Recape.Data.Repository.OrdensDeServico
{
    public interface IOrdemDeServicoRepository
    {
        IQueryable<OrdemDeServico> GetOrdensPorCliente(string clienteId);
        bool Insert(OrdemDeServico ordemDeServico);
    }
}
