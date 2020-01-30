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
    public class AdquirentesController : ControllerBase
    {
        private IMaestrosServices maestrosServices;

        public AdquirentesController(IMaestrosServices maestrosServices)
        {
            this.maestrosServices = maestrosServices;
        }

        // GET: api/Adquirentes/5
        [HttpGet("{nm_id_emisor}")]
        public async Task<IActionResult> GetTpfAdquirentes([FromRoute] int nm_id_emisor)
        {
            try
            {
                List<TpfAdquirentes> adquirentes = await maestrosServices.Get(nm_id_emisor);
                return Ok(adquirentes);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> PutTpfAdquirentes( [FromBody] TpfAdquirentes adquirente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                string response = await maestrosServices.UpdateAsync(adquirente);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostTpfAdquirentes([FromBody] TpfAdquirentes adquirente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                string response = await maestrosServices.Add(adquirente);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{nm_id_adquirente}")]
        public async Task<IActionResult> DeleteTpfAdquirentes([FromRoute] int nm_id_adquirente)
        {
            try
            {
                string response = await maestrosServices.DeleteAsync(nm_id_adquirente);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}