using SistemaGestionResidencial.Interfaces;
using SistemaGestionResidencial.Models;

namespace SistemaGestionResidencial.Controllers
{
    public class ContratoController
    {
        private readonly IContratoRepository _contratoRepo;

        public ContratoController(IContratoRepository contratoRepo)
        {
            _contratoRepo = contratoRepo;
        }

        public IEnumerable<Contrato> Listar()
        {
            return _contratoRepo.ObtenerTodos();
        }

        public IEnumerable<Contrato> ObtenerContratosActivos()
        {
            return _contratoRepo.ObtenerContratosActivos();
        }

        public void Agregar(Contrato contrato)
        {
            // Validar duración mínima de 1 año
            if ((contrato.FechaFin - contrato.FechaInicio).TotalDays < 365)
            {
                throw new ArgumentException("El contrato debe tener una duración mínima de 1 año");
            }

            // Validar que el apartamento no tenga contrato activo
            if (_contratoRepo.TieneContratoActivo(contrato.ApartamentoId))
            {
                throw new ArgumentException("El apartamento ya tiene un contrato activo");
            }

            _contratoRepo.Agregar(contrato);
        }

        public void Actualizar(Contrato contrato)
        {
            _contratoRepo.Actualizar(contrato);
        }

        public void Eliminar(int id)
        {
            _contratoRepo.Eliminar(id);
        }
    }
}
