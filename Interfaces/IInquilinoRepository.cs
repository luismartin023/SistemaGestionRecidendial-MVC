using SistemaGestionResidencial.Models;

namespace SistemaGestionResidencial.Interfaces
{
    public interface IInquilinoRepository : IRepository<Inquilino>
    {
        IEnumerable<Inquilino> BuscarPorNombre(string nombre);
        Inquilino? BuscarPorDocumento(string numero);
    }
}
