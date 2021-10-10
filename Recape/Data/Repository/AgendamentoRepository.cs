using Microsoft.EntityFrameworkCore;
using Recape.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Recape.Data.Repository
{
    public class AgendamentoRepository : IAgendamentoRepository
    {
        private readonly RecapeDbContext dbContext;

        public AgendamentoRepository(RecapeDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<Agendamento> GetAgendamentos(string usuarioId)
        {
            var results = dbContext.Agendamentos
                .Where(a => a.PacienteId == usuarioId && a.DataHorario >= DateTime.Today)
                .Include(a => a.Paciente)
                .Include(a => a.Medico)
                .Include(a => a.Medico.Especialidade)
                .OrderBy(a => a.DataHorario)
                .ThenBy(a => a.Id)
                .ToList();

            return results;
        }



        public bool CriarAgendamento(Agendamento agendamento)
        {
            dbContext.Add(agendamento);
            var registrosInseridos = dbContext.SaveChanges();
            return registrosInseridos == 1 ? true : false;
        }

        public bool ExcluirAgendamento(int agendamentoId)
        {
            var registrosDeletados = 0;
            var agendamento = dbContext.Agendamentos
                .Where(a => a.Id == agendamentoId)
                .FirstOrDefault();

            if (agendamento != null)
            {
                dbContext.Remove(agendamento);
                registrosDeletados = dbContext.SaveChanges();
            }

            return registrosDeletados == 1 ? true : false;
        }

    }
}
