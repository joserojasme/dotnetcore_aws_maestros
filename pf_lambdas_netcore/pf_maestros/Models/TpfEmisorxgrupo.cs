using System;
using System.Collections.Generic;

namespace pf_maestros.Models
{
    public partial class TpfEmisorxgrupo
    {
        public int NmId { get; set; }
        public int NmIdEmisor { get; set; }
        public int NmIdGrupo { get; set; }
        public DateTime FeProceso { get; set; }

        public TpfEmisores NmIdEmisorNavigation { get; set; }
        public TpfGruposEmisores NmIdGrupoNavigation { get; set; }
    }
}
