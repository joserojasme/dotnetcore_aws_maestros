using pf_maestros.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pf_maestros.Services.Interfaces
{
    public interface IProductosServices
    {
        Task<List<TpfProductos>> GetAsync(int nm_id_emisor);
        Task<string> UpdateAsync(TpfProductos producto);
        Task<string> AddAsync(TpfProductos producto);
        Task<string> DeleteAsync(int nm_id_producto);
    }
}
