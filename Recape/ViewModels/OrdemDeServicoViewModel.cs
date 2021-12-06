namespace Recape.ViewModels;
public class OrdemDeServicoViewModel
{
    public int Id { get; set; }
    public string Servico { get; set; }
    public decimal Valor { get; set; }
    public string Data { get; set; }
    public string Horario { get; set; }
    public Situacao Status { get; set; }
}
