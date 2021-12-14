namespace Recape.Services.Veiculos;

public interface IVeiculoService
{
    List<VeiculoCadastradoViewModel> GetVeiculosPorProprietarioId(string proprietarioId);
    bool UsuarioTemVeiculoCadastrado(string proprietarioId);
    bool VeiculoExiste(string placa);
    bool VeiculoPertenceAoUsuario(string placa, string proprietarioId);
}
