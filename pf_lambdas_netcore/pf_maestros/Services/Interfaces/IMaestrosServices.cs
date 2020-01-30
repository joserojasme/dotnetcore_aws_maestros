using pf_maestros.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pf_maestros.Services.Interfaces
{
    public interface IMaestrosServices
    {
        Task<List<TpfAdquirentes>> Get(int nm_id_emisor);
        Task<string> UpdateAsync(TpfAdquirentes adquirente);
        Task<string> Add(TpfAdquirentes adquirente);
        Task<string> DeleteAsync(int nm_id_adquirente);
    }
}
