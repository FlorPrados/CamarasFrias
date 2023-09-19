namespace CamarasFrias.Domain.DTO
{
    public class VentaDTO
    {
        public int ClienteDNI { get; set; }
        public List<DetalleProducto> Productos { get; set; }
        public string? Nota { get; set; }

    }

}
