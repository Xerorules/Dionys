using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAPA_ENTIDAD
{
    public class E_MANT_EMPLEADOS
    {
        #region VARIABLES_MANT_EMPLEADOS
        public string ID_EMPLEADO { get; set; }
        public string NOMBRE { get; set; }
        public string APELLIDOS { get; set; }
        public string DNI_USUARIO { get; set; }
        public string CONTRASENA { get; set; }
        public string DIRECCION { get; set; }
        public string FECHA_NAC { get; set; }
        public string TELEFONO { get; set; }
        public string MOVIL { get; set; }
        public string EMAIL { get; set; }
        public bool ESTADO { get; set; }
        public string UBIDST { get; set; }
        public string ID_CARGO { get; set; }
        public string ID_SEDE { get; set; }
        public string ID_AREA { get; set; }
        public int ACCION { get; set; }
        #endregion

    }
}
