using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAPA_ENTIDAD
{
    public class E_MANT_CLIENTE
    {
        #region VARIABLLES_MANT_CLIENTE
        public string ID_CLIENTE { get; set; }
        public string TIPO_CLIENTE { get; set; }
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
        public string ACCION { get; set; }
        #endregion


        #region VAR_FILTRO_CLIENTE
        public string FILTRO_TIPOCLIENTE { get; set; }
        public int FILTRO_TIPOBUSQUEDA { get; set; }
        public string FILTRO_DATO { get; set; }
        #endregion




        #region opcionales variables globales
        public string factor1 { get; set; }
        public string factor2 { get; set; }
        public string factor3 { get; set; }
        #endregion
    }
}
