using Recape.Data;
using Recape.Data.Repository.Comentarios;
using Recape.Data.Repository.Horarios;
using Recape.Data.Repository.OrdensDeServico;
using Recape.Data.Repository.Servicos;
using Recape.Data.Repository.Veiculos;
using Recape.Services.Email;
using Recape.Services.OrdensDeServico;
using Recape.Services.Servicos;
using Recape.Services.Veiculos;

namespace Recape;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
        var serverVersion = new MySqlServerVersion(new Version(5, 7, 32));
        var connection = Configuration.GetConnectionString("DbConnection");

        services.AddDbContext<RecapeDbContext>(options =>
        {
            options
                .UseMySql(connection, serverVersion)
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                .EnableSensitiveDataLogging()
                .LogTo(
                    Console.WriteLine,
                    LogLevel.Information);
        });

        services.AddDatabaseDeveloperPageExceptionFilter();

        services.AddScoped<IComentarioRepository, ComentarioRepository>();

        services.AddSingleton<IEmailService, EmailService>();

        services.AddScoped<IHorarioRepository, HorarioRepository>();

        services.AddScoped<IOrdemDeServicoRepository, OrdemDeServicoRepository>();
        services.AddScoped<IOrdemDeServicoService, OrdemDeServicoService>();

        services.AddScoped<IServicoRepository, ServicoRepository>();
        services.AddScoped<IServicoService, ServicoService>();

        services.AddScoped<IVeiculoRepository, VeiculoRepository>();
        services.AddScoped<IVeiculoService, VeiculoService>();

        services.AddDefaultIdentity<Usuario>()
            .AddEntityFrameworkStores<RecapeDbContext>();

        services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequiredLength = 8;
                options.Password.RequireDigit = false;
                options.User.RequireUniqueEmail = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Lockout.AllowedForNewUsers = false;
            }
        );

        services.AddControllersWithViews();
        services.AddRazorPages();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseDeveloperExceptionPage();
        if (env.IsDevelopment())
        {
            app.UseMigrationsEndPoint();
        }
        else
        {
            //app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }
        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthentication();
        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            endpoints.MapRazorPages();
        });
    }
}
