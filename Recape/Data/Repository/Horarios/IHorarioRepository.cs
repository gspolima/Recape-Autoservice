using Recape.Models;
using System.Linq;

namespace Recape.Data.Repository.Horarios
{
    public interface IHorarioRepository
    {
        public IQueryable<Horario> GetHorarios();
    }
}
