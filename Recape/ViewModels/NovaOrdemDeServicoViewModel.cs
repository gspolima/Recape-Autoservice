using Microsoft.AspNetCore.Mvc.Rendering;

namespace Recape.ViewModels;

public class NovaOrdemDeServicoViewModel : DataViewModel
{
    public SelectList Servicos { get; set; }

    [Required(ErrorMessage = "Um serviço deve ser selecionado")]
    public int ServicoId { get; set; }

    public SelectList TiposVeiculo { get; set; }

    public string TipoSelecionado { get; set; }

    public SelectList Horarios { get; set; }

    [Required(ErrorMessage = "Um horário deve ser selecionado")]
    public int HorarioId { get; set; }

    [StringLength(7, ErrorMessage = "A placa tem um máximo de {0} caracteres")]
    public string Placa { get; set; }

    [MaxLength(40, ErrorMessage = "Limite a descrição do modelo a {0} caracteres")]
    public string Modelo { get; set; }

    public string Valor { get; set; }

    public bool ExisteConflitoDeHorario { get; set; }

    public SelectList VeiculosCadastrados { get; set; }

    public int VeiculoId { get; set; }

}
