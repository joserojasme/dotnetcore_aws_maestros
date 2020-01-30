using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using pf_gestionarPrimeraRecarga.Models;

namespace pf_gestionarPrimeraRecarga.Data.Repositories.Impl
{
    public class AgregarPrimeraRecargaRepository : IAgregarPrimeraRecargaRepository
    {
        private static string tipoPersona = "JURIDICA";
        private readonly Context context;
        public AgregarPrimeraRecargaRepository(Context context)
        {
            this.context = context;
        }
        public async Task<TpfSaldos> AgregarSaldo(TpfRecargas model, int CantidadDocumentos)
        {
            var existe = context.TpfSaldos.SingleOrDefault(saldo => saldo.NmIdEmisor == model.NmIdEmisor);
            if(existe != null) { return null; }

            TpfSaldos nuevoSaldo = new TpfSaldos()
            {
                NmIdEmisor = model.NmIdEmisor,
                NmSaldo = CantidadDocumentos
            };

            context.TpfSaldos.Add(nuevoSaldo);
            context.SaveChanges();

            var query = (from saldo in context.TpfSaldos
                         where saldo.NmIdEmisor == model.NmIdEmisor
                         select saldo).FirstOrDefault();

            return await Task.FromResult(query);
        }

        public async Task<TpfEmisores> AgregarEmisor(TpfPersonas model)
        {
            var existe = context.TpfEmisores.SingleOrDefault(emisor => emisor.NmIdPersona == model.NmId);
            if (existe != null) { return null; }

            TpfEmisores nuevoEmisor = new TpfEmisores()
            {
                NmIdPersona = model.NmId,
                CdTipoPersona = tipoPersona,
                DsEmailRemitente = model.DsEmail,
                DsLogo = string.Empty
            };

            context.TpfEmisores.Add(nuevoEmisor);
            context.SaveChanges();

            var query = (from emisor in context.TpfEmisores
                         where emisor.NmIdPersona == model.NmId
                         select emisor).FirstOrDefault();
            return await Task.FromResult(query);
        }

        public async Task<TpfRecargas> AgregarRecarga(TpfEmisores model, string idPlanPersona)
        {
            int idPlan = Convert.ToInt32(idPlanPersona);
            TpfRecargas nuevaRecarga = new TpfRecargas()
            {
                NmIdEmisor = model.NmId,
                NmIdPlan = idPlan,
            };

            context.TpfRecargas.Add(nuevaRecarga);
            context.SaveChanges();

            var query = (from recarga in context.TpfRecargas
                         where recarga.NmIdEmisor == model.NmId && recarga.NmIdPlan == idPlan
                         select recarga).Last();

            return await Task.FromResult(query);
        }

        public async Task<TpfPersonas> ObtenerPersona(string identificacionPersona)
        {
            var query = (from persona in context.TpfPersonas
                         where persona.DsIdentificacion == identificacionPersona
                         select persona).Last();
            return await Task.FromResult(query);
        }

        public async Task<TpfPlanes> ObtenerPlan(int idPlan)
        {
            var query = (from plan in context.TpfPlanes
                         where plan.NmId == idPlan
                         select plan).FirstOrDefault();
            return await Task.FromResult(query);
        }
    }
}
