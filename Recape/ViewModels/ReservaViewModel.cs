using Microsoft.AspNetCore.Identity;
using Recape.Models;

namespace Recape.ViewModels
{
    public class ReservaViewModel
    {
        public int Id { get; set; }
        public IdentityUser Cliente { get; set; }
        public Poltrona Poltrona { get; set; }
        public string DataPartida { get; set; }
        public string HorarioPartida { get; set; }
    }
}
