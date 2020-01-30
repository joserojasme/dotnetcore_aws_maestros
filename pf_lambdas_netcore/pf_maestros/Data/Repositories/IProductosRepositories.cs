using pf_maestros.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pf_maestros.Data.Repositories
{
    public interface IProductosRepositories
    {
        Task<List<TpfProductos>> Obtener(int nm_id_emisor);
        Task<string> Insertar(TpfProductos producto);
        Task<string> Actualizar(TpfProductos producto);
        Task<string> Eliminar(int nm_id_producto);
    }
}
