using System;
using System.Collections.Generic;

namespace pf_maestros.Models
{
    public partial class TpfResolucionEmisor
    {
        public int NmId { get; set; }
        public int NmIdEmisor { get; set; }
        public int? NmInicio { get; set; }
        public int? NmFin { get; set; }
        public string DsPrefijo { get; set; }
        public string DsResolucionDian { get; set; }
        public DateTime? FeVencimiento { get; set; }
        public string CdEstado { get; set; }
        public DateTime FeProceso { get; set; }

        public TpfEmisores NmIdEmisorNavigation { get; set; }
    }
}
