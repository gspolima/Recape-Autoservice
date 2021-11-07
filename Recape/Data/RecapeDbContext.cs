using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Recape.Models;
using System;
using System.Collections.Generic;

namespace Recape.Data
{
    public class RecapeDbContext : IdentityDbContext<IdentityUser>
    {
        private readonly IConfiguration configuration;
        private readonly ILogger<RecapeDbContext> logger;

        public RecapeDbContext(
            DbContextOptions<RecapeDbContext> options,
            IConfiguration configuration,
            ILogger<RecapeDbContext> logger) : base(options)
        {
            this.configuration = configuration;
            this.logger = logger;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(configuration.GetConnectionString("DbConnection"))
                    .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            }

            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Servico> Servicos { get; set; }
        public DbSet<OrdemDeServico> OrdensDeServico { get; set; }
        public DbSet<DataReservada> DatasReservadas { get; set; }

        // --------------------------------------------------

        public DbSet<Agendamento> Agendamentos { get; set; }
        public DbSet<Medico> Medicos { get; set; }
        public DbSet<Especialidade> Especialidades { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
        public DbSet<Viagem> Viagens { get; set; }
        public DbSet<Poltrona> Poltronas { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<DataReservada>()
                .Property(d => d.DataHorario)
                .HasPrecision(1)
                .IsRequired();

            builder.Entity<Servico>()
                .Property(s => s.Nome)
                .HasMaxLength(30)
                .IsRequired();

            builder.Entity<Servico>()
                .Property(s => s.Valor)
                .HasPrecision(7, 2)
                .IsRequired();

            builder.Entity<Servico>()
                .HasData(
                    new List<Servico>()
                    {
                        new Servico()
                        {
                            Id = 1,
                            Nome = "Troca de Óleo",
                            Valor = 249.99m
                        },
                        new Servico()
                        {
                            Id = 2,
                            Nome = "Alinhamento",
                            Valor = 129.99m
                        },
                        new Servico()
                        {
                            Id = 3,
                            Nome = "Funilaria",
                            Valor = 199.99m
                        },
                        new Servico()
                        {
                            Id = 4,
                            Nome = "Pintura",
                            Valor = 179.99m
                        },
                        new Servico()
                        {
                            Id = 5,
                            Nome = "Serviços de Reparo Geral",
                            Valor = 309.99m
                        }
                    }
                );

            // --------------------------------------------------

            builder.Entity<Agendamento>()
                .Property(p => p.DataHorario)
                .IsRequired();

            builder.Entity<Agendamento>()
                .Property(p => p.PacienteId)
                .IsRequired();

            builder.Entity<Especialidade>()
                .Property(p => p.Nome)
                .IsRequired();

            builder.Entity<Medico>()
                .Property(p => p.Nome)
                .IsRequired();

            builder.Entity<Viagem>()
                .Property(r => r.Origem)
                .HasMaxLength(40)
                .IsRequired();

            builder.Entity<Viagem>()
                .Property(r => r.Destino)
                .HasMaxLength(40)
                .IsRequired();

            builder.Entity<Viagem>()
                .Property(r => r.Preco)
                .IsRequired();

            builder.Entity<Viagem>()
                .Property(r => r.DataPartida)
                .IsRequired();

            builder.Entity<Viagem>()
                .Property(r => r.DuracaoEmHoras)
                .IsRequired();

            builder.Entity<Especialidade>()
                .HasData(
                    new Especialidade()
                    {
                        Id = 1,
                        Nome = "Pediatria"
                    },
                    new Especialidade()
                    {
                        Id = 2,
                        Nome = "Cardiologia"
                    },
                    new Especialidade()
                    {
                        Id = 4,
                        Nome = "Pneumologia"
                    },
                    new Especialidade()
                    {
                        Id = 5,
                        Nome = "Clínica Geral"
                    },
                    new Especialidade()
                    {
                        Id = 6,
                        Nome = "Oftalmologia"
                    },
                    new Especialidade()
                    {
                        Id = 7,
                        Nome = "Ortopedia"
                    }
                );

            builder.Entity<Medico>()
                .HasData(
                    new Medico()
                    {
                        Id = 1,
                        Nome = "Dra. Adama Cadaval",
                        EspecialidadeId = 1
                    },
                    new Medico()
                    {
                        Id = 2,
                        Nome = "Dr. Raúl Abelho",
                        EspecialidadeId = 2
                    },
                    new Medico()
                    {
                        Id = 3,
                        Nome = "Dr. Ismael Veleda",
                        EspecialidadeId = 4
                    },
                    new Medico()
                    {
                        Id = 4,
                        Nome = "Dr. Alberto Mourão",
                        EspecialidadeId = 2
                    },
                    new Medico()
                    {
                        Id = 5,
                        Nome = "Dr. Teófilo Saldanha",
                        EspecialidadeId = 6
                    },
                    new Medico()
                    {
                        Id = 6,
                        Nome = "Dr. Rúben Medeiros",
                        EspecialidadeId = 7
                    },
                    new Medico()
                    {
                        Id = 7,
                        Nome = "Dra. Adriana Rosário",
                        EspecialidadeId = 2
                    },
                    new Medico()
                    {
                        Id = 8,
                        Nome = "Dr. Arthur Nazário",
                        EspecialidadeId = 5
                    }
                );

            builder.Entity<Viagem>()
                .HasData(
                    new Viagem()
                    {
                        Id = 1,
                        Origem = "Fortaleza",
                        Destino = "Recife",
                        Preco = 120,
                        DataPartida = new DateTime(2021, 10, 25, 16, 20, 00),
                        DuracaoEmHoras = 28
                    },
                    new Viagem()
                    {
                        Id = 2,
                        Origem = "Fortaleza",
                        Destino = "Juazeiro do Norte",
                        Preco = 90,
                        DataPartida = new DateTime(2021, 10, 23, 06, 00, 00),
                        DuracaoEmHoras = 20
                    },
                    new Viagem()
                    {
                        Id = 3,
                        Origem = "Salvador",
                        Destino = "Belo Horizonte",
                        Preco = 100,
                        DataPartida = new DateTime(2021, 11, 02, 22, 30, 00),
                        DuracaoEmHoras = 24
                    },
                    new Viagem()
                    {
                        Id = 4,
                        Origem = "Porto Alegre",
                        Destino = "Brasília",
                        Preco = 180,
                        DataPartida = new DateTime(2021, 11, 05, 19, 00, 00),
                        DuracaoEmHoras = 36
                    }
                );

            base.OnModelCreating(builder);
        }
    }
}
