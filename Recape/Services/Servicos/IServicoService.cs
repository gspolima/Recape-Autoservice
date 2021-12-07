namespace Recape.Services.Servicos;

public interface IServicoService
{
    decimal GetValorPorServicoId(int id);
    List<ServicoViewModel> GetListaDeServicos(string tipoVeiculo);
}

