using System;
using System.Collections.Generic;

namespace pf_maestros.Models
{
    public partial class TpfPersonas
    {
        public TpfPersonas()
        {
            TpfEmisores = new HashSet<TpfEmisores>();
        }

        public int NmId { get; set; }
        public string CdTipoIdentificacion { get; set; }
        public string DsIdentificacion { get; set; }
        public string DsNombre { get; set; }
        public string DsSegundoNombre { get; set; }
        public string DsPrimerApellido { get; set; }
        public string DsSegundoApellido { get; set; }
        public string DsDireccion { get; set; }
        public string CdCiudad { get; set; }
        public string DsTelefono { get; set; }
        public string DsCelular { get; set; }
        public string DsEmail { get; set; }
        public DateTime FeProceso { get; set; }
        public string DsTokenPrimrecar { get; set; }

        public ICollection<TpfEmisores> TpfEmisores { get; set; }
    }
}
