using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using System.Data;
using System.Data.Sql;
using CAPA_ENTIDAD;
using CAPA_DATOS;

namespace CAPA_NEGOCIO
{
    public class N_LOGUEO
    {
        D_LOGUEO OBJLOGUEO = new D_LOGUEO();

        public DataTable VALIDAR_USUARIO(string USUARIO, string CONTRASENA, string ID_SEDE)
        {
            return OBJLOGUEO.VALIDAR_USUARIO(USUARIO, CONTRASENA, ID_SEDE);
        }

        
        public DataTable LISTAR_EMPRESA()
        {
            return OBJLOGUEO.LISTAR_EMPRESA();
        }
        public DataTable LISTAR_SEDE(string ID_EMPRESA)
        {
            return OBJLOGUEO.LISTAR_SEDE(ID_EMPRESA);
        }
        public DataTable PUNTO_VENTA(string ID_SEDE)
        {
            return OBJLOGUEO.PUNTO_VENTA(ID_SEDE);
        }
        public DataTable CONSULTAR_VISTA_EMPRESA(String ID_EMPRESA)
        {
            return OBJLOGUEO.CONSULTAR_VISTA_EMPRESA(ID_EMPRESA);
        }
        public DataTable CONSULTAR_VISTA_SEDE(String ID_SEDE)
        {
            return OBJLOGUEO.CONSULTAR_VISTA_SEDE(ID_SEDE);
        }
    }
}
