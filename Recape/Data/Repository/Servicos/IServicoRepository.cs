namespace Recape.Data.Repository.Servicos;

public interface IServicoRepository
{
    IQueryable<Servico> GetServicos();
    IQueryable<Servico> GetServicoPorId(int id);
}
