using SistemaGestionResidencial.Models;

namespace SistemaGestionResidencial.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ResidencialDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Usuarios.Any())
            {
                return;
            }

            // Seed data
            var usuarios = new Usuario[]
            {
                new Usuario { NombreUsuario = "admin", PasswordHash = "8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918", Rol = Rol.Admin },
                new Usuario { NombreUsuario = "recepcionista", PasswordHash = "8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918", Rol = Rol.Recepcionista },
                new Usuario { NombreUsuario = "usuario", PasswordHash = "8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918", Rol = Rol.Usuario }
            };

            context.Usuarios.AddRange(usuarios);
            context.SaveChanges();
        }
    }
}
