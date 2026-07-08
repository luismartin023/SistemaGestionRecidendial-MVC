using Microsoft.EntityFrameworkCore;
using SistemaGestionResidencial.Data;
using SistemaGestionResidencial.Interfaces;
using SistemaGestionResidencial.Models;

namespace SistemaGestionResidencial.Repositories
{
    public class InquilinoRepository : Repository<Inquilino>, IInquilinoRepository
    {
        public InquilinoRepository(ResidencialDbContext context) : base(context) { }

        public IEnumerable<Inquilino> BuscarPorNombre(string nombre)
        {
            return _context.Inquilinos
                .Where(i => i.Nombre.Contains(nombre) || i.Apellido.Contains(nombre))
                .Include(i => i.Contratos)
                .ToList();
        }

        public Inquilino? BuscarPorDocumento(string numero)
        {
            return _context.Inquilinos
                .Include(i => i.Contratos)
                .FirstOrDefault(i => i.NumeroDocumento == numero);
        }
    }
}
