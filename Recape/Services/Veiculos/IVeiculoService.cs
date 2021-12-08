namespace Recape.Services.Veiculos;

public interface IVeiculoService
{
    bool VeiculoExiste(string placa);
    bool VeiculoPertenceAoUsuario(string placa, string proprietarioId);
}
