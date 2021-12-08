namespace Recape.Data.Repository.Veiculos;

public class VeiculoRepository : IVeiculoRepository
{
    private readonly RecapeDbContext dbContext;

    public VeiculoRepository(RecapeDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public IQueryable<Veiculo> GetVeiculoPorPlaca(string placa)
    {
        var veiculo = dbContext.Veiculos
            .Where(v => v.Placa == placa);

        return veiculo;
    }

    public IQueryable<Veiculo> GetVeiculos()
    {
        return dbContext.Veiculos;
    }
}
