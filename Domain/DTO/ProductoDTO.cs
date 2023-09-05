using CamarasFrias.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace CamarasFrias.Domain.DTO
{
    public class ProductoDTO
    {
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; } = null!;
        public string? Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
    }
}
