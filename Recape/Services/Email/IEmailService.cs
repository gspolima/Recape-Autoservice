using Recape.Models;
using Recape.ViewModels;

namespace Recape.Services.Email;

public interface IEmailService
{
    Task<bool> EnviarEmailAsync(EmailAutomatico email);
    string FormatarCorpoEmail(ConfirmacaoEmailViewModel dadosEmail);
}
