using Recape.Models;
using System.Collections.Generic;
using System.Linq;

namespace Recape.Data.Repository.Especialidades
{
    public class EspecialidadeRepository : IEspecialidadeRepository
    {
        private readonly RecapeDbContext dbContext;

        public EspecialidadeRepository(RecapeDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<Especialidade> GetEspecialidades()
        {
            var results = dbContext.Especialidades.ToList();
            return results;
        }
    }
}
