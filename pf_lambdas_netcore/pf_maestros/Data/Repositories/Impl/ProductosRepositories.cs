using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using pf_maestros.Models;

namespace pf_maestros.Data.Repositories.Impl
{
    public class ProductosRepositories : IProductosRepositories
    {
        private static string OK_MESSAGE = "Proceso ejecutado con éxito";
        private static string NOT_FOUND_MESSAGE = "Producto no encontrado";
        private static string DISABLE_STATE = "I";
        private static string ENABLE_STATE = "A";
        private readonly Context context;
        public ProductosRepositories(Context context)
        {
            this.context = context;
        }
        public async Task<string> Actualizar(TpfProductos producto)
        {
            context.Entry(producto).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return OK_MESSAGE;
        }

        public async Task<string> Eliminar(int nm_id_producto)
        {
            TpfProductos producto = await context.TpfProductos.Where(x => x.NmId == nm_id_producto).SingleOrDefaultAsync();
            if (producto == null)
            {
                return NOT_FOUND_MESSAGE;
            }

            if (producto.CdEstado == DISABLE_STATE)
            {
                producto.CdEstado = ENABLE_STATE;
            }
            else
            {
                producto.CdEstado = DISABLE_STATE;
            }

            context.Update(producto);
            await context.SaveChangesAsync();
            return OK_MESSAGE;
        }

        public async Task<string> Insertar(TpfProductos producto)
        {
            context.TpfProductos.Add(producto);
            await context.SaveChangesAsync();
            return OK_MESSAGE;
        }

        public async Task<List<TpfProductos>> Obtener(int nm_id_emisor)
        {
            List<TpfProductos> productos = await context.TpfProductos.Where(x => x.NmIdEmisor == nm_id_emisor).ToListAsync();
            return productos;
        }
    }
}
