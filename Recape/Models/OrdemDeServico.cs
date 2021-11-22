﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Recape.Models
{
    public class OrdemDeServico
    {
        public int Id { get; set; }
        public DateOnly Data { get; set; }
        public bool Finalizado { get; set; }
        public bool Cancelado { get; set; }
        public string Total { get; set; }
        public Servico Servico { get; set; }
        public int ServicoId { get; set; }
        public IdentityUser Cliente { get; set; }
        public string ClienteId { get; set; }
        public Horario Horario { get; set; }
        public int HorarioId { get; set; }
        public List<Comentario> Comentarios { get; set; }
    }
}
