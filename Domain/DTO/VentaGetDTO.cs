namespace CamarasFrias.Domain.DTO
{
    public class VentaGetDTO
    {
        public int NroComprobante { get; set; }
        public int ClienteDNI { get; set; }
        public string Nombre { get; set; }
        public DateTime Fecha { get; set; }
        public List<DetalleGetProducto>? Productos { get; set; }
        public string? Nota { get; set; }
        public decimal Total { get; set; }
    }
}
