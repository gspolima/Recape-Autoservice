using Recape.Models;
using System.Linq;

namespace Recape.Data.Repository.Poltronas
{
    public interface IPoltronaRepository
    {
        IQueryable<Poltrona> GetPoltronas(int viagemId);
        Poltrona GetPoltrona(int poltronaId);
        int IndisponibilizarPoltrona(int poltronaId);
    }
}
