using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;

namespace WindowsFormsApplication1
{
    public static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        public static string id_caja; //Program.id_caja
        public static string id_empresa;
        public static string id_cliente;
        public static string id_sede;
       
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LOGIN());
        }
    }
}
