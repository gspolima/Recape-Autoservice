using Recape.Models;
using System.Linq;

namespace Recape.Data.Repository
{
    public interface IReservaRepository
    {
        IQueryable<Reserva> GetReservas(string usuarioId);

        int CriarReserva(Reserva reserva);
    }
}
