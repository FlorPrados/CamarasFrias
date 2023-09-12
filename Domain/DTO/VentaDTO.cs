namespace CamarasFrias.Domain.DTO
{
    public class VentaDTO
    {
        public int NroComprobante { get; set; }
        public int ClienteDNI { get; set; }
        public List<misProductos> Productos { get; set; }
        public string? Nota { get; set; }

    }

    public class misProductos
    {
        public int ProductoID { get; set; }
        public int Cantidad { get; set; }
        public int? PorcDescuento { get; set; }
    }
}
