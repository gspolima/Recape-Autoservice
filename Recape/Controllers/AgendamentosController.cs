using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Recape.Controllers
{
    public class AgendamentosController : Controller
    {
        [Authorize]
        public IActionResult ListarAgendamentos()
        {
            return View();
        }
    }
}
