namespace Recape.Data.Repository.Servicos;

public class ServicoRepository : IServicoRepository
{
    private readonly RecapeDbContext dbContext;

    public ServicoRepository(RecapeDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public IQueryable<Servico> GetServicoPorId(int id)
    {
        var servico = dbContext.Servicos
            .Where(s => s.Id == id);

        return servico;
    }

    public IQueryable<Servico> GetServicos()
    {
        var servicos = dbContext.Servicos;

        return servicos;
    }
}
