using pf_maestros.Data.Repositories;
using pf_maestros.Models;
using pf_maestros.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pf_maestros.Services
{
    public class MaestrosServices : IMaestrosServices
    {
        private IMaestrosRepository maestrosRepository;
        public MaestrosServices(IMaestrosRepository maestrosRepository)
        {
            this.maestrosRepository = maestrosRepository;
        }
        public async Task<string> Add(TpfAdquirentes adquirente)
        {
            string result = await maestrosRepository.InsertarAdquirente(adquirente);
            return result;
        }

        public async Task<string> DeleteAsync(int nm_id_adquirente)
        {
            string result = await maestrosRepository.EliminarAdquirente(nm_id_adquirente);
            return result;
        }

        public async Task<List<TpfAdquirentes>> Get(int nm_id_emisor)
        {
            List<TpfAdquirentes> adquirentes = await maestrosRepository.ObtenerAdquirentes(nm_id_emisor);
            return adquirentes;
        }

        public async Task<string> UpdateAsync(TpfAdquirentes adquirente)
        {
            string result = await maestrosRepository.ActualizarAdquirente(adquirente);
            return result;
        }
    }
}
