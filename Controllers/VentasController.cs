using CamarasFrias.Application.Business.Interfaces;
using CamarasFrias.Domain.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CamarasFrias.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentasController : ControllerBase
    {
        private readonly IVentaBusiness _ventaBusiness;

        public VentasController(IVentaBusiness ventaBusiness)
        {
            _ventaBusiness = ventaBusiness;
        }

        [HttpPost]
        public async Task<IActionResult> Create(VentaDTO ventaDTO)
        {
            var venta = _ventaBusiness.CrearVenta(ventaDTO);
            if(venta != null)
            {
                var result = new JsonResult(venta);
                result.StatusCode = (int)HttpStatusCode.Created;
                return result;
            }
            return BadRequest();
        }

    }
}
