using Microsoft.EntityFrameworkCore;
using SistemaGestionResidencial.Data;
using SistemaGestionResidencial.Interfaces;
using SistemaGestionResidencial.Models;

namespace SistemaGestionResidencial.Repositories
{
    public class ContratoRepository : Repository<Contrato>, IContratoRepository
    {
        public ContratoRepository(ResidencialDbContext context) : base(context) { }

        public IEnumerable<Contrato> ObtenerContratosActivos()
        {
            return _context.Contratos
                .Where(c => c.Estado == "Activo")
                .Include(c => c.Apartamento)
                .Include(c => c.Inquilino)
                .ToList();
        }

        public bool TieneContratoActivo(int apartamentoId)
        {
            return _context.Contratos
                .Any(c => c.ApartamentoId == apartamentoId && c.Estado == "Activo");
        }
    }
}
