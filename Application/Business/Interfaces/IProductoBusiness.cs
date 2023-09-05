using CamarasFrias.Domain.DTO;

namespace CamarasFrias.Application.Business.Interfaces
{
    public interface IProductoBusiness
    {
        public ProductoDTO CrearProducto(ProductoDTO producto);
        public List<ProductoDTO> TraerProductos();
        public ProductoDTO TraerProductoId(int Id);
        public bool ActualizarProducto(int Id, ProductoPutDTO producto);
        public bool ActualizarStock(int Id, int cantidad);
        public bool ActualizarPrecio(int Id, int precio);
        public bool EliminarProducto(int Id);

    }
}