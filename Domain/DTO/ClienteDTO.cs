using CamarasFrias.Domain.Entities;

namespace CamarasFrias.Domain.DTO
{
    public class ClienteDTO
    {
        public int Dni { get; set; }
        public string Nombre { get; set; } = null!;
        public int Telefono { get; set; }
        public string? Domicilio { get; set; }
    }
}
