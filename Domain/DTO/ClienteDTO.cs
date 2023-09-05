using CamarasFrias.Domain.Entities;
using Microsoft.Build.Framework;

namespace CamarasFrias.Domain.DTO
{
    public class ClienteDTO
    {
        public int Dni { get; set; }
        [Required]
        public string Nombre { get; set; }
        public int Telefono { get; set; }
        public string? Domicilio { get; set; }
    }
}
