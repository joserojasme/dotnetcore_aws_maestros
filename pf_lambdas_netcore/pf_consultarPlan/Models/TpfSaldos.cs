using System;
using System.Collections.Generic;

namespace pf_consultarPlan.Models
{
    public partial class TpfSaldos
    {
        public int NmId { get; set; }
        public int NmIdEmisor { get; set; }
        public int NmSaldo { get; set; }
        public DateTime? FeProceso { get; set; }

        public TpfEmisores NmIdEmisorNavigation { get; set; }
    }
}
