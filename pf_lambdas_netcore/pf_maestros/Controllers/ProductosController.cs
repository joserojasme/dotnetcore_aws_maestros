using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pf_maestros.Models;
using pf_maestros.Services.Interfaces;

namespace pf_maestros.Controllers
{
    //[Route("maestros-qa/[controller]")]
    [Route("maestros-prod/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private IProductosServices productosServices;

        public ProductosController(IProductosServices productosServices)
        {
            this.productosServices = productosServices;
        }

        [HttpGet("{nm_id_emisor}")]
        public async Task<IActionResult> GetTpfProductos([FromRoute] int nm_id_emisor)
        {
            try
            {
                List<TpfProductos> productos = await productosServices.GetAsync(nm_id_emisor);
                return Ok(productos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> PutTpfProductos([FromBody] TpfProductos producto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                string response = await productosServices.UpdateAsync(producto);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostTpfProductos([FromBody] TpfProductos producto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                string response = await productosServices.AddAsync(producto);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{nm_id_producto}")]
        public async Task<IActionResult> DeleteTpfProductos([FromRoute] int nm_id_producto)
        {
            try
            {
                string response = await productosServices.DeleteAsync(nm_id_producto);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}