using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Recape.Data;

public class RecapeDbContext : IdentityDbContext<Usuario>
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

    public RecapeDbContext(DbContextOptions<RecapeDbContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var serverVersion = new MySqlServerVersion(new Version(5, 7, 32));
            var connection = configuration.GetConnectionString("DbConnection");

            optionsBuilder
                .UseMySql(connection, serverVersion)
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                .LogTo(
                    Console.WriteLine,
                    new[]
                    {
                            DbLoggerCategory.Database.Command.Name
                    },
                    LogLevel.Information)
                .EnableDetailedErrors();
        }

        base.OnConfiguring(optionsBuilder);
    }

    public DbSet<Servico> Servicos { get; set; }
    public DbSet<OrdemDeServico> OrdensDeServico { get; set; }
    public DbSet<Horario> Horarios { get; set; }
    public DbSet<Comentario> Comentarios { get; set; }

    // --------------------------------------------------

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Comentario>()
            .Property(c => c.Texto)
            .HasMaxLength(200)
            .IsRequired();

        builder.Entity<OrdemDeServico>()
            .Property(o => o.Data)
            .IsRequired();

        builder.Entity<OrdemDeServico>()
            .Property(o => o.Status)
            .HasConversion<string>();

        builder.Entity<Horario>()
            .Property(d => d.HoraDoDia)
            .IsRequired();

        builder.Entity<Horario>()
            .HasData(
                new List<Horario>()
                {
                        new Horario()
                        {
                            Id = 1,
                            HoraDoDia = new TimeOnly(8, 0)
                        },
                        new Horario()
                        {
                            Id = 2,
                            HoraDoDia = new TimeOnly(9, 0)
                        },
                        new Horario()
                        {
                            Id = 3,
                            HoraDoDia = new TimeOnly(10, 0)
                        },
                        new Horario()
                        {
                            Id = 4,
                            HoraDoDia = new TimeOnly(11, 0)
                        },
                        new Horario()
                        {
                            Id = 5,
                            HoraDoDia = new TimeOnly(12, 0)
                        },
                        new Horario()
                        {
                            Id = 6,
                            HoraDoDia = new TimeOnly(13, 0)
                        },
                        new Horario()
                        {
                            Id = 7,
                            HoraDoDia = new TimeOnly(14, 0)
                        },
                        new Horario()
                        {
                            Id = 8,
                            HoraDoDia = new TimeOnly(15, 0)
                        },
                        new Horario()
                        {
                            Id = 9,
                            HoraDoDia = new TimeOnly(16, 0)
                        },
                        new Horario()
                        {
                            Id = 10,
                            HoraDoDia = new TimeOnly(17, 0)
                        },
                }
            );

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


    }
}
