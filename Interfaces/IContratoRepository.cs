using SistemaGestionResidencial.Models;

namespace SistemaGestionResidencial.Interfaces
{
    public interface IContratoRepository : IRepository<Contrato>
    {
        IEnumerable<Contrato> ObtenerContratosActivos();
        bool TieneContratoActivo(int apartamentoId);
    }
}
