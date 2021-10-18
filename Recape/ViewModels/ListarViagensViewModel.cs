namespace Recape.ViewModels
{
    public class ListarViagensViewModel
    {
        public int Id { get; set; }
        public string Origem { get; set; }
        public string Destino { get; set; }
        public double Preco { get; set; }
        public string DataSaida { get; set; }
        public string HorarioSaida { get; set; }
        public float DuracaoEmHoras { get; set; }
    }
}
