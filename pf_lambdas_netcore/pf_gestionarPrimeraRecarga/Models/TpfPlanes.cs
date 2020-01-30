using System;
using System.Collections.Generic;

namespace pf_gestionarPrimeraRecarga.Models
{
    public partial class TpfPlanes
    {
        public TpfPlanes()
        {
            TpfRecargas = new HashSet<TpfRecargas>();
        }

        public int NmId { get; set; }
        public string DsDescripcion { get; set; }
        public int NmCantDoc { get; set; }
        public int NmDocRegalo { get; set; }
        public float NmValor { get; set; }
        public DateTime? FeProceso { get; set; }
        public string CdEstado { get; set; }
        public string CdVisible { get; set; }

        public ICollection<TpfRecargas> TpfRecargas { get; set; }
    }
}
