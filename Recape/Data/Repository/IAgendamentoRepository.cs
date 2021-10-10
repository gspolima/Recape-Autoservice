using Recape.Models;
using System.Collections.Generic;

namespace Recape.Data.Repository
{
    public interface IAgendamentoRepository
    {
        List<Agendamento> GetAgendamentos(string usuarioId);

        bool CriarAgendamento(Agendamento agendamento);

        bool ExcluirAgendamento(int agendamentoId);
    }
}
