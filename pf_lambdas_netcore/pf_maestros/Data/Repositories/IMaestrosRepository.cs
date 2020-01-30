using pf_maestros.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pf_maestros.Data.Repositories
{
    public interface IMaestrosRepository
    {
        Task<List<TpfAdquirentes>> ObtenerAdquirentes(int nm_id_emisor);
        Task<string> InsertarAdquirente(TpfAdquirentes adquirente);
        Task<string> ActualizarAdquirente(TpfAdquirentes adquirente);
        Task<string> EliminarAdquirente(int nm_id_adquirente);
    }
}
