using SistemaGestionResidencial.Interfaces;
using SistemaGestionResidencial.Models;

namespace SistemaGestionResidencial.Controllers
{
    public class InquilinoController
    {
        private readonly IInquilinoRepository _inquilinoRepo;

        public InquilinoController(IInquilinoRepository inquilinoRepo)
        {
            _inquilinoRepo = inquilinoRepo;
        }

        public IEnumerable<Inquilino> Listar()
        {
            return _inquilinoRepo.ObtenerTodos();
        }

        public IEnumerable<Inquilino> BuscarPorNombre(string nombre)
        {
            return _inquilinoRepo.BuscarPorNombre(nombre);
        }

        public Inquilino? BuscarPorDocumento(string numero)
        {
            return _inquilinoRepo.BuscarPorDocumento(numero);
        }

        public void Agregar(Inquilino inquilino)
        {
            _inquilinoRepo.Agregar(inquilino);
        }

        public void Actualizar(Inquilino inquilino)
        {
            _inquilinoRepo.Actualizar(inquilino);
        }

        public void Eliminar(int id)
        {
            _inquilinoRepo.Eliminar(id);
        }
    }
}
