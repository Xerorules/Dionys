using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CAPA_NEGOCIO;
using CAPA_ENTIDAD;
using System.Globalization;

namespace WindowsFormsApplication1
{
    public partial class CAJA : Form
    {
        public string id_caja;
        public string id_puntoventa;
        public string id_empleado;
        public string id_empresa;
        public string nombre_empleado;
        public string tipo_cambio;
        public string sede;
        

        

        public CAJA()
        {
            InitializeComponent();
        }
                     
        private void CAJA_Load(object sender, EventArgs e)
        {
            
            if (id_caja == string.Empty)
            {
                HABILITAR_CONTROLES(2); //HABILITA LOS CONTROLES PARA PODER HABILITAR UN CAJA
                btnVentaRapida.Enabled = false;
                //ESTO ES PARA CARGAR EL SALDO ANTERIOR DE LA CORRESPONDIENTE CAJA

                DataTable DT = new DataTable();

                DT = OBJ_N_MANTCAJA.OBTENER_SALDO_CAJA(id_puntoventa);
                if (DT.Rows.Count != 0)
                {
                    txtSaldoInicial.Text = DT.Rows[0][0].ToString();
                    txtSaldoFinal.Text = DT.Rows[0][0].ToString();
                }

               


                //================================================================
            }
            else
            {
                
                HABILITAR_CONTROLES(1); // CON ESTA OPCION SE PONE EN ESTADO DE CONSULTA DE CAJA
                CONSULTAR_CAJA();
                btnVentaRapida.Enabled = true;
            }



        }
        //class para retornar del formulario padre
        

        #region OBJETOS

        E_MANTENIMIENTO_CAJA OBJ_E_MANTCAJA = new E_MANTENIMIENTO_CAJA();
        E_VARIABLES_GLOBALES OBJVARIABLES = new E_VARIABLES_GLOBALES();
        N_VENTA OBJ_N_MANTCAJA = new N_VENTA();
        

        #endregion

        public void CONSULTAR_CAJA()
        {
            
        DataTable dt = new DataTable();
            dt = OBJ_N_MANTCAJA.CONSULTAR_CAJA(txtIDcaja.Text);///cambiar a objvariables.idcaja

            if (dt.Rows.Count != 0) {
                txtFchaApertura.Text = dt.Rows[0]["FECHA_INICIAL"].ToString(); //AQUI RECUPERO LA FECHA DE APERTURA QUE SE HIZO EN UN PRINCIPIO
                txtFchaCierre.Text = DateTime.Now.ToString();
                txtIDcaja.Text = dt.Rows[0]["ID_CAJA"].ToString();
                txtSaldoInicial.Text = dt.Rows[0]["SALDO_INICIAL"].ToString();
                txtSaldoFinal.Text = dt.Rows[0]["SALDO_FINAL"].ToString();
                txtObs.Text = dt.Rows[0]["OBSERVACION"].ToString();

                
                

            }
        }


        public void btnSalirCaja_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            LOGIN objlogueo = new LOGIN();
            objlogueo.Visible = true;
            
        }

        
       
