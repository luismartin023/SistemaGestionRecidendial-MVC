using SistemaGestionResidencial.Data;
using SistemaGestionResidencial.Models;

namespace SistemaGestionResidencial.Controllers
{
    public class DashboardController
    {
        private readonly ResidencialDbContext _context;

        public DashboardController(ResidencialDbContext context)
        {
            _context = context;
        }

        public object ObtenerMetricasAdmin()
        {
            return new
            {
                TotalApartamentos = _context.Apartamentos.Count(),
                ApartamentosDisponibles = _context.Apartamentos.Count(a => a.Estado == EstadoApartamento.Disponible),
                ContratosActivos = _context.Contratos.Count(c => c.Estado == "Activo"),
                PagosMes = _context.Pagos.Count(p => p.FechaPago.Month == DateTime.Now.Month && p.FechaPago.Year == DateTime.Now.Year)
            };
        }

        public object ObtenerMetricasRecepcionista()
        {
            return new
            {
                PagosPendientes = _context.Contratos.Count(c => c.Estado == "Activo"),
                ContratosProximosVencer = _context.Contratos.Count(c => c.FechaFin < DateTime.Now.AddDays(30) && c.Estado == "Activo")
            };
        }

        public object ObtenerMetricasUsuario(int usuarioId)
        {
            var usuario = _context.Usuarios.Find(usuarioId);
            if (usuario == null || usuario.InquilinoId == null)
            {
                return new { Error = "Usuario no válido" };
            }

            var contrato = _context.Contratos.FirstOrDefault(c => c.InquilinoId == usuario.InquilinoId && c.Estado == "Activo");
            var pagos = _context.Pagos.Where(p => p.ContratoId == contrato?.Id).ToList();

            return new
            {
                Contrato = contrato,
                Pagos = pagos
            };
        }
    }
}
