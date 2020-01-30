using System;
using System.Collections.Generic;

namespace pf_maestros.Models
{
    public partial class TpfAdquirentes
    {
        public int NmId { get; set; }
        public int NmIdEmisor { get; set; }
        public string CdTipoPersona { get; set; }
        public string CdTipoIdentificacion { get; set; }
        public string DsIdentificacion { get; set; }
        public string DsDigitoVerif { get; set; }
        public string DsNombre { get; set; }
        public string DsSegundoNombre { get; set; }
        public string DsPrimerApellido { get; set; }
        public string DsSegundoApellido { get; set; }
        public string DsDireccion { get; set; }
        public string CdCiudad { get; set; }
        public string DsTelefono { get; set; }
        public string DsEmail { get; set; }
        public string NmRegimen { get; set; }
        public string NmResponFiscales { get; set; }
        public string CdAdqResponsable { get; set; }
        public string CdEstado { get; set; }
        public DateTime? FeProceso { get; set; }

        public TpfEmisores NmIdEmisorNavigation { get; set; }
    }
}
