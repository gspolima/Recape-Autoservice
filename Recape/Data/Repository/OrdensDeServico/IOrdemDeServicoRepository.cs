namespace Recape.Data.Repository.OrdensDeServico;

public interface IOrdemDeServicoRepository
{
    IQueryable<OrdemDeServico> GetOrdemPorId(int id);
    IQueryable<OrdemDeServico> GetOrdemPorCliente(string clienteId);
    IQueryable<OrdemDeServico> GetOrdensPorCliente(string clienteId);
    IQueryable GetHorariosReservadosPorData(DateOnly data);
    bool Insert(OrdemDeServico ordemDeServico);
    bool Exists(int servicoId, DateOnly data, int horarioId);
    IQueryable<OrdemDeServico> GetOrdensDeServicoPorVeiculoId(int veiculoId);
    bool Update(OrdemDeServico ordem);
}