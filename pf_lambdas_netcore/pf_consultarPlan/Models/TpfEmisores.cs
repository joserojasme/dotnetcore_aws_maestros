using System;
using System.Collections.Generic;

namespace pf_consultarPlan.Models
{
    public partial class TpfEmisores
    {
        public TpfEmisores()
        {
            TpfDocumentos = new HashSet<TpfDocumentos>();
            TpfRangosFact = new HashSet<TpfRangosFact>();
            TpfRecargas = new HashSet<TpfRecargas>();
            TpfSaldos = new HashSet<TpfSaldos>();
        }

        public int NmId { get; set; }
        public int NmIdPersona { get; set; }
        public string CdTipoPersona { get; set; }
        public string CdTipoRegimen { get; set; }
        public string DsTokenSeguridad { get; set; }
        public string DsObservacion { get; set; }
        public string DsEmailRemitente { get; set; }
        public string CdRetenedorImpuestos { get; set; }
        public string DsLogo { get; set; }
        public DateTime FeProceso { get; set; }

        public TpfPersonas NmIdPersonaNavigation { get; set; }
        public ICollection<TpfDocumentos> TpfDocumentos { get; set; }
        public ICollection<TpfRangosFact> TpfRangosFact { get; set; }
        public ICollection<TpfRecargas> TpfRecargas { get; set; }
        public ICollection<TpfSaldos> TpfSaldos { get; set; }
    }
}
