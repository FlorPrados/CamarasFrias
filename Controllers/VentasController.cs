using CamarasFrias.Application.Business.Interfaces;
using CamarasFrias.Domain.DTO;
using CamarasFrias.Domain.Entities;
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

        [HttpPut("nroComprobante")]
        public async Task<IActionResult> Put(int nroComprobante, VentaDTO ventaDTO)
        {
            var venta = _ventaBusiness.ActualizarVenta(nroComprobante, ventaDTO);
            if (venta == true)
            {
                var result = new JsonResult(venta);
                result.StatusCode = (int)HttpStatusCode.OK;
                return result;
            }
            return NotFound();
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

        [HttpDelete("Id")]
        public async Task<IActionResult> Delete(int Id)
        {
            var venta = _ventaBusiness.EliminarVenta(Id);
            if(venta == true)
            {
                var result = new JsonResult(venta);
                result.StatusCode = (int)HttpStatusCode.OK;
                return result;
            }
            return NotFound();
        }

        [HttpGet("NroComprobante")]
        public async Task<IActionResult> GetVenta(int NroComprobante)
        {
            var venta = _ventaBusiness.VerVenta(NroComprobante);

            if (venta != null)
            {
                var result = new JsonResult(venta);
                result.StatusCode = (int)HttpStatusCode.OK;
                return result;
            }
            return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> GetVentas()
        {
            var ventas = _ventaBusiness.VerVentas();

            if (ventas != null)
            {
                var result = new JsonResult(ventas);
                result.StatusCode = (int)HttpStatusCode.OK;
                return result;
            }
            return NotFound();

        }

    }
}
