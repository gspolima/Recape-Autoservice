using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Recape.Models;

namespace Recape.Data
{
    public class RecapeDbContext : IdentityDbContext<IdentityUser>
    {
        public RecapeDbContext(DbContextOptions<RecapeDbContext> options)
            : base(options)
        {
        }

        public DbSet<Medico> Medicos { get; set; }
        public DbSet<Especialidade> Especialidades { get; set; }
        public DbSet<Agendamento> Agendamentos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Especialidade>()
                .Property(p => p.Nome)
                .IsRequired();

            builder.Entity<Medico>()
                .Property(p => p.Nome)
                .IsRequired();

            builder.Entity<Agendamento>()
                .Property(p => p.DataHorario)
                .IsRequired();

            builder.Entity<Agendamento>()
                .Property(p => p.PacienteId)
                .IsRequired();

            base.OnModelCreating(builder);
        }
    }
}