        public void btnAbrirCaja_Click(object sender, EventArgs e)
        {
            
            
            DataTable DT = OBJ_N_MANTCAJA.VALIDAR_RESTRICCIONES_ABRIR_CAJA(id_puntoventa);
            if (DT.Rows.Count == 0) {

                if (txtSaldoInicial.Text.ToString() != string.Empty)
                {

                    OBJ_E_MANTCAJA.ID_CAJA = string.Empty;
                    OBJ_E_MANTCAJA.SALDO_INICIAL = double.Parse(txtSaldoInicial.Text.ToString());
                    OBJ_E_MANTCAJA.OBSERVACION = txtObs.Text.ToString();
                    OBJ_E_MANTCAJA.ID_EMPLEADO = id_empleado;
                    OBJ_E_MANTCAJA.ID_PUNTOVENTA = id_puntoventa;
                    OBJ_E_MANTCAJA.OPCION = 1;

                    OBJ_N_MANTCAJA.MANTENIMIENTO_CAJA(OBJ_E_MANTCAJA);
                    OBJVARIABLES.Idcaja = OBJ_E_MANTCAJA.ID_CAJA;
                    OBJ_E_MANTCAJA.SALDO_INICIAL = double.Parse(txtSaldoInicial.Text.ToString());
                    HABILITAR_CONTROLES(1);
                    CONSULTAR_CAJA();
                    
                    InterfazVenta objint = new InterfazVenta();
                    objint.lblCajaIDVentas.Text = OBJVARIABLES.Idcaja.ToString();
                    Program.id_caja = OBJVARIABLES.Idcaja.ToString();
                    /*---VARIABLE id_caja GUARDA VALOR AUN DESPUES DE CERRAR LA APLICACION---*/
                    Properties.Settings.Default.id_caja = OBJVARIABLES.Idcaja.ToString();
                    Properties.Settings.Default.Save();
                    Properties.Settings.Default.Upgrade();
                    /*-----------------------------------------------------------------------*/
                    /*---VARIABLE id_empresa GUARDA VALOR AUN DESPUES DE CERRAR LA APLICACION---*/
                    
                    /*-----------------------------------------------------------------------*/
                    objint.v_id_empleado = id_empleado;
                    objint.v_id_puntoventa = id_puntoventa;
                    Program.id_empresa = id_empresa;
                    objint.v_id_empresa = Program.id_empresa;
                    objint.v_nombre_empleado = nombre_empleado;
                    objint.v_tipo_cambio = tipo_cambio;
                    objint.v_sede = sede;
                    objint.ShowDialog();
                    this.Visible = false;
                   
                }
            }
            else
            {
                MessageBox.Show("NO PUEDE ABRIR CAJA, PORQUE EXISTE UNA CAJA ABIERTA EN ESTE PUNTO DE VENTA");
            }
        }

        public void HABILITAR_CONTROLES(int ESTADO)
        {
            if (ESTADO == 1) //ESTADO 1 SIGNIIFCA QUE ESTA EN CONSULTA CIERRE DE CAJA
            {
                txtFchaApertura.ReadOnly = true;
                txtFchaCierre.Text = DateTime.Now.ToString();
                txtFchaCierre.ReadOnly = true;
                txtIDcaja.ReadOnly = true;
                txtSaldoInicial.ReadOnly = true;
                txtSaldoFinal.ReadOnly = true;
                txtObs.ReadOnly = true;
                btnAbrirCaja.Enabled = false;
                btnCERRARCAJA.Enabled = true;
            }
            if (ESTADO == 2) // ESTADO 2 INDICA QUE VA A APERTURAR CAJA
            {
                txtFchaApertura.Text = DateTime.Now.ToString();
                txtFchaApertura.ReadOnly = true;
                txtFchaCierre.ReadOnly = true;
                txtIDcaja.ReadOnly = true;
                txtSaldoInicial.ReadOnly = false;
                txtSaldoFinal.ReadOnly = true;
                txtObs.ReadOnly = false;
                btnAbrirCaja.Enabled = true;
                btnCERRARCAJA.Enabled = false;
            }

        }

        private void btnCERRARCAJA_Click_1(object sender, EventArgs e)
        {
            
            string ID_ADMIN = "";
            if (id_empresa == "001")
            {
                ID_ADMIN = "PV005";
            }
            else
            {
                if (id_empresa == "003")
                {
                    ID_ADMIN = "PV010";
                }
                else
                {
                    if (id_empresa == "004")
                    {
                        ID_ADMIN = "PV011";
                    }
                }

            }
            DataTable dt = OBJ_N_MANTCAJA.VALIDAR_EXISTENCIA_CAJAADMINISTRACION(ID_ADMIN);

            if (dt.Rows.Count > 0)
            {
                if (txtFchaApertura.Text.ToString() != string.Empty && txtFchaCierre.Text.ToString() != string.Empty &&
                    txtIDcaja.Text.ToString() != string.Empty && txtSaldoInicial.Text.ToString() != string.Empty && txtSaldoFinal.Text.ToString() != string.Empty)
                {
                    OBJ_E_MANTCAJA.ID_CAJA = txtIDcaja.Text.ToString();
                    OBJ_E_MANTCAJA.SALDO_INICIAL = Convert.ToDouble(txtSaldoInicial.Text.ToString());
                    OBJ_E_MANTCAJA.OBSERVACION = txtObs.Text.ToString();
                    OBJ_E_MANTCAJA.ID_EMPLEADO = id_empleado;
                    OBJ_E_MANTCAJA.ID_PUNTOVENTA = id_puntoventa;
                    OBJ_E_MANTCAJA.OPCION = 2;


                    //AQUI TENEMOS EL CODIGO PARA PASAR LA INFORMACION DE CADA CAJA A LA CAJA ADMINISTRACION
                    //=====================================================================================
                    NumberFormatInfo provider = new NumberFormatInfo();
                    provider.NumberDecimalSeparator = ".";
                    provider.NumberGroupSeparator = ",";
                    provider.NumberGroupSizes = new int[] { 2 };

                    OBJ_N_MANTCAJA.MOVIMIENTOS_XDIA_CAJAS(nombre_empleado, txtIDcaja.Text.ToString(), Convert.ToDouble(tipo_cambio), "1", (-1) * Convert.ToDouble(txtSaldoFinal.Text.ToString(), provider), sede);
                    OBJ_N_MANTCAJA.MOVIMIENTOS_XDIA_CAJAS(nombre_empleado, txtIDcaja.Text.ToString(), Convert.ToDouble(tipo_cambio), "2", (Convert.ToDouble(txtSaldoFinal.Text.ToString(), provider)), sede);

                    // ====================================================================================

                    OBJ_N_MANTCAJA.MANTENIMIENTO_CAJA(OBJ_E_MANTCAJA);
                    id_caja = string.Empty;
                    string id = id_caja;
                    HABILITAR_CONTROLES(2); // CON ESTA OPCION SE PONE EN ESTADO DE CONSULTA DE CAJA
                    if (this.Width >= 1100)
                    {
                        button2.Location = new Point(1190, 226);
                        this.Width = 1079;
                        button2.Text = "EXP AND I R";
                    }
                    lblMENSAJES.Text = string.Empty;

                }
            }
            else
            {
                MessageBox.Show("NO PUEDE CERRAR CAJA, PORQUE NO HAY UNA CAJA ADMINISTRACION ABIERTA");
            }
        }

