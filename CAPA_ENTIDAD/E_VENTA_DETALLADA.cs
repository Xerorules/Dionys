using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAPA_ENTIDAD
{
    public class E_VENTA_DETALLADA
    {
        #region VARIABLES_VENTAS

        public string ID_VENTA { get; set; }
        public string FECHA { get; set; }
        public string SERIE { get; set; }
        public string TIPO_DOC { get; set; }
        public string MONEDA { get; set; }
        public double VALOR_VENTA { get; set; }
        public double IGV { get; set; }
        public double TOTAL { get; set; }
        public double SALDO { get; set; }
        public string ID_SEDE { get; set; }
        public string ID_PEDIDO { get; set; }
        public string ID_CLIENTE { get; set; }
        public string CLIENTE { get; set; }
        public string ACCION { get; set; }

        #endregion
        #region VARIABLES_VENTASDETALLES
        public string ID_BIEN { get; set; }
        public int ITEM { get; set; }
        public double CANTIDAD { get; set; }
        public double PRECIO { get; set; }
        public double IMPORTE { get; set; }
        public double SALDO_CANTIDAD { get; set; }


        #endregion
    }
}
