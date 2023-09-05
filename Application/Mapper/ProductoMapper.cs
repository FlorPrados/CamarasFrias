using CamarasFrias.Domain.DTO;
using CamarasFrias.Domain.Entities;

namespace CamarasFrias.Application.Mapper
{
    public class ProductoMapper
    {
        public static Producto createProducto(ProductoDTO productoDTO)
        {
            if(productoDTO != null)
            {
                return new Producto
                {
                    Id = productoDTO.Id,
                    Nombre = productoDTO.Nombre,
                    Descripcion = productoDTO.Descripcion,
                    Precio = productoDTO.Precio,
                    Stock = productoDTO.Stock
                };
            }
            return null;
        }

        public static List<ProductoDTO> ToProductoList(List<Producto> productos)
        {
            List<ProductoDTO> productoDTO = new();
            if (productos != null)
            {
                foreach (var p in productos)
                {
                    productoDTO.Add(
                        new ProductoDTO
                        {
                            Id = p.Id,
                            Nombre = p.Nombre,
                            Descripcion = p.Descripcion,
                            Precio = p.Precio,
                            Stock = p.Stock
                        });
                }
                return productoDTO;
            }
            return null;
        }

        public static ProductoDTO ToProductoDTO(Producto producto)
        {
            if (producto != null)
            {
                return new ProductoDTO
                {
                    Id = producto.Id,
                    Nombre = producto.Nombre,
                    Descripcion = producto.Descripcion,
                    Precio = producto.Precio,
                    Stock = producto.Stock
                };
            }
            return null;
        }

        public static Producto putProducto(Producto producto)
        {
            if (producto != null)
            {
                return new Producto
                {
                    Nombre = producto.Nombre,
                    Descripcion = producto.Descripcion,
                    Precio = producto.Precio,
                    Stock = producto.Stock
                };
            }
            return null;
        }


    }

}
