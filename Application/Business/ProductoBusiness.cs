using CamarasFrias.Application.Business.Interfaces;
using CamarasFrias.Application.Mapper;
using CamarasFrias.Domain.DTO;
using CamarasFrias.Domain.Entities;
using CamarasFrias.Infrastructure.Persistence;

namespace CamarasFrias.Application.Business
{
    public class ProductoBusiness : IProductoBusiness
    {
        private readonly CamarasFriasContext _context;
        public ProductoBusiness(CamarasFriasContext context)
        {
            _context = context;
        }

        public bool ActualizarProducto(int Id, ProductoPutDTO producto)
        {
            try
            {
                var pto = _context.Productos.FirstOrDefault(p => p.Id == Id);

                if (pto == null) return false;

                var ptoActualizado = ProductoMapper.putProducto(pto);
                _context.SaveChanges();

                return true;
            }
            catch
            {
                throw;
            }
        }

        public bool ActualizarStock(int Id, int cantidad)
        {
            try
            {
                var pto = _context.Productos.FirstOrDefault(p => p.Id == Id);

                if (pto == null) return false;

                pto.Stock = cantidad;
                _context.SaveChanges();

                return true;
            }
            catch
            {
                throw;
            }
        }

        public bool ActualizarPrecio(int Id, int precio)
        {
            try
            {
                var pto = _context.Productos.FirstOrDefault(p => p.Id == Id);

                if (pto == null) return false;

                pto.Precio = precio;
                _context.SaveChanges();

                return true;
            }
            catch
            {
                throw;
            }
        }

        public ProductoDTO CrearProducto(ProductoDTO productoDTO)
        {
            try
            {
                Producto pto = _context.Productos.FirstOrDefault(p => p.Id == productoDTO.Id);

                if (pto != null)
                {
                    return null;
                    //throw new InvalidOperationException("Ya existe un producto con el Id registrado"); ;
                }
                var producto = ProductoMapper.createProducto(productoDTO);
                _context.Productos.Add(producto);
                _context.SaveChanges();

                return productoDTO;
            }
            catch
            {
                throw;
            }

        }

        public bool EliminarProducto(int Id)
        {
            try
            {
                var producto = _context.Productos.FirstOrDefault(p => p.Id == Id);

                if (producto == null) return false;

                _context.Productos.Remove(producto);
                _context.SaveChanges();

                return true;
            }
            catch
            {
                throw;
            }

        }

        public ProductoDTO TraerProductoId(int Id)
        {
            try
            {
                var producto = _context.Productos.FirstOrDefault(p => p.Id == Id);

                var pto = ProductoMapper.ToProductoDTO(producto);
                return pto;
            }
            catch
            {
                throw;
            }

        }

        public List<ProductoDTO> TraerProductos()
        {
            try
            {
                List<Producto> productos = _context.Productos.ToList();

                var ptos = ProductoMapper.ToProductoList(productos);

                return ptos;
            }
            catch
            {
                throw;
            }
        }
    }
}
