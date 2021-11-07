using Microsoft.EntityFrameworkCore;
using Recape.Data.Repository.OrdensDeServico;
using Recape.Models;
using Recape.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace Recape.Services.OrdensDeServico
{
    public class OrdemDeServiceService : IOrdemDeServicoService
    {
        private readonly IOrdemDeServicoRepository ordemRepository;

        public OrdemDeServiceService(IOrdemDeServicoRepository ordemRepository)
        {
            this.ordemRepository = ordemRepository;
        }

        public List<OrdemDeServicoViewModel> GetOrdensDeServico(string clienteId)
        {
            var viewModel = ordemRepository.GetOrdensPorCliente(clienteId)
                .Include(o => o.Servico)
                .Include(o => o.DataAgendada)
                .Select(o => new OrdemDeServicoViewModel()
                {
                    Id = o.Id,
                    Servico = o.Servico.Nome,
                    Valor = o.Servico.Valor,
                    Data = o.DataAgendada.DataHorario.Date.ToString("dd/MM/yyyy"),
                    Horario = o.DataAgendada.DataHorario.TimeOfDay.ToString("hh\\:mm")
                })
                .ToList();

            return viewModel;
        }

        public bool InserirOrdem(string clienteId, NovaOrdemDeServicoViewModel viewModel)
        {
            var ordem = new OrdemDeServico()
            {
                ClienteId = clienteId,
                ServicoId = viewModel.ServicoId,
                DataAgendada = new DataReservada()
                {
                    DataHorario = viewModel.GetDataHorario()
                }
            };

            var sucesso = ordemRepository.Insert(ordem);

            return sucesso;
        }
    }
}
