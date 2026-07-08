using Microsoft.EntityFrameworkCore;
using SistemaGestionResidencial.Models;

namespace SistemaGestionResidencial.Data
{
    public class ResidencialDbContext : DbContext
    {
        public DbSet<Apartamento> Apartamentos { get; set; }
        public DbSet<Inquilino> Inquilinos { get; set; }
        public DbSet<Contrato> Contratos { get; set; }
        public DbSet<Pago> Pagos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        public ResidencialDbContext(DbContextOptions<ResidencialDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuración de Contrato - Apartamento
            modelBuilder.Entity<Contrato>()
                .HasOne(c => c.Apartamento)
                .WithMany(a => a.Contratos)
                .HasForeignKey(c => c.ApartamentoId)
                .OnDelete(DeleteBehavior.Restrict);

            // Configuración de Contrato - Inquilino
            modelBuilder.Entity<Contrato>()
                .HasOne(c => c.Inquilino)
                .WithMany(i => i.Contratos)
                .HasForeignKey(c => c.InquilinoId)
                .OnDelete(DeleteBehavior.Restrict);

            // Configuración de Pago - Contrato
            modelBuilder.Entity<Pago>()
                .HasOne(p => p.Contrato)
                .WithMany(c => c.Pagos)
                .HasForeignKey(p => p.ContratoId)
                .OnDelete(DeleteBehavior.Cascade);

            // Índices para optimización
            modelBuilder.Entity<Apartamento>()
                .HasIndex(a => new { a.Numero, a.Bloque, a.Piso })
                .IsUnique();

            modelBuilder.Entity<Inquilino>()
                .HasIndex(i => i.NumeroDocumento)
                .IsUnique();

            modelBuilder.Entity<Contrato>()
                .HasIndex(c => c.ApartamentoId);

            modelBuilder.Entity<Pago>()
                .HasIndex(p => new { p.ContratoId, p.FechaPago });
        }
    }
}
