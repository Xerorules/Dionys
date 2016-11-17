using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAPA_ENTIDAD
{
    public class E_MANTENIMIENTO_CAJA
    {
        public string ID_CAJA { get; set; }
        public double SALDO_INICIAL { get; set; }
        public string ID_EMPLEADO { get; set; }
        public string ID_PUNTOVENTA { get; set; }
        public string OBSERVACION { get; set; }
        public int OPCION { get; set; }
    }
}
