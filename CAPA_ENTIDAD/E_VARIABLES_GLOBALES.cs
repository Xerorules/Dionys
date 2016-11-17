using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAPA_ENTIDAD
{
    public class E_VARIABLES_GLOBALES
    {
        public E_VARIABLES_GLOBALES() { }
        public string id_empleado { get; set;}
        public string nombre_empleado { get; set;}

        private string idcaja;
        public string saldo_inicial { get; set;}
        public string id_puntoventa { get; set;}
        public string id_empresa { get; set;}
        public string tipo_cambio { get; set;} 
        public string sede { get; set;}

        public string Idcaja
        {
            get
            {
                return idcaja;
            }

            set
            {
                idcaja = value;
            }
        }
    }
}
