using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaGestionResidencial.Models
{
    public class Contrato
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "El apartamento es obligatorio")]
        public int ApartamentoId { get; set; }

        [Required(ErrorMessage = "El inquilino es obligatorio")]
        public int InquilinoId { get; set; }

        [Required(ErrorMessage = "La fecha de inicio es obligatoria")]
        public DateTime FechaInicio { get; set; }

        [Required(ErrorMessage = "La fecha de fin es obligatoria")]
        public DateTime FechaFin { get; set; }

        [Required(ErrorMessage = "El monto mensual es obligatorio")]
        [Range(100, 10000, ErrorMessage = "El monto debe estar entre 100 y 10000")]
        public decimal MontoMensual { get; set; }

        [Required(ErrorMessage = "El depósito es obligatorio")]
        [Range(0, 20000, ErrorMessage = "El depósito debe estar entre 0 y 20000")]
        public decimal Deposito { get; set; }

        [Required(ErrorMessage = "El estado es obligatorio")]
        [StringLength(20, ErrorMessage = "El estado no puede exceder 20 caracteres")]
        public string Estado { get; set; } = "Activo";

        [StringLength(1000, ErrorMessage = "Las observaciones no pueden exceder 1000 caracteres")]
        public string Observaciones { get; set; } = string.Empty;

        [ForeignKey("ApartamentoId")]
        public Apartamento Apartamento { get; set; } = null!;

        [ForeignKey("InquilinoId")]
        public Inquilino Inquilino { get; set; } = null!;

        public List<Pago> Pagos { get; set; } = new();
    }
}
