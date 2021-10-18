using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Recape.Models;
using System;
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

        public Viagem GetViagem(int viagemId)
        {
            var viagem = dbContext.Viagens
                .Where(v => v.Id == viagemId)
                .FirstOrDefault();

            return viagem;
        }

        public IQueryable<Viagem> GetViagens()
        {
            var viagens = dbContext.Viagens
                .Where(v => v.DataPartida > DateTime.Now);

            return viagens;
        }

        public int InserirPoltronas()
        {
            var viagensCount = dbContext.Viagens.Count();
            var poltronasInseridas = 0;

            for (int i = 1; i <= viagensCount; i++)
            {
                var viagem = dbContext.Viagens
                    .AsTracking()
                    .Include(v => v.Poltronas)
                    .FirstOrDefault(v => v.Id == i);

                if (viagem.Poltronas.Count != 0)
                    continue;

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

                if (poltronasInseridas == 40)
                    logger.Log(LogLevel.Information, $"Inseridas as poltronas para a viagem {viagem.Id}");
            }

            poltronasInseridas = dbContext.SaveChanges();

            return poltronasInseridas;
        }
    }
}
