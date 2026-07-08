using SistemaGestionResidencial.Models;

namespace SistemaGestionResidencial.Interfaces
{
    public interface IApartamentoRepository : IRepository<Apartamento>
    {
        IEnumerable<Apartamento> ObtenerPorEstado(EstadoApartamento estado);
    }
}
