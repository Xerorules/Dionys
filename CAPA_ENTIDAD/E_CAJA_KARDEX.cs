using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAPA_ENTIDAD
{
    public class E_CAJA_KARDEX
    {
        #region VARIABLES CAJA_KARDEX

        public string ID_MOVIMIENTO { get; set; }
        public string DESCRIPCION { get; set; }
        public string ID_COMPVENT { get; set; }
        public string ID_TIPOPAGO { get; set; }
        public string ID_TIPOMOV { get; set; }
        public double IMPORTE { get; set; }
        public string MONEDA { get; set; }
        public double TIPO_CAMBIO { get; set; }
        public double AMORTIZADO { get; set; }
        public string ID_CAJA { get; set; }
        public double IMPORTE_CAJA { get; set; }
        public int OPCION { get; set; }

        #endregion
    }
}
