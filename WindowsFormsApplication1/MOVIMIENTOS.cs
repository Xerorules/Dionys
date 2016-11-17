using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class MOVIMIENTOS : Form
    {
        public string m_id_caja;
        public string m_id_empleado;
        public string m_id_puntoventa;
        public string m_id_empresa;
        public string m_nombre_empleado;
        public string m_tipo_cambio;
        public string m_sede;
        public MOVIMIENTOS()
        {
            InitializeComponent();
        }

        private void MOVIMIENTOS_Load(object sender, EventArgs e)
        {
                //CON ESTO PUEDO VERIFICO SI TENGO UNA CAJA ABIERTA  Y SINO ES ASI, ABRIR UNA CAJA NUEVA
             /*   if (Properties.Settings.Default.id_caja == string.Empty)
                {
                    //mandar a formulario caja
                }

                FILTRAR_CAJA_KARDEX(0, "1", "");
                ESTADO_TRANSACCION(1);
                LLENAR_COMBO_TIPOMOV_PAGO();
                SELECCIONAR_REGISTRO_CARGADATA(); //AQUI CARGO POR PRIMERA VEZ TODOS LOS CAMPOS SELECIONADOS DE LA GRILLA
                ESTADO_TEXBOX_VENTA(2); //PARA PONER EN ESTADO DE BLOQUEADO A LOS TEXBOX DE LA VENTA
            */
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCANCELAR_Click(object sender, EventArgs e)
        {
            this.Hide();
            CAJA OBJCAJA = new CAJA();
            OBJCAJA.txtIDcaja.Text = Properties.Settings.Default.id_caja;
            OBJCAJA.id_empleado = m_id_empleado;
            OBJCAJA.id_puntoventa = m_id_puntoventa;
            OBJCAJA.sede = m_sede;
            OBJCAJA.tipo_cambio = m_tipo_cambio;
            OBJCAJA.nombre_empleado = m_nombre_empleado;
            OBJCAJA.id_empresa = m_id_empresa;
            OBJCAJA.Show();
        }
    }
}
