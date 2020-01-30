using System;
using System.Collections.Generic;

namespace pf_gestionarPrimeraRecarga.Models
{
    public partial class TpfRangosFact
    {
        public int NmId { get; set; }
        public int NmIdEmisor { get; set; }
        public int? NmInicio { get; set; }
        public int? NmFin { get; set; }
        public string DsPrefijo { get; set; }
        public string DsResolucionDian { get; set; }
        public string DsClaveTecnica { get; set; }
        public DateTime? FeResolucion { get; set; }
        public DateTime? FeExpedicion { get; set; }
        public DateTime? FeVencimiento { get; set; }
        public string CdEstado { get; set; }
        public string SnContingencia { get; set; }
        public DateTime? FeInicioContingencia { get; set; }
        public DateTime? FeFinContingencia { get; set; }

        public TpfEmisores NmIdEmisorNavigation { get; set; }
    }
}
