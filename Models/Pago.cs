using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaGestionResidencial.Models
{
    public class Pago
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "El contrato es obligatorio")]
        public int ContratoId { get; set; }

        [Required(ErrorMessage = "La fecha de pago es obligatoria")]
        public DateTime FechaPago { get; set; }

        [Required(ErrorMessage = "El monto es obligatorio")]
        [Range(1, 10000, ErrorMessage = "El monto debe estar entre 1 y 10000")]
        public decimal Monto { get; set; }

        [Required(ErrorMessage = "El método de pago es obligatorio")]
        public MetodoPago MetodoPago { get; set; }

        [StringLength(50, ErrorMessage = "La referencia no puede exceder 50 caracteres")]
        public string Referencia { get; set; } = string.Empty;

        [Required(ErrorMessage = "El número de recibo es obligatorio")]
        [StringLength(20, ErrorMessage = "El número de recibo no puede exceder 20 caracteres")]
        public string NumeroRecibo { get; set; } = string.Empty;

        [Required(ErrorMessage = "El estado es obligatorio")]
        [StringLength(20, ErrorMessage = "El estado no puede exceder 20 caracteres")]
        public string Estado { get; set; } = "Pagado";

        [ForeignKey("ContratoId")]
        public Contrato Contrato { get; set; } = null!;
    }
}
