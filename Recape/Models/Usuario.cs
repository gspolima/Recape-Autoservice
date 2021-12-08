namespace Recape.Models;

public class Usuario : IdentityUser
{
    [Required(ErrorMessage = "Preencha com seu nome")]
    [MaxLength(40, ErrorMessage = "Nome não pode ter mais que 40 caracteres")]
    public string NomeCompleto { get; set; }

    public List<Veiculo> Veiculos { get; set; } = new List<Veiculo>();
}
