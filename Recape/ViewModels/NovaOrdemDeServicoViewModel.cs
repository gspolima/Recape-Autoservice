using Microsoft.AspNetCore.Mvc.Rendering;

namespace Recape.ViewModels;

public class NovaOrdemDeServicoViewModel : DataViewModel
{
    public SelectList Servicos { get; set; }

    [Required(ErrorMessage = "Um serviço deve ser selecionado")]
    public int ServicoId { get; set; }


    public SelectList TiposVeiculo { get; set; }

    [Required(ErrorMessage = "Um tipo de veículo deve ser selecionado")]
    public string TipoSelecionado { get; set; }

    public SelectList Horarios { get; set; }

    [Required(ErrorMessage = "Um horário deve ser selecionado")]
    public int HorarioId { get; set; }

    [Required(ErrorMessage = "Informe uma placa")]
    [StringLength(7, ErrorMessage = "A placa tem um máximo de {0} caracteres", MinimumLength = 7)]
    public string Placa { get; set; }

    [Required(ErrorMessage = "Inclua uma descrição breve do modelo")]
    [MaxLength(40, ErrorMessage = "Limite a descrição do modelo a {0} caracteres")]
    public string Modelo { get; set; }

    public string Valor { get; set; }

    public bool ExisteConflitoDeHorario { get; set; }

    public SelectList VeiculosCadastrados { get; set; }

    [Required(ErrorMessage = "Escolha um veículo")]
    public int VeiculoId { get; set; }

}
