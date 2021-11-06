using System.Threading.Tasks;

namespace Recape.Services
{
    public interface IEmailService
    {
        Task<bool> EnviarEmailAsync(string emailDestino, string assunto, string corpo);
    }
}
