using Recape.Models;
using System.Linq;

namespace Recape.Data.Repository
{
    public interface IPoltronaRepository
    {
        IQueryable<Poltrona> GetPoltronas(int viagemId);
    }
}
