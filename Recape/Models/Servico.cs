namespace Recape.Models;

public class Servico
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public decimal Valor { get; set; }
    public TimeSpan TempoDeExecucao { get; set; }
}
