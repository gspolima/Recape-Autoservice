﻿using Recape.Models;
using System.Threading.Tasks;

namespace Recape.Services.Email
{
    public interface IEmailService
    {
        Task<bool> EnviarEmailAsync(EmailAutomatico email);
        string FormatarCorpoEmail(int id, string cliente, string dataHorario, string total, string servico);
    }
}
