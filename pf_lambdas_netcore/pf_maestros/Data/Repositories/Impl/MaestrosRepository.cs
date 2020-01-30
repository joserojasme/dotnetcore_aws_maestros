using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using pf_maestros.Models;

namespace pf_maestros.Data.Repositories.Impl
{
    public class MaestrosRepository : IMaestrosRepository
    {
        private static string OK_MESSAGE = "Proceso ejecutado con éxito";
        private static string NOT_FOUND_MESSAGE = "Adquirente no encontrado";
        private static string DISABLE_STATE = "I";
        private static string ENABLE_STATE = "A";
        private readonly Context context;
        public MaestrosRepository(Context context)
        {
            this.context = context;
        }

        public async Task<string> ActualizarAdquirente(TpfAdquirentes adquirente)
        {
            context.Entry(adquirente).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return OK_MESSAGE;
        }

        public async Task<string> EliminarAdquirente(int nm_id_adquirente)
        {
            TpfAdquirentes adquirente = await context.TpfAdquirentes.Where(x => x.NmId == nm_id_adquirente).SingleOrDefaultAsync();
            if (adquirente == null)
            {
                return NOT_FOUND_MESSAGE;
            }

            if (adquirente.CdEstado == DISABLE_STATE)
            {
                adquirente.CdEstado = ENABLE_STATE;
            }
            else
            {
                adquirente.CdEstado = DISABLE_STATE;
            }
            
            context.Update(adquirente);
            await context.SaveChangesAsync();
            return OK_MESSAGE;
        }

        public async Task<string> InsertarAdquirente(TpfAdquirentes adquirente)
        {
            context.TpfAdquirentes.Add(adquirente);
            await context.SaveChangesAsync();
            return OK_MESSAGE;
        }

        public async Task<List<TpfAdquirentes>> ObtenerAdquirentes(int nm_id_emisor)
        {
            List<TpfAdquirentes> adquirentes = await context.TpfAdquirentes.Where(x => x.NmIdEmisor == nm_id_emisor).ToListAsync();
            return adquirentes;
        }

    }
}
