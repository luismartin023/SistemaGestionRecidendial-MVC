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

            // Seed Usuarios
            var usuarios = new Usuario[]
            {
                new Usuario { NombreUsuario = "admin", PasswordHash = "8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918", Rol = Rol.Admin },
                new Usuario { NombreUsuario = "recepcionista", PasswordHash = "8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918", Rol = Rol.Recepcionista },
                new Usuario { NombreUsuario = "usuario", PasswordHash = "8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918", Rol = Rol.Usuario }
            };

            context.Usuarios.AddRange(usuarios);
            context.SaveChanges();

            // Seed Apartamentos
            var apartamentos = new Apartamento[]
            {
                new Apartamento { Numero = "101", Piso = 1, Bloque = "A", NumHabitaciones = 2, MetrosCuadrados = 80, Descripcion = "Apartamento con vista al jardín", PrecioAlquiler = 500, Estado = EstadoApartamento.Disponible },
                new Apartamento { Numero = "102", Piso = 1, Bloque = "A", NumHabitaciones = 3, MetrosCuadrados = 120, Descripcion = "Apartamento amplio con balcon", PrecioAlquiler = 700, Estado = EstadoApartamento.Disponible },
                new Apartamento { Numero = "201", Piso = 2, Bloque = "A", NumHabitaciones = 2, MetrosCuadrados = 85, Descripcion = "Apartamento moderno", PrecioAlquiler = 550, Estado = EstadoApartamento.Disponible },
                new Apartamento { Numero = "202", Piso = 2, Bloque = "A", NumHabitaciones = 1, MetrosCuadrados = 50, Descripcion = "Estudio acogedor", PrecioAlquiler = 350, Estado = EstadoApartamento.Disponible },
                new Apartamento { Numero = "301", Piso = 3, Bloque = "B", NumHabitaciones = 3, MetrosCuadrados = 130, Descripcion = "Penthouse con terraza", PrecioAlquiler = 900, Estado = EstadoApartamento.Disponible }
            };

            context.Apartamentos.AddRange(apartamentos);
            context.SaveChanges();

            // Seed Inquilinos
            var inquilinos = new Inquilino[]
            {
                new Inquilino { Nombre = "Juan", Apellido = "Pérez", TipoDocumento = TipoDocumento.Cedula, NumeroDocumento = "12345678901", Telefono = "8095550101", Email = "juan.perez@email.com" },
                new Inquilino { Nombre = "María", Apellido = "García", TipoDocumento = TipoDocumento.Cedula, NumeroDocumento = "12345678902", Telefono = "8095550102", Email = "maria.garcia@email.com" },
                new Inquilino { Nombre = "Carlos", Apellido = "Rodríguez", TipoDocumento = TipoDocumento.Pasaporte, NumeroDocumento = "A12345678", Telefono = "8095550103", Email = "carlos.rodriguez@email.com" }
            };

            context.Inquilinos.AddRange(inquilinos);
            context.SaveChanges();

            // Seed Contratos
            var contratos = new Contrato[]
            {
                new Contrato 
                { 
                    ApartamentoId = 1, 
                    InquilinoId = 1, 
                    FechaInicio = DateTime.Now.AddMonths(-6), 
                    FechaFin = DateTime.Now.AddMonths(6), 
                    MontoMensual = 500, 
                    Deposito = 1000, 
                    Estado = "Activo",
                    Observaciones = "Contrato estándar"
                },
                new Contrato 
                { 
                    ApartamentoId = 2, 
                    InquilinoId = 2, 
                    FechaInicio = DateTime.Now.AddMonths(-3), 
                    FechaFin = DateTime.Now.AddMonths(9), 
                    MontoMensual = 700, 
                    Deposito = 1400, 
                    Estado = "Activo",
                    Observaciones = "Contrato con balcon"
                }
            };

            context.Contratos.AddRange(contratos);
            context.SaveChanges();

            // Seed Pagos
            var pagos = new Pago[]
            {
                new Pago 
                { 
                    ContratoId = 1, 
                    FechaPago = DateTime.Now.AddMonths(-5), 
                    Monto = 500, 
                    MetodoPago = MetodoPago.Transferencia, 
                    Referencia = "BAN-001", 
                    NumeroRecibo = "REC-001",
                    Estado = "Pagado"
                },
                new Pago 
                { 
                    ContratoId = 1, 
                    FechaPago = DateTime.Now.AddMonths(-4), 
                    Monto = 500, 
                    MetodoPago = MetodoPago.Transferencia, 
                    Referencia = "BAN-002", 
                    NumeroRecibo = "REC-002",
                    Estado = "Pagado"
                },
                new Pago 
                { 
                    ContratoId = 1, 
                    FechaPago = DateTime.Now.AddMonths(-3), 
                    Monto = 500, 
                    MetodoPago = MetodoPago.Transferencia, 
                    Referencia = "BAN-003", 
                    NumeroRecibo = "REC-003",
                    Estado = "Pagado"
                },
                new Pago 
                { 
                    ContratoId = 1, 
                    FechaPago = DateTime.Now.AddMonths(-2), 
                    Monto = 500, 
                    MetodoPago = MetodoPago.Transferencia, 
                    Referencia = "BAN-004", 
                    NumeroRecibo = "REC-004",
                    Estado = "Pagado"
                },
                new Pago 
                { 
                    ContratoId = 1, 
                    FechaPago = DateTime.Now.AddMonths(-1), 
                    Monto = 500, 
                    MetodoPago = MetodoPago.Transferencia, 
                    Referencia = "BAN-005", 
                    NumeroRecibo = "REC-005",
                    Estado = "Pagado"
                },
                new Pago 
                { 
                    ContratoId = 2, 
                    FechaPago = DateTime.Now.AddMonths(-2), 
                    Monto = 700, 
                    MetodoPago = MetodoPago.Efectivo, 
                    Referencia = "EFEC-001", 
                    NumeroRecibo = "REC-006",
                    Estado = "Pagado"
                },
                new Pago 
                { 
                    ContratoId = 2, 
                    FechaPago = DateTime.Now.AddMonths(-1), 
                    Monto = 700, 
                    MetodoPago = MetodoPago.Efectivo, 
                    Referencia = "EFEC-002", 
                    NumeroRecibo = "REC-007",
                    Estado = "Pagado"
                }
            };

            context.Pagos.AddRange(pagos);
            context.SaveChanges();

            // Actualizar estado de apartamentos con contratos activos
            var apto1 = context.Apartamentos.Find(1);
            if (apto1 != null) apto1.Estado = EstadoApartamento.Ocupado;

            var apto2 = context.Apartamentos.Find(2);
            if (apto2 != null) apto2.Estado = EstadoApartamento.Ocupado;

            context.SaveChanges();
        }
    }
}
