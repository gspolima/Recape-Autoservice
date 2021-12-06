namespace Recape.Models;

public class Veiculo
{
    public string Placa { get; set; }
    public string Modelo { get; set; }
    public Usuario Proprietario { get; set; }
    public string ProprietarioId { get; set; }
}
