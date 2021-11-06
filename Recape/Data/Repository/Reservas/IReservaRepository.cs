using Recape.Models;
using System.Collections.Generic;
using System.Linq;

namespace Recape.Data.Repository.Reservas
{
    public interface IReservaRepository
    {
        IQueryable<Reserva> GetReservas(string usuarioId);

        int CriarReserva(Reserva reserva);

        int CriarReservas(List<Reserva> reservas);
    }
}
