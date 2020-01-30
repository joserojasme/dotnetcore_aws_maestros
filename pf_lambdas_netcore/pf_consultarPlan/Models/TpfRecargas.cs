using System;
using System.Collections.Generic;

namespace pf_consultarPlan.Models
{
    public partial class TpfRecargas
    {
        public int NmId { get; set; }
        public int NmIdEmisor { get; set; }
        public int NmIdPlan { get; set; }
        public DateTime? FeProceso { get; set; }

        public TpfEmisores NmIdEmisorNavigation { get; set; }
        public TpfPlanes NmIdPlanNavigation { get; set; }
    }
}
