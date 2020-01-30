using pf_maestros.Data.Repositories;
using pf_maestros.Models;
using pf_maestros.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pf_maestros.Services
{
    public class ProductosServices : IProductosServices
    {
        private IProductosRepositories productosRepository;
        public ProductosServices(IProductosRepositories productosRepository)
        {
            this.productosRepository = productosRepository;
        }
        public async Task<string> AddAsync(TpfProductos producto)
        {
            string result = await productosRepository.Insertar(producto);
            return result;
        }

        public async Task<string> DeleteAsync(int nm_id_producto)
        {
            string result = await productosRepository.Eliminar(nm_id_producto);
            return result;
        }

        public async Task<List<TpfProductos>> GetAsync(int nm_id_emisor)
        {
            List<TpfProductos> productos = await productosRepository.Obtener(nm_id_emisor);
            return productos;
        }

        public async Task<string> UpdateAsync(TpfProductos producto)
        {
            string result = await productosRepository.Actualizar(producto);
            return result;
        }
    }
}
