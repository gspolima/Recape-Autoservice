using System;
using System.Collections.Generic;

namespace Recape
{
    public class Medico
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public List<Especialidade> Especialidade { get; set; }
    }
}