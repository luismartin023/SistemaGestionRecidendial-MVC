using SistemaGestionResidencial.Interfaces;
using SistemaGestionResidencial.Models;

namespace SistemaGestionResidencial.Controllers
{
    public class ApartamentoController
    {
        private readonly IApartamentoRepository _apartamentoRepo;

        public ApartamentoController(IApartamentoRepository apartamentoRepo)
        {
            _apartamentoRepo = apartamentoRepo;
        }

        public IEnumerable<Apartamento> Listar()
        {
            return _apartamentoRepo.ObtenerTodos();
        }

        public IEnumerable<Apartamento> BuscarPorEstado(EstadoApartamento estado)
        {
            return _apartamentoRepo.ObtenerPorEstado(estado);
        }

        public void Agregar(Apartamento apartamento)
        {
            _apartamentoRepo.Agregar(apartamento);
        }

        public void Actualizar(Apartamento apartamento)
        {
            _apartamentoRepo.Actualizar(apartamento);
        }

        public void Eliminar(int id)
        {
            _apartamentoRepo.Eliminar(id);
        }
    }
}
