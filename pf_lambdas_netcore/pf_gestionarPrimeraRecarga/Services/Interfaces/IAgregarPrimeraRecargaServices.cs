using pf_gestionarPrimeraRecarga.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pf_gestionarPrimeraRecarga.Services.Interfaces
{
    public interface IAgregarPrimeraRecargaServices
    {
        Task<TpfPersonas> Add(string identificacionPersona);
    }
}
