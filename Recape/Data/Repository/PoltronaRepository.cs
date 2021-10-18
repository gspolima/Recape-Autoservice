using Recape.Models;
using System.Linq;

namespace Recape.Data.Repository
{
    public class PoltronaRepository : IPoltronaRepository
    {
        private readonly RecapeDbContext dbContext;

        public PoltronaRepository(RecapeDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IQueryable<Poltrona> GetPoltronas(int viagemId)
        {
            var poltronas = dbContext.Poltronas
                .Where(p => p.ViagemId == viagemId);

            return poltronas;
        }
    }
}
