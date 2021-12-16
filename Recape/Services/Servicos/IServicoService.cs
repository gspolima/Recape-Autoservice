namespace Recape.Services.Servicos;

public interface IServicoService
{
    decimal GetValorPorServicoId(int id);
    TimeSpan GetTempoDeExecucaoPorServicoId(int servicoId);
    List<ServicoViewModel> GetListaDeServicos(string tipoVeiculo);
}

