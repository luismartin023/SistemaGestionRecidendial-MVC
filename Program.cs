using System;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SistemaGestionResidencial.Data;
using SistemaGestionResidencial.Forms;
using SistemaGestionResidencial.Services;

namespace SistemaGestionResidencial
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Configurar inyección de dependencias
            var services = new ServiceCollection();
            var connectionString = "Data Source=residencial.db";
            DependencyInjection.ConfigureServices(services, connectionString);

            var serviceProvider = services.BuildServiceProvider();

            // Inicializar base de datos
            using (var scope = serviceProvider.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<ResidencialDbContext>();
                DbInitializer.Initialize(context);
            }

            // Mostrar LoginForm
            var loginForm = serviceProvider.GetRequiredService<LoginForm>();
            Application.Run(loginForm);
        }
    }
}
