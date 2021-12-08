namespace Recape.Models;

public class OrdemDeServico
{
    public int Id { get; set; }
    public DateOnly Data { get; set; }
    public Situacao Status { get; set; }
    public string Total { get; set; }
    public Veiculo Veiculo { get; set; }
    public string VeiculoId { get; set; }
    public Servico Servico { get; set; }
    public int ServicoId { get; set; }
    public Usuario Cliente { get; set; }
    public string ClienteId { get; set; }
    public Horario Horario { get; set; }
    public int HorarioId { get; set; }
}
