using Recape.Models;
using Recape.ViewModels;
using System.Threading.Tasks;

namespace Recape.Services.Email
{
    public interface IEmailService
    {
        Task<bool> EnviarEmailAsync(EmailAutomatico email);
        string FormatarCorpoEmail(ConfirmacaoEmailViewModel dadosEmail);
    }
}
