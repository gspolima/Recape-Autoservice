using Recape.Data.Repository.Veiculos;

namespace Recape.Services.Veiculos;

public class VeiculoService : IVeiculoService
{
    private readonly IVeiculoRepository veiculoRepository;

    public VeiculoService(IVeiculoRepository veiculoRepository)
    {
        this.veiculoRepository = veiculoRepository;
    }

    public List<VeiculoCadastradoViewModel> GetVeiculosPorProprietarioId(string proprietarioId)
    {
        var veiculos = veiculoRepository.GetVeiculos()
            .Where(v => v.ProprietarioId == proprietarioId)
            .Select(v => new VeiculoCadastradoViewModel
            {
                Id = v.Id,
                TipoModeloPlaca = $"{v.Tipo} {v.Modelo} - {v.Placa}"
            })
            .ToList();

        return veiculos;
    }

    public bool UsuarioTemVeiculoCadastrado(string proprietarioId)
    {
        var temVeiculo = veiculoRepository.GetVeiculos()
            .Any(v => v.ProprietarioId == proprietarioId);

        return temVeiculo;
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
