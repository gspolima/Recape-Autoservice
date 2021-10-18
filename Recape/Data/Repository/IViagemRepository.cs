using Recape.Models;
using System.Linq;

namespace Recape.Data.Repository
{
    public interface IViagemRepository
    {
        int InserirPoltronas();

        IQueryable<Viagem> GetViagens();

        Viagem GetViagem(int viagemId);
    }
}
