using Recape.Models;
using System.Linq;

namespace Recape.Data.Repository.Servicos
{
    public interface IServicoRepository
    {
        IQueryable<Servico> GetServicos();
        decimal GetValorPorServicoId(int id);
    }
}
