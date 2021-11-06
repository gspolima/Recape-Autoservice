using Microsoft.EntityFrameworkCore;
using Recape.Models;
using System.Linq;

namespace Recape.Data.Repository.Poltronas
{
    public class PoltronaRepository : IPoltronaRepository
    {
        private readonly RecapeDbContext dbContext;

        public PoltronaRepository(RecapeDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Poltrona GetPoltrona(int poltronaId)
        {
            return dbContext.Poltronas
                .Where(p => p.Id == poltronaId)
                .FirstOrDefault();
        }

        public IQueryable<Poltrona> GetPoltronas(int viagemId)
        {
            var poltronas = dbContext.Poltronas
                .Where(p => p.ViagemId == viagemId);

            return poltronas;
        }

        public int IndisponibilizarPoltrona(int poltronaId)
        {
            var poltrona = GetPoltrona(poltronaId);
            poltrona.Disponivel = false;
            dbContext.Entry(poltrona).State = EntityState.Modified;
            var atualizado = dbContext.SaveChanges();

            return atualizado;
        }
    }
}
