using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Recape.Data
{
    public class RecapeDbContext : IdentityDbContext<IdentityUser>
    {
        public RecapeDbContext(DbContextOptions<RecapeDbContext> options)
            : base(options)
        {
        }

        public DbSet<Especialidade> Especialidades { get; set; }
        public DbSet<Medico> Medicos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Especialidade>()
                .Property(p => p.Nome)
                .IsRequired();

            builder.Entity<Medico>()
                .Property(p => p.Nome)
                .IsRequired();

            base.OnModelCreating(builder);
        }
    }
}
