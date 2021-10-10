namespace Recape.Models
{
    public class Medico
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public Especialidade Especialidade { get; set; }
        public int EspecialidadeId { get; set; }
    }
}