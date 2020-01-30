using Newtonsoft.Json;
using pf_gestionarPrimeraRecarga.Data.Repositories;
using pf_gestionarPrimeraRecarga.Models;
using pf_gestionarPrimeraRecarga.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pf_gestionarPrimeraRecarga.Services
{
    public class AgregarPrimeraRecargaServices : IAgregarPrimeraRecargaServices
    {
        private IAgregarPrimeraRecargaRepository agregarPrimeraRecargaRepository;
        public AgregarPrimeraRecargaServices(IAgregarPrimeraRecargaRepository agregarPrimeraRecargaRepository)
        {
            this.agregarPrimeraRecargaRepository = agregarPrimeraRecargaRepository;
        }
        public async Task<TpfPersonas> Add(string identificacionPersona)
        {
            TpfPersonas persona = await agregarPrimeraRecargaRepository.ObtenerPersona(identificacionPersona);
            if(persona == null) {return null;}

            var tokenPrimeraRecarga = JsonConvert.DeserializeObject<Dictionary<string, string>>(persona.DsTokenPrimrecar);

            TpfPlanes plan = await agregarPrimeraRecargaRepository.ObtenerPlan(Convert.ToInt32(tokenPrimeraRecarga["idPlan"]));
            if (plan == null) { return null; }

            TpfEmisores emisor = await agregarPrimeraRecargaRepository.AgregarEmisor(persona);
            if (emisor == null) { return null; }

            TpfRecargas recarga = await agregarPrimeraRecargaRepository.AgregarRecarga(emisor, tokenPrimeraRecarga["idPlan"]);
            if (recarga == null) { return null; }

            TpfSaldos saldo = await agregarPrimeraRecargaRepository.AgregarSaldo(recarga, plan.NmCantDoc);
            if (saldo == null) { return null; }

            return  persona;
        }
    }
}
