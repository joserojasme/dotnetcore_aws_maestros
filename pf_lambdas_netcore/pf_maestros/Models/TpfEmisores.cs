using System;
using System.Collections.Generic;

namespace pf_maestros.Models
{
    public partial class TpfEmisores
    {
        public TpfEmisores()
        {
            TpfAdquirentes = new HashSet<TpfAdquirentes>();
            TpfDocumentos = new HashSet<TpfDocumentos>();
            TpfEmisorxgrupo = new HashSet<TpfEmisorxgrupo>();
            TpfProductos = new HashSet<TpfProductos>();
            TpfRecargas = new HashSet<TpfRecargas>();
            TpfResolucionEmisor = new HashSet<TpfResolucionEmisor>();
            TpfSaldos = new HashSet<TpfSaldos>();
        }

        public int NmId { get; set; }
        public int NmIdPersona { get; set; }
        public string CdTipoPersona { get; set; }
        public string CdTipoRegimen { get; set; }
        public string CdGrupo { get; set; }
        public string DsTokenSeguridad { get; set; }
        public string DsObservacion { get; set; }
        public string DsEmailRemitente { get; set; }
        public string CdRetenedorImpuestos { get; set; }
        public string DsLogo { get; set; }
        public DateTime FeProceso { get; set; }
        public string DsPiePagina { get; set; }
        public string CdVersion { get; set; }
        public string CdHabilitado { get; set; }

        public TpfPersonas NmIdPersonaNavigation { get; set; }
        public ICollection<TpfAdquirentes> TpfAdquirentes { get; set; }
        public ICollection<TpfDocumentos> TpfDocumentos { get; set; }
        public ICollection<TpfEmisorxgrupo> TpfEmisorxgrupo { get; set; }
        public ICollection<TpfProductos> TpfProductos { get; set; }
        public ICollection<TpfRecargas> TpfRecargas { get; set; }
        public ICollection<TpfResolucionEmisor> TpfResolucionEmisor { get; set; }
        public ICollection<TpfSaldos> TpfSaldos { get; set; }
    }
}
