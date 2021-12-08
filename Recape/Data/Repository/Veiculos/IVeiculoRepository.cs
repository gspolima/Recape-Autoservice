namespace Recape.Data.Repository.Veiculos;

public interface IVeiculoRepository
{
    IQueryable<Veiculo> GetVeiculos();
    IQueryable<Veiculo> GetVeiculoPorPlaca(string placa);
}
