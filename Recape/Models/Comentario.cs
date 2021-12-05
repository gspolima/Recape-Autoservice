namespace Recape.Models;

public class Comentario
{
    public int Id { get; set; }
    public string Texto { get; set; }
    public OrdemDeServico OrdemDeServico { get; set; }
    public int OrdemDeServicoId { get; set; }
}