        private void btnVentaRapida_Click(object sender, EventArgs e)
        {
            if (id_caja != string.Empty) //SI ES DIFERENTE DE VACIO ES PORQUE EL USUARIO  ID_USUARIO Y EL PUNTO DE VENTA ID_PUNTOVENTA TIENE CAJA APERTURADA
            {

                InterfazVenta objventa = new InterfazVenta();
                objventa.lblCajaIDVentas.Text = Program.id_caja;
                objventa.v_id_empleado = id_empleado;
                objventa.v_id_puntoventa = id_puntoventa;
                objventa.v_id_empresa = id_empresa;
                objventa.v_nombre_empleado = nombre_empleado;
                objventa.v_tipo_cambio = tipo_cambio;
                objventa.v_sede = sede;
                objventa.ShowDialog();
                this.Width = 1079;
                this.Hide();
            }
            else
            {
                lblMENSAJES.Text = "¡¡NO TIENES CAJA ABIERTA, PRIMERO APERTURA UNA CAJA!!";
            }
        }

        public new Point Location { get; set; }
        private void button2_Click(object sender, EventArgs e)
        {
            if (id_caja != string.Empty) {
                if (this.Width == 1079)
                {
                    this.Width = 1360;
                    button2.Location = new Point(1330, 226);
                    button2.Text = "CON TRA E R";
                }
                else
                {
                    if (this.Width >= 1100)
                    {
                        button2.Location = new Point(1190, 226);
                        this.Width = 1079;
                        button2.Text = "EXP AND I R";
                    }
                }
            }
            else
            {
                lblMENSAJES.Text = "¡¡NO TIENES CAJA ABIERTA, PRIMERO APERTURA UNA CAJA!!";
            }
        }

        private void btnMOVIMIENTOS_Click(object sender, EventArgs e)
        {
            if (id_caja != string.Empty) //SI ES DIFERENTE DE VACIO ES PORQUE EL USUARIO  ID_USUARIO Y EL PUNTO DE VENTA ID_PUNTOVENTA TIENE CAJA APERTURADA
            {

                MOVIMIENTOS objMOV= new MOVIMIENTOS();
                objMOV.m_id_caja = Program.id_caja;
                objMOV.m_id_empleado = id_empleado;
                objMOV.m_id_puntoventa = id_puntoventa;
                objMOV.m_id_empresa = id_empresa;
                objMOV.m_nombre_empleado = nombre_empleado;
                objMOV.m_tipo_cambio = tipo_cambio;
                objMOV.m_sede = sede;
                objMOV.ShowDialog();
                this.Width = 1079;
                this.Visible = false;
            }
            else
            {
                lblMENSAJES.Text = "¡¡NO TIENES CAJA ABIERTA, PRIMERO APERTURA UNA CAJA!!";
            }
        }
    }
}
