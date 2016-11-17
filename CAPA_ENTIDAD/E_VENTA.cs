using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAPA_ENTIDAD
{
    public class E_VENTA
    {
        #region MyRegion
        public string ID_TIPOBIEN { get; set; }
        public string BIEN { get; set; }

        #endregion



        #region BIEN_X_CLASE
        public string ID_CLASE { get; set; }
        public string ID_EMPRESA { get; set; }

        #endregion

        #region VARIABLES_BUSQUEDA_BIENES
        public string OPCION_CLASE_BUSCAR { get; set; }
        public string ID_BIEN_BUSCAR { get; set; }
        public string DESCRIPCION_BUSCAR { get; set; }

        #endregion

    }
}
