using Microsoft.EntityFrameworkCore;
using SistemaGestionResidencial.Data;
using SistemaGestionResidencial.Interfaces;
using SistemaGestionResidencial.Models;

namespace SistemaGestionResidencial.Repositories
{
    public class ApartamentoRepository : Repository<Apartamento>, IApartamentoRepository
    {
        public ApartamentoRepository(ResidencialDbContext context) : base(context) { }

        public IEnumerable<Apartamento> ObtenerPorEstado(EstadoApartamento estado)
        {
            return _context.Apartamentos
                .Where(a => a.Estado == estado)
                .Include(a => a.Contratos)
                .ToList();
        }
    }
}
