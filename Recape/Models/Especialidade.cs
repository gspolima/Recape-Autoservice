using System.Collections.Generic;

namespace Recape.Models
{
    public class Especialidade
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public List<Medico> Medicos { get; set; }
    }
}