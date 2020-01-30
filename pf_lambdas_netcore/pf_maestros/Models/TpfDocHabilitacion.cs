using System;
using System.Collections.Generic;

namespace pf_maestros.Models
{
    public partial class TpfDocHabilitacion
    {
        public int NmId { get; set; }
        public string DsTipoDoc { get; set; }
        public string DsPrefijoDoc { get; set; }
        public string DsNumDoc { get; set; }
        public string DsJsonDocumento { get; set; }
    }
}
