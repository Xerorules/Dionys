using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAPA_ENTIDAD
{
    public class E_PEDIDO
    {
        public string ID_PEDIDO { get; set; }
        public string ID_EMPLEADO { get; set; }
        public string CLIENTE { get; set; }
        public double VALOR_VENTA { get; set; }
        public double IGV { get; set; }
        public double TOTAL { get; set; }
        public string MONEDA { get; set; }
        public string OBSERVACION { get; set; }
        public string FECHA_ANULADO { get; set; }
        public string FECHA_ATENDIDO { get; set; }
        public string ID_SEDE { get; set; }
        public string ACCION { get; set; }
    }
}
