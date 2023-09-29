namespace CamarasFrias.Domain.DTO
{
    public class DetalleGetProducto
    {
        public int ProductoID { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }
        public int? PorcDescuento { get; set; }
    }
}
