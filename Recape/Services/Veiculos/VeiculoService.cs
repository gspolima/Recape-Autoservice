using Recape.Data.Repository.Veiculos;

namespace Recape.Services.Veiculos;

public class VeiculoService : IVeiculoService
{
    private readonly IVeiculoRepository veiculoRepository;

    public VeiculoService(IVeiculoRepository veiculoRepository)
    {
        this.veiculoRepository = veiculoRepository;
    }

    public bool VeiculoExiste(string placa)
    {
        var existe = veiculoRepository.GetVeiculos()
            .Any(v => v.Placa == placa.ToUpper());

        return existe;
    }

    public bool VeiculoPertenceAoUsuario(string placa, string proprietarioId)
    {
        var pertence = veiculoRepository.GetVeiculoPorPlaca(placa)
            .Any(v => v.ProprietarioId == proprietarioId);

        return pertence;
    }
}
