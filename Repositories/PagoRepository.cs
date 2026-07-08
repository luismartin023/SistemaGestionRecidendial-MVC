using Microsoft.EntityFrameworkCore;
using SistemaGestionResidencial.Data;
using SistemaGestionResidencial.Interfaces;
using SistemaGestionResidencial.Models;

namespace SistemaGestionResidencial.Repositories
{
    public class PagoRepository : Repository<Pago>, IPagoRepository
    {
        public PagoRepository(ResidencialDbContext context) : base(context) { }

        public IEnumerable<Pago> ObtenerPagosPorContrato(int contratoId)
        {
            return _context.Pagos
                .Where(p => p.ContratoId == contratoId)
                .Include(p => p.Contrato)
                .ToList();
        }

        public bool PagoMesRegistrado(int contratoId, int mes, int anio)
        {
            return _context.Pagos
                .Any(p => p.ContratoId == contratoId && p.FechaPago.Month == mes && p.FechaPago.Year == anio);
        }
    }
}
