using Recape.Models;
using System.Linq;

namespace Recape.Data.Repository.OrdensDeServico
{
    public class OrdemDeServicoRepository : IOrdemDeServicoRepository
    {
        private readonly RecapeDbContext dbContext;

        public OrdemDeServicoRepository(RecapeDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IQueryable<OrdemDeServico> GetOrdensPorCliente(string clienteId)
        {
            var ordens = dbContext.OrdensDeServico.Where(o =>
                o.ClienteId == clienteId);

            return ordens;
        }

        public bool Insert(OrdemDeServico ordemDeServico)
        {
            dbContext.OrdensDeServico.Add(ordemDeServico);
            var inseridos = dbContext.SaveChanges();

            return inseridos > 0;
        }
    }
}
