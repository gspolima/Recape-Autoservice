using Recape.Models;
using System.Linq;

namespace Recape.Data.Repository.Horarios
{
    public class HorarioRepository : IHorarioRepository
    {
        private readonly RecapeDbContext dbContext;

        public HorarioRepository(RecapeDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IQueryable<Horario> GetHorarios()
        {
            var horarios = dbContext.Horarios;
            return horarios;
        }
    }
}
