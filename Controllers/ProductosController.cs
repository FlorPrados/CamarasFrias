using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CamarasFrias.Domain.Entities;
using CamarasFrias.Infrastructure.Persistence;
using CamarasFrias.Application.Business.Interfaces;
using CamarasFrias.Domain.DTO;
using System.Net;

namespace CamarasFrias.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly IProductoBusiness _productoBusiness;
        public ProductosController(IProductoBusiness productoBusiness)
        {
            _productoBusiness = productoBusiness;
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductoDTO producto)
        {
            var pto = _productoBusiness.CrearProducto(producto);
            if(pto != null)
            {
                var result = new JsonResult(pto);
                result.StatusCode = (int)HttpStatusCode.Created;
                return result;
            }
            return BadRequest();
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var ptos = _productoBusiness.TraerProductos();

            var result = new JsonResult(ptos);
            result.StatusCode = (int)HttpStatusCode.OK;
            return result;
        }

        [HttpGet("Id")]
        public async Task<IActionResult> Get(int Id)
        {
            var pto = _productoBusiness.TraerProductoId(Id);

            if (pto != null)
            {
                var result = new JsonResult(pto);
                result.StatusCode = (int)HttpStatusCode.OK;
                return result;
            }
            return NotFound();
        }

        [HttpPut("Id")]
        public async Task<IActionResult> Put(int Id, ProductoPutDTO producto)
        {
            var pto = _productoBusiness.ActualizarProducto(Id, producto);
            if (pto == true)
            {
                var result = new JsonResult(pto);
                result.StatusCode = (int)HttpStatusCode.OK;
                return result;
            }
            return NotFound();
        }

        [HttpPatch("AcualizarStock/{Id}")]
        public async Task<IActionResult> PatchStock(int Id, int cantidad)
        {
            var pto = _productoBusiness.ActualizarStock(Id, cantidad);
            if (pto == true)
            {
                var result = new JsonResult(pto);
                result.StatusCode = (int)HttpStatusCode.OK;
                return result;
            }
            return NotFound();
        }
        [HttpPatch("ActualizarPrecio/{Id}")]
        public async Task<IActionResult> PatchPrecio(int Id, int precio)
        {
            var pto = _productoBusiness.ActualizarPrecio(Id, precio);
            if (pto == true)
            {
                var result = new JsonResult(pto);
                result.StatusCode = (int)HttpStatusCode.OK;
                return result;
            }
            return NotFound();
        }

        [HttpDelete("Id")]
        public async Task<IActionResult> Delete(int Id)
        {
            var pto = _productoBusiness.EliminarProducto(Id);
            if (pto == true)
            {
                var result = new JsonResult(pto);
                result.StatusCode = (int)HttpStatusCode.OK;
                return result;
            }
            return NotFound();
        }
    }
}
