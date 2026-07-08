using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SistemaGestionResidencial.Data;
using SistemaGestionResidencial.Interfaces;
using SistemaGestionResidencial.Repositories;
using SistemaGestionResidencial.Controllers;

namespace SistemaGestionResidencial.Services
{
    public static class DependencyInjection
    {
        public static IServiceCollection ConfigureServices(IServiceCollection services, string connectionString)
        {
            // DbContext
            services.AddDbContext<ResidencialDbContext>(options =>
                options.UseSqlite(connectionString));

            // Repositories
            services.AddScoped<IRepository<Apartamento>, ApartamentoRepository>();
            services.AddScoped<IApartamentoRepository, ApartamentoRepository>();
            services.AddScoped<IRepository<Inquilino>, InquilinoRepository>();
            services.AddScoped<IInquilinoRepository, InquilinoRepository>();
            services.AddScoped<IRepository<Contrato>, ContratoRepository>();
            services.AddScoped<IContratoRepository, ContratoRepository>();
            services.AddScoped<IRepository<Pago>, PagoRepository>();
            services.AddScoped<IPagoRepository, PagoRepository>();

            // Controllers
            services.AddScoped<ApartamentoController>();
            services.AddScoped<InquilinoController>();
            services.AddScoped<ContratoController>();
            services.AddScoped<PagoController>();
            services.AddScoped<AuthController>();
            services.AddScoped<DashboardController>();

            return services;
        }
    }
}
