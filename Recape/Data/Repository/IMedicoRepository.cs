using Recape.Models;
using System.Linq;

namespace Recape.Data.Repository
{
    public interface IMedicoRepository
    {
        IQueryable<MedicoInfo> GetMedicos();
    }
}
