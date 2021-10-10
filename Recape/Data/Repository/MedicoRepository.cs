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

        public IQueryable<Medico> GetMedicos()
        {
            var results = dbContext.Medicos
                .Include(m => m.Especialidade);

            return results;
        }

        public Medico GetMedicoComEspecialidade(int medicoId)
        {
            var medico = dbContext.Medicos
                .Where(m => m.Id == medicoId)
                .Include(a => a.Especialidade)
                .FirstOrDefault();

            return medico;
        }
    }
}
