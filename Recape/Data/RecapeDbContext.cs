using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Recape.Models;

namespace Recape.Data
{
    public class RecapeDbContext : IdentityDbContext<IdentityUser>
    {
        private readonly IConfiguration configuration;

        public RecapeDbContext(
            DbContextOptions<RecapeDbContext> options,
            IConfiguration configuration)
            : base(options)
        {
            this.configuration = configuration;
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

        public DbSet<Agendamento> Agendamentos { get; set; }
        public DbSet<Medico> Medicos { get; set; }
        public DbSet<Especialidade> Especialidades { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
        public DbSet<Viagem> Viagens { get; set; }
        public DbSet<Poltrona> Poltronas { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
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

            base.OnModelCreating(builder);
        }
    }
}
