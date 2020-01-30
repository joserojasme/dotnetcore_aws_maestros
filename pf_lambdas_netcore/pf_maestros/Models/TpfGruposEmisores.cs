using System;
using System.Collections.Generic;

namespace pf_maestros.Models
{
    public partial class TpfGruposEmisores
    {
        public TpfGruposEmisores()
        {
            TpfEmisorxgrupo = new HashSet<TpfEmisorxgrupo>();
        }

        public int NmId { get; set; }
        public string DsNombreGrupo { get; set; }
        public DateTime? FeProceso { get; set; }

        public ICollection<TpfEmisorxgrupo> TpfEmisorxgrupo { get; set; }
    }
}
