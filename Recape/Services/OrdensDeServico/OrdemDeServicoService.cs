using Microsoft.EntityFrameworkCore;
using Recape.Data.Repository.OrdensDeServico;
using Recape.Models;
using Recape.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Recape.Services.OrdensDeServico
{
    public class OrdemDeServicoService : IOrdemDeServicoService
    {
        private readonly IOrdemDeServicoRepository ordemRepository;

        public OrdemDeServicoService(IOrdemDeServicoRepository ordemRepository)
        {
            this.ordemRepository = ordemRepository;
        }

        public List<OrdemDeServicoViewModel> GetOrdensDeServico(string clienteId)
        {
            var viewModel = ordemRepository.GetOrdensPorCliente(clienteId)
                .Include(o => o.Servico)
                .Include(o => o.Horario)
                .Select(o => new OrdemDeServicoViewModel()
                {
                    Id = o.Id,
                    Servico = o.Servico.Nome,
                    Valor = o.Servico.Valor,
                    Data = o.Data.ToString("dd/MM/yyyy"),
                    Horario = o.Horario.HoraDoDia.ToString("hh:mm")
                })
                .ToList();

            return viewModel;
        }

        public bool InserirOrdem(string clienteId, NovaOrdemDeServicoViewModel viewModel)
        {
            var ordem = new OrdemDeServico()
            {
                ClienteId = clienteId,
                Data = viewModel.GetData(),
                ServicoId = viewModel.ServicoId,
                HorarioId = viewModel.HorarioId
            };

            var sucesso = ordemRepository.Insert(ordem);

            return sucesso;
        }

        public bool verificarDisponibilidadeHorario(int servicoId, string data, int horarioId)
        {
            var dataFormatada = DateOnly.ParseExact(data, "yyyy-MM-dd");
            var existe = ordemRepository.Exists(servicoId, dataFormatada, horarioId);

            return existe;
        }
    }
}
