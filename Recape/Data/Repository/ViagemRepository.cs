using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Recape.Models;
using System.Linq;

namespace Recape.Data.Repository
{
    public class ViagemRepository : IViagemRepository
    {
        private readonly RecapeDbContext dbContext;
        private readonly ILogger<RecapeDbContext> logger;

        public ViagemRepository(
            ILogger<RecapeDbContext> logger,
            RecapeDbContext context)
        {
            this.dbContext = context;
            this.logger = logger;
        }

        public int InserirPoltronas()
        {
            var viagensCount = dbContext.Viagens.Count();
            var poltronasInseridas = 0;

            for (int i = 1; i <= viagensCount; i++)
            {
                var viagem = dbContext.Viagens
                    .Include(v => v.Poltronas)
                    .FirstOrDefault(v => v.Id == i);

                if (viagem.Poltronas.Count != 0)
                    return 0;

                for (byte p = 1; p <= 40; p++)
                {
                    viagem.Poltronas.Add(
                        new Poltrona()
                        {
                            Numero = p,
                            Disponivel = true,
                            ViagemId = viagem.Id
                        });
                }

                poltronasInseridas = dbContext.SaveChanges();

                if (poltronasInseridas == 40)
                    logger.Log(LogLevel.Information, $"Inseridas as poltronas para a viagem {viagem.Id}");
            }

            return poltronasInseridas;
        }
    }
}
