using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Recape.ViewModels;

namespace Recape.Controllers
{
    public class AgendamentosController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;

        public AgendamentosController(UserManager<IdentityUser> userManager)
        {
            this.userManager = userManager;
        }

        [Authorize]
        public IActionResult ListarAgendamentos()
        {
            var userId = userManager.GetUserId(User);
            var viewModel = new AgendamentosViewModel()
            {
                UserId = userId
            };

            return View(viewModel);
        }
    }
}
