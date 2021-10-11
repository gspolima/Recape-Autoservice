using Microsoft.EntityFrameworkCore;
using Recape.Models;
using System.Linq;

namespace Recape.Data.Repository
{
    public class ReservaRepository : IReservaRepository
    {
        private readonly RecapeDbContext dbContext;

        public ReservaRepository(RecapeDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public int CriarReserva(Reserva reserva)
        {
            dbContext.Add(reserva);
            var registrosCriados = dbContext.SaveChanges();
            return registrosCriados;
        }

        public IQueryable<Reserva> GetReservas(string usuarioId)
        {
            var results = dbContext.Reservas
                .Where(r => r.ClienteId == usuarioId)
                .Include(r => r.Cliente)
                .Include(r => r.Poltrona)
                .Include(r => r.Poltrona.Viagem);

            return results;
        }
    }
}
