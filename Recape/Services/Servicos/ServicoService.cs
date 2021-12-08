using Recape.Data.Repository.Servicos;

namespace Recape.Services.Servicos;

public class ServicoService : IServicoService
{
    private readonly IServicoRepository servicoRepository;

    public ServicoService(IServicoRepository servicoRepository)
    {
        this.servicoRepository = servicoRepository;
    }

    public decimal GetValorPorServicoId(int id)
    {
        var valor = servicoRepository.GetServicos()
            .Where(s => s.Id == id)
            .Select(s => new { Valor = s.Valor })
            .FirstOrDefault();

        return valor.Valor;
    }

    public List<ServicoViewModel> GetListaDeServicos(string tipoVeiculo)
    {
        List<ServicoViewModel> lista;

        if (tipoVeiculo == "Moto")
        {
            lista = servicoRepository.GetServicos()
                .Where(s => s.Nome != "Alinhamento")
                .Select(s => new ServicoViewModel
                {
                    Id = s.Id,
                    Nome = s.Nome
                })
                .OrderBy(s => s.Nome)
                .ToList();

            return lista;
        }

        lista = servicoRepository.GetServicos()
            .Select(s => new ServicoViewModel
            {
                Id = s.Id,
                Nome = s.Nome
            })
            .OrderBy(s => s.Nome)
            .ToList();

        return lista;
    }
}

