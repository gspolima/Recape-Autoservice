using Recape.Models;
using System.Linq;

namespace Recape.Data.Repository.Medicos
{
    public interface IMedicoRepository
    {
        IQueryable<MedicoInfo> GetMedicos();
    }
}
