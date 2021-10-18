using Recape.Models;
using System.Collections.Generic;

namespace Recape.ViewModels
{
    public class ListarPoltronasViewModel
    {
        public double PrecoUnitario { get; set; }
        public List<Poltrona> Poltronas { get; set; }
    }
}
