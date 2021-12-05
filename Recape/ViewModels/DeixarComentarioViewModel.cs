namespace Recape.ViewModels;

public class DeixarComentarioViewModel
{
    [Required(ErrorMessage = "Você precisa deixar um comentário para registrar a avaliação")]
    [MaxLength(200, ErrorMessage = "O comentário não pode ser maior que 200 caracteres")]
    public string TextoComentario { get; set; }

    public int ServicoId { get; set; }
    public string Servico { get; set; }
    public string Data { get; set; }
    public string Horario { get; set; }
}

