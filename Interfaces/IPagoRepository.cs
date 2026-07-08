using SistemaGestionResidencial.Models;

namespace SistemaGestionResidencial.Interfaces
{
    public interface IPagoRepository : IRepository<Pago>
    {
        IEnumerable<Pago> ObtenerPagosPorContrato(int contratoId);
        bool PagoMesRegistrado(int contratoId, int mes, int anio);
    }
}
