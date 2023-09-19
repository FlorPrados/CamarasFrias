namespace CamarasFrias.Domain.DTO
{
    public class VentaGetDTO
    {
        public int ClienteDNI { get; set; }
        public DateTime Fecha { get; set; }
        public List<DetalleProducto> Productos { get; set; }
        public string? Nota { get; set; }
        public decimal Total { get; set; }
    }
}
