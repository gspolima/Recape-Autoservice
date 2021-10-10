using Microsoft.EntityFrameworkCore;
using Recape.Models;
using System.Linq;

namespace Recape.Data.Repository
{
    public class MedicoRepository : IMedicoRepository
    {
        private readonly RecapeDbContext dbContext;

        public MedicoRepository(RecapeDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IQueryable<MedicoInfo> GetMedicos()
        {
            var results = dbContext.Medicos
                .Include(m => m.Especialidade)
                .Select(m => new MedicoInfo()
                {
                    Id = m.Id,
                    Nome = m.Nome,
                    Especialidade = m.Especialidade.Nome
                });

            return results;
        }
    }
}
