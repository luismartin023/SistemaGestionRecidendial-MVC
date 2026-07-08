using SistemaGestionResidencial.Interfaces;
using SistemaGestionResidencial.Models;

namespace SistemaGestionResidencial.Controllers
{
    public class PagoController
    {
        private readonly IPagoRepository _pagoRepo;

        public PagoController(IPagoRepository pagoRepo)
        {
            _pagoRepo = pagoRepo;
        }

        public IEnumerable<Pago> Listar()
        {
            return _pagoRepo.ObtenerTodos();
        }

        public IEnumerable<Pago> ObtenerPagosPorContrato(int contratoId)
        {
            return _pagoRepo.ObtenerPagosPorContrato(contratoId);
        }

        public void Agregar(Pago pago)
        {
            // Validar que no exista pago del mes
            if (_pagoRepo.PagoMesRegistrado(pago.ContratoId, pago.FechaPago.Month, pago.FechaPago.Year))
            {
                throw new ArgumentException("Ya existe un pago registrado para este mes");
            }

            _pagoRepo.Agregar(pago);
        }

        public void Actualizar(Pago pago)
        {
            _pagoRepo.Actualizar(pago);
        }

        public void Eliminar(int id)
        {
            _pagoRepo.Eliminar(id);
        }
    }
}
