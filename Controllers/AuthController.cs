using SistemaGestionResidencial.Data;
using SistemaGestionResidencial.Models;
using System.Security.Cryptography;
using System.Text;

namespace SistemaGestionResidencial.Controllers
{
    public class AuthController
    {
        private readonly ResidencialDbContext _context;

        public AuthController(ResidencialDbContext context)
        {
            _context = context;
        }

        public Usuario? Login(string nombreUsuario, string password)
        {
            var passwordHash = ComputeSha256Hash(password);
            return _context.Usuarios.FirstOrDefault(u => u.NombreUsuario == nombreUsuario && u.PasswordHash == passwordHash);
        }

        public void CambiarPassword(string nombreUsuario, string passwordActual, string passwordNueva)
        {
            var usuario = _context.Usuarios.FirstOrDefault(u => u.NombreUsuario == nombreUsuario);
            if (usuario == null)
            {
                throw new ArgumentException("Usuario no encontrado");
            }

            var passwordActualHash = ComputeSha256Hash(passwordActual);
            if (usuario.PasswordHash != passwordActualHash)
            {
                throw new ArgumentException("Contraseña actual incorrecta");
            }

            usuario.PasswordHash = ComputeSha256Hash(passwordNueva);
            _context.SaveChanges();
        }

        private string ComputeSha256Hash(string rawData)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
