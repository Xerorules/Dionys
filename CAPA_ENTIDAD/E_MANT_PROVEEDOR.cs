using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAPA_ENTIDAD
{
    public class E_MANT_PROVEEDOR
    {
        #region VARIABLLES_MANT_PROVEEDOR
        public string ID_PROVEEDOR { get; set; }
        public string TIPO_PROVEEDOR { get; set; }
        public string ORIGEN_PROVEEDOR { get; set; }
        public string DESCRIPCION { get; set; }
        public string RUC_DNI { get; set; }
        public string DIRECCION { get; set; }
        public string TELEFONO_1 { get; set; }
        public string TELEFONO_2 { get; set; }
        public string MOVIL { get; set; }
        public string FECHA_NAC { get; set; }
        public string EMAIL { get; set; }
        public string WEB_SITE { get; set; }
        public bool ESTADO { get; set; }
        public string UBIDST { get; set; }
        public int ACCION { get; set; }
        #endregion

    }
}
