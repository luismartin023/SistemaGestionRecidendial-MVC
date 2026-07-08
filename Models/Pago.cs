namespace SistemaGestionResidencial.Models
{
    public class Pago
    {
        public int Id { get; set; }
        public int ContratoId { get; set; }
        public DateTime FechaPago { get; set; }
        public decimal Monto { get; set; }
        public MetodoPago MetodoPago { get; set; }
        public string Referencia { get; set; }
        public string NumeroRecibo { get; set; }
        public string Estado { get; set; }
        public Contrato Contrato { get; set; }
    }
}
