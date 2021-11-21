using Recape.Models;
using System;
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

        public bool Exists(int servicoId, System.DateOnly data, int horarioId)
        {
            var existe = dbContext.OrdensDeServico
                .Where(
                    o => o.ServicoId == servicoId &&
                    o.Data == data &&
                    o.HorarioId == horarioId)
                .Any();

            return existe;
        }

        public IQueryable<OrdemDeServico> GetOrdensPorCliente(string clienteId)
        {
            var ordens = dbContext.OrdensDeServico.Where(o =>
                o.ClienteId == clienteId);

            return ordens;
        }

        public IQueryable GetHorariosReservadosPorData(DateOnly data)
        {
            var ordens = dbContext.OrdensDeServico
                .Where(o => o.Data == data)
                .Select(o => new
                {
                    HorarioId = o.HorarioId
                });

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
