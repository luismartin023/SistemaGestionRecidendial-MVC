using Microsoft.EntityFrameworkCore;
using SistemaGestionResidencial.Data;
using SistemaGestionResidencial.Interfaces;

namespace SistemaGestionResidencial.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly ResidencialDbContext _context;

        public Repository(ResidencialDbContext context)
        {
            _context = context;
        }

        public IEnumerable<T> ObtenerTodos()
        {
            return _context.Set<T>().ToList();
        }

        public T? ObtenerPorId(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public void Agregar(T entidad)
        {
            _context.Set<T>().Add(entidad);
            _context.SaveChanges();
        }

        public void Actualizar(T entidad)
        {
            _context.Set<T>().Update(entidad);
            _context.SaveChanges();
        }

        public void Eliminar(int id)
        {
            var entidad = ObtenerPorId(id);
            if (entidad != null)
            {
                _context.Set<T>().Remove(entidad);
                _context.SaveChanges();
            }
        }
    }
}
