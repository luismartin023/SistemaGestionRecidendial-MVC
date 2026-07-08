using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaGestionResidencial.Models
{
    public class Apartamento
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "El número es obligatorio")]
        [StringLength(10, ErrorMessage = "El número no puede exceder 10 caracteres")]
        public string Numero { get; set; } = string.Empty;

        [Required(ErrorMessage = "El piso es obligatorio")]
        [Range(1, 50, ErrorMessage = "El piso debe estar entre 1 y 50")]
        public int Piso { get; set; }

        [Required(ErrorMessage = "El bloque es obligatorio")]
        [StringLength(5, ErrorMessage = "El bloque no puede exceder 5 caracteres")]
        public string Bloque { get; set; } = string.Empty;

        [Required(ErrorMessage = "El número de habitaciones es obligatorio")]
        [Range(1, 10, ErrorMessage = "El número de habitaciones debe estar entre 1 y 10")]
        public int NumHabitaciones { get; set; }

        [Required(ErrorMessage = "Los metros cuadrados son obligatorios")]
        [Range(20, 500, ErrorMessage = "Los metros cuadrados deben estar entre 20 y 500")]
        public double MetrosCuadrados { get; set; }

        [StringLength(500, ErrorMessage = "La descripción no puede exceder 500 caracteres")]
        public string Descripcion { get; set; } = string.Empty;

        [Required(ErrorMessage = "El precio de alquiler es obligatorio")]
        [Range(100, 10000, ErrorMessage = "El precio debe estar entre 100 y 10000")]
        public decimal PrecioAlquiler { get; set; }

        [Required(ErrorMessage = "El estado es obligatorio")]
        public EstadoApartamento Estado { get; set; } = EstadoApartamento.Disponible;

        public List<Contrato> Contratos { get; set; } = new();
    }
}
