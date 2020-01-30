using pf_gestionarPrimeraRecarga.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pf_gestionarPrimeraRecarga.Data.Repositories
{
    public interface IAgregarPrimeraRecargaRepository
    {
        Task<TpfPersonas> ObtenerPersona(string identificacionPersona);

        Task<TpfEmisores> AgregarEmisor(TpfPersonas model);

        Task<TpfRecargas> AgregarRecarga(TpfEmisores model, string idPlan);

        Task<TpfSaldos> AgregarSaldo(TpfRecargas model, int CantidadDocumentos);

        Task<TpfPlanes> ObtenerPlan(int idPlan);
    }
}
