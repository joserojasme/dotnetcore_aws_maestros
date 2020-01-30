using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pf_gestionarPrimeraRecarga.Models;
using pf_gestionarPrimeraRecarga.Services.Interfaces;

namespace pf_gestionarPrimeraRecarga.Controllers
{
    //[Route("gestionarrecarga-dev/[controller]")]
    [Route("gestionarrecarga-prod/[controller]")]
    [ApiController]
    public class AgregarPrimeraRecargaController : ControllerBase
    {
        private IAgregarPrimeraRecargaServices agregarPrimeraRecargaServices;

        public AgregarPrimeraRecargaController(IAgregarPrimeraRecargaServices agregarPrimeraRecarga)
        {
            this.agregarPrimeraRecargaServices = agregarPrimeraRecarga;
        }

        // POST: gestionarrecarga-dev/AgregarPrimeraRecarga
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] string identificacionPersona)
        {
            try
            {
                if (!this.ModelState.IsValid || identificacionPersona == null)
                {
                    return BadRequest("La identifiación no puede estar vacía");
                }

                TpfPersonas persona = await agregarPrimeraRecargaServices.Add(identificacionPersona);
                if (persona != null)
                {
                    string nombre = String.Format("{0} {1} {2} {3}", persona.DsNombre, persona.DsSegundoNombre, persona.DsPrimerApellido, persona.DsSegundoApellido);
                    return Ok(nombre);
                }
                else
                {
                    return NotFound(String.Format("{0} {1}","No se pudo procesar la primera recarga. Contáctese con soporte",identificacionPersona));
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }   
        }
    }
}