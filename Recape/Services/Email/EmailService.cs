using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;

namespace Recape.Services.Email
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration configuration;

        public EmailService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task<bool> EnviarEmailAsync(string emailDestino, string assunto, string corpo)
        {
            // API Key should be defined in appsettings.json
            // OR
            // set in Application settings on Azure App Services
            var apiKey = configuration.GetValue<string>("SendGrid:SENDGRID_API_KEY");
            var client = new SendGridClient(apiKey);

            var from = new EmailAddress("sampaioglima@gmail.com", "ReCarPe Autopeças");
            var subject = $"{assunto}";
            var to = new EmailAddress(emailDestino);
            var plainTextContent = "Esta mensagem deve ser visualizada em HTML";
            var htmlContent = $"<strong>{corpo}</strong>";

            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);

            return response.IsSuccessStatusCode;
        }
    }
}
