﻿using System;
using System.Collections.Generic;

namespace pf_consultarPlan.Models
{
    public partial class TpfDocumentos
    {
        public int NmId { get; set; }
        public int NmIdEmisor { get; set; }
        public string DsTipoDoc { get; set; }
        public string DsPrefijoDoc { get; set; }
        public string DsNumDoc { get; set; }
        public string DsIdAquirente { get; set; }
        public DateTime FeFactura { get; set; }
        public DateTime? FeProceso { get; set; }
        public DateTime? FeModifica { get; set; }
        public string CdEstado { get; set; }
        public string DsJsonDocumento { get; set; }

        public TpfEmisores NmIdEmisorNavigation { get; set; }
    }
}
