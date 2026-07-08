namespace SistemaGestionResidencial.Models
{
    public class Contrato
    {
        public int Id { get; set; }
        public int ApartamentoId { get; set; }
        public int InquilinoId { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public decimal MontoMensual { get; set; }
        public decimal Deposito { get; set; }
        public string Estado { get; set; }
        public string Observaciones { get; set; }
        public Apartamento Apartamento { get; set; }
        public Inquilino Inquilino { get; set; }
        public List<Pago> Pagos { get; set; } = new();
    }
}
