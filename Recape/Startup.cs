using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Recape.Data;
using Recape.Data.Repository.AgendamentosConsulta;
using Recape.Data.Repository.Especialidades;
using Recape.Data.Repository.Medicos;
using Recape.Data.Repository.OrdensDeServico;
using Recape.Data.Repository.Poltronas;
using Recape.Data.Repository.Reservas;
using Recape.Data.Repository.Servicos;
using Recape.Data.Repository.Viagens;
using Recape.Services.Email;
using Recape.Services.OrdensDeServico;
using System;

namespace Recape
{
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
                        new[]
                        {
                            DbLoggerCategory.Database.Command.Name
                        },
                        LogLevel.Information);
            });

            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddSingleton<IEmailService, EmailService>();

            services.AddScoped<IOrdemDeServicoRepository, OrdemDeServicoRepository>();
            services.AddScoped<IOrdemDeServicoService, OrdemDeServiceService>();
            services.AddScoped<IServicoRepository, ServicoRepository>();
            services.AddScoped<IPoltronaRepository, PoltronaRepository>();
            services.AddScoped<IViagemRepository, ViagemRepository>();
            services.AddScoped<IMedicoRepository, MedicoRepository>();
            services.AddScoped<IAgendamentoRepository, AgendamentoRepository>();
            services.AddScoped<IEspecialidadeRepository, EspecialidadeRepository>();
            services.AddScoped<IReservaRepository, ReservaRepository>();

            services.AddDefaultIdentity<IdentityUser>(options =>
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(50))
                .AddEntityFrameworkStores<RecapeDbContext>();

            services.Configure<IdentityOptions>(options =>
                {
                    options.Password.RequiredLength = 8;
                    options.Password.RequireDigit = true;
                    options.User.RequireUniqueEmail = true;
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
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
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
}
