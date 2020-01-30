using System;
using System.Collections.Generic;

namespace pf_maestros.Models
{
    public partial class TpfProductos
    {
        public int NmId { get; set; }
        public int NmIdEmisor { get; set; }
        public string DsCodigo { get; set; }
        public string DsDescripcion { get; set; }
        public decimal NmValorUnitario { get; set; }
        public int? NmPorcentajeIva { get; set; }
        public int? NmPorcentajeInc { get; set; }
        public string CdEstado { get; set; }
        public string NmUnidadMedida { get; set; }
        public string NmMarca { get; set; }
        public string NmModelo { get; set; }
        public DateTime? FeProceso { get; set; }

        public TpfEmisores NmIdEmisorNavigation { get; set; }
    }
}
