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
            // Configuración de relaciones
            modelBuilder.Entity<Contrato>()
                .HasOne(c => c.Apartamento)
                .WithMany(a => a.Contratos)
                .HasForeignKey(c => c.ApartamentoId);

            modelBuilder.Entity<Contrato>()
                .HasOne(c => c.Inquilino)
                .WithMany(i => i.Contratos)
                .HasForeignKey(c => c.InquilinoId);

            modelBuilder.Entity<Pago>()
                .HasOne(p => p.Contrato)
                .WithMany(c => c.Pagos)
                .HasForeignKey(p => p.ContratoId);
        }
    }
}
