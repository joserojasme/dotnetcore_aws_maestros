using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pf_consultarPlan.Models;

namespace pf_consultarPlan.Controllers
{
    //[Route("consultarplan-dev/[controller]")]
    [Route("consultarplan-prod/[controller]")]
    [ApiController]
    public class TpfPlanesController : ControllerBase
    {
        private readonly Context _context;
        private static string CdEstado = "A";
        private static string CdVisible = "S";

        public TpfPlanesController(Context context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<TpfPlanes> GetTpfPlanes()
        {
            Console.WriteLine("Entra aquí");
            try
            {
                List<TpfPlanes> planes = (from plan in _context.TpfPlanes
                                          where plan.CdEstado == CdEstado
                                          && plan.CdVisible == CdVisible
                                          select plan).ToList();
                Console.WriteLine("Ya obtuvo respuesta");
                return planes;
            }
            catch (Exception e)
            {
                Console.WriteLine("*****ERROR: " + e.Message);
                return null;
            }
           
        }
    }
}