using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CAPA_ENTIDAD;
using CAPA_NEGOCIO;

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
               if (Properties.Settings.Default.id_caja == string.Empty)
                {
                    CAJA objcaja = new CAJA();
                    objcaja.ShowDialog();
                    this.Hide();
                }

                lblEmpresa.Text = Properties.Settings.Default.nomempresa;
                lblUsuario.Text = Properties.Settings.Default.nomempleado;
                lblSede.Text = Properties.Settings.Default.nomsede;
                lblFecha.Text = DateTime.Today.ToShortDateString();
                rdbSOLES.Checked = true;
                rdbTICKET.Checked = true;
                FILTRAR_CAJA_KARDEX(0, "1", "");
                ESTADO_TRANSACCION(1);
                LLENAR_COMBO_TIPOMOV();
                LLENAR_COMBO_TIPOPAGO();
                SELECCIONAR_REGISTRO_CARGADATA(); //AQUI CARGO POR PRIMERA VEZ TODOS LOS CAMPOS SELECIONADOS DE LA GRILLA
                ESTADO_TEXBOX_VENTA(2); //PARA PONER EN ESTADO DE BLOQUEADO A LOS TEXBOX DE LA VENTA
            
        }

        #region OBJETOS
        N_VENTA N_OBJVENTAS = new N_VENTA();
        N_LOGUEO N_OBJEMPRESA = new N_LOGUEO();
        E_CAJA_KARDEX E_OBJCAJA_KARDEX = new E_CAJA_KARDEX();

        #endregion


        #region FUNCIONES


        private bool VALIDAR_DATOS_CAJA_KARDEX()
        {

            bool RESULTADO = false;
            //ESTE SEGMENTO HAY QUE MODIFICAR POSTERIORMENTE EL COMBO DE ID_TIPO_MOV  
            try
            {
                if (cboTIPO_MOV.SelectedIndex != -1)
                {
                    if (cboTIPO_PAGO.SelectedItem.ToString() != string.Empty)
                    {
                        if (txtMONTO.Text != string.Empty)
                        {
                            if (rdbSOLES.Checked == true)
                            {
                                if (txtDESCRIPCION.Text != string.Empty)
                                {
                                    if (cboTIPO_MOV.SelectedValue.ToString() == "IPV" || cboTIPO_MOV.SelectedValue.ToString() == "EPC")
                                    {
                                        if (txtID_DOC.Text != string.Empty)
                                        {
                                            if (txtSALDO.Text != string.Empty)
                                            {
                                                RESULTADO = true;
                                            }
                                            else
                                            {
                                                RESULTADO = false;
                                            }

                                        }
                                        else
                                        {
                                            RESULTADO = false;
                                        }

                                    }
                                    else
                                    {
                                        RESULTADO = true;
                                    }
                                }
                                else
                                {
                                    RESULTADO = false;
                                }

                            }
                            else
                            {
                                RESULTADO = false;
                            }
                        }
                        else
                        {
                            RESULTADO = false;
                        }
                    }
                    else
                    {
                        RESULTADO = false;
                    }
                }
                else
                {
                    RESULTADO = false;
                }
            }
            catch (Exception)
            {

                MessageBox.Show("LOS DATOS ESTAN INCOMPLETOS");
            }


            return RESULTADO;
        }


        #endregion

        #region PROCEDIMIENTOS
        void FILTRAR_CAJA_KARDEX(int OPCION, string VER, string DESCRIPCION)
        {
            double TOTAL_CAJA, TOTAL_SOLES, TOTAL_DOLARES;
            TOTAL_CAJA = 0.00;
            TOTAL_SOLES = 0.00;
            TOTAL_DOLARES = 0.00;

            DataTable dt = new DataTable();
            string ID_MOVIMIENTO = string.Empty;
            string ID_CAJA = Properties.Settings.Default.id_caja;
            string TIPO_PAGO = string.Empty;
            string ID_TIPOMOV = string.Empty;
            string OPCION_USUARIO = string.Empty;

            //if (Session["ID_PUNTOVENTA"].ToString() == "PV010" || Session["ID_PUNTOVENTA"].ToString() == "PV005")
            //{
            //    OPCION_USUARIO = "ADMINISTRADOR";
            //}
            //else
            //{
            //    OPCION_USUARIO = "CAJERO";
            //}
            dt = N_OBJVENTAS.FILTRAR_CAJA_KARDEX(ID_MOVIMIENTO, ID_CAJA, DESCRIPCION, TIPO_PAGO, ID_TIPOMOV, OPCION, VER);
            dgvMOV_CAJAKARDEX.DataSource = dt;
            




            for (int i = 0; i < dt.Rows.Count; i++)
            {
                TOTAL_CAJA = TOTAL_CAJA + Convert.ToDouble(dt.Rows[i]["IMPORTE_CAJA"]);
                if (dt.Rows[i]["MONEDA"].ToString() == "S")
                {
                    if (dt.Rows[i]["ID_TIPOMOV"].ToString().Substring(0, 1) == "I")
                    {
                        TOTAL_SOLES = TOTAL_SOLES + Convert.ToDouble(dt.Rows[i]["IMPORTE"]);
                    }
                    else
                    {
                        TOTAL_SOLES = TOTAL_SOLES - Convert.ToDouble(dt.Rows[i]["IMPORTE"]);
                    }


                }
                else
                {
                    if (dt.Rows[i]["ID_TIPOMOV"].ToString().Substring(0, 1) == "I")
                    {
                        TOTAL_DOLARES = TOTAL_DOLARES + Convert.ToDouble(dt.Rows[i]["IMPORTE"]);
                    }
                    else
                    {

                        TOTAL_DOLARES = TOTAL_DOLARES - Convert.ToDouble(dt.Rows[i]["IMPORTE"]);
                    }
                }
            }

            txtTOTALSOLES.Text = TOTAL_SOLES.ToString("N2");
            txtTOTALDOLARES.Text = TOTAL_DOLARES.ToString("N2");
            txtTOTALCAJA.Text = TOTAL_CAJA.ToString("N2");

        }


        void LLENAR_COMBO_TIPOMOV()
        {

            cboTIPO_MOV.ValueMember = "ID_TIPOMOV";
            cboTIPO_MOV.DisplayMember = "DESCRIPCION";
            cboTIPO_MOV.DataSource = N_OBJVENTAS.LISTAR_TIPO_MOVIMIENTO();

        }

        void LLENAR_COMBO_TIPOPAGO() { 

            cboTIPO_PAGO.ValueMember = "ID_TIPOPAGO";
            cboTIPO_PAGO.DisplayMember = "DESCRIPCION";
            cboTIPO_PAGO.DataSource = N_OBJVENTAS.LISTAR_TIPO_PAGO();
        }



        void ESTADO_TRANSACCION(int ESTADO)
        {
            if (ESTADO == 1) //ESTADO CONSULTA
            {
                txtID_MOVIMIENTO.ReadOnly = true;
                txtFECHA.ReadOnly = true;
                txtFECHA_ANULADO.ReadOnly = true;
                cboTIPO_MOV.Enabled = false;
                cboTIPO_PAGO.Enabled = false;
                txtMONTO.ReadOnly = true;
                rdbSOLES.Enabled = false;
                rdbDOLARES.Enabled = false;
                txtDESCRIPCION.ReadOnly = true;
                btnNUEVO.Enabled = true;
                btnGRABAR.Enabled = false;
                btnCANCELAR.Enabled = false;
                btnANULAR.Enabled = true;
                btnIMPRIMIR.Enabled = true;
                cboTIPO_BUSQUEDA.Enabled = true;
                txtDATA_BUSQUEDA.ReadOnly = true;
                rdbACTIVOS.Enabled = true;
                rdbANULADOS.Enabled = true;
                rdbTODOS.Enabled = true;
                dgvMOV_CAJAKARDEX.Enabled = true;
                btnBUSCAR.Enabled = true;
                txtDATA_BUSQUEDA.ReadOnly = false;

            }
            if (ESTADO == 2) //ESTADO NUEVO
            {
                //LIMPIARDO CONTROLES
                txtID_MOVIMIENTO.Text = string.Empty;
                txtFECHA.Text = DateTime.Now.ToShortDateString();
                txtFECHA_ANULADO.Text = string.Empty;
                cboTIPO_MOV.SelectedIndex = 0;
                cboTIPO_PAGO.SelectedIndex = 0;
                txtMONTO.Text = string.Empty;
                txtDESCRIPCION.Text = string.Empty;
                rdbSOLES.Checked = false;
                rdbDOLARES.Checked = false;

                //===================

                txtID_MOVIMIENTO.ReadOnly = true;
                txtFECHA.ReadOnly = true;
                txtFECHA_ANULADO.ReadOnly = true;
                cboTIPO_MOV.Enabled = true;
                cboTIPO_PAGO.Enabled = true;
                txtMONTO.ReadOnly = false;
                rdbSOLES.Enabled = false;
                rdbDOLARES.Enabled = false;
                txtDESCRIPCION.ReadOnly = false;
                btnNUEVO.Enabled = false;
                btnGRABAR.Enabled = true;
                btnCANCELAR.Enabled = true;
                btnANULAR.Enabled = false;
                btnIMPRIMIR.Enabled = false;
                cboTIPO_BUSQUEDA.Enabled = false;
                txtDATA_BUSQUEDA.ReadOnly = false;
                rdbACTIVOS.Enabled = false;
                rdbANULADOS.Enabled = false;
                rdbTODOS.Enabled = false;
                dgvMOV_CAJAKARDEX.Enabled = false;
                btnBUSCAR.Enabled = false;
                txtDATA_BUSQUEDA.ReadOnly = true;
            }
        }

        public void ANULAR_CAJA_KARDEX_REGISTRO()
        {
            E_OBJCAJA_KARDEX.ID_MOVIMIENTO  = dgvMOV_CAJAKARDEX.CurrentRow.Cells[0].Value.ToString();
            E_OBJCAJA_KARDEX.DESCRIPCION = string.Empty;
            E_OBJCAJA_KARDEX.ID_COMPVENT = string.Empty;
            E_OBJCAJA_KARDEX.ID_TIPOMOV = string.Empty;
            E_OBJCAJA_KARDEX.ID_TIPOPAGO = string.Empty;
            E_OBJCAJA_KARDEX.IMPORTE = 0.00;
            E_OBJCAJA_KARDEX.MONEDA = string.Empty;
            E_OBJCAJA_KARDEX.TIPO_CAMBIO = 0.00;
            E_OBJCAJA_KARDEX.AMORTIZADO = 0.00;
            E_OBJCAJA_KARDEX.ID_CAJA = string.Empty;
            E_OBJCAJA_KARDEX.IMPORTE_CAJA = 0.00;
            E_OBJCAJA_KARDEX.OPCION = 2; //ESTA OPCION 2 ANULA AMORTIZACION

            N_OBJVENTAS.CAJA_KARDEX_MANTENIMIENTO(E_OBJCAJA_KARDEX);
        }

        private void GRABAR_CAJA_KARDEX()
        {
            try
            {
                E_OBJCAJA_KARDEX.ID_MOVIMIENTO = string.Empty;
                E_OBJCAJA_KARDEX.DESCRIPCION = txtDESCRIPCION.Text.ToString();
                if (txtID_DOC.Text != string.Empty)
                {
                    E_OBJCAJA_KARDEX.ID_COMPVENT = txtID_DOC.Text;
                }
                else
                {
                    E_OBJCAJA_KARDEX.ID_COMPVENT = string.Empty;
                }

                E_OBJCAJA_KARDEX.ID_TIPOMOV = cboTIPO_MOV.SelectedText.ToString();
                E_OBJCAJA_KARDEX.ID_TIPOPAGO = cboTIPO_PAGO.SelectedText.ToString();

                E_OBJCAJA_KARDEX.IMPORTE = Convert.ToDouble(txtMONTO.Text.ToString());

                if (rdbSOLES.Checked == true)
                {
                    E_OBJCAJA_KARDEX.MONEDA = "S";
                }
                else
                {
                    if (rdbDOLARES.Checked == true)
                    {
                        E_OBJCAJA_KARDEX.MONEDA = "D";
                    }
                }
                E_OBJCAJA_KARDEX.TIPO_CAMBIO = Convert.ToDouble(Properties.Settings.Default.tipo_cambio);

                if (txtMONEDA.Text == "S" && rdbSOLES.Checked == true)
                {
                    E_OBJCAJA_KARDEX.AMORTIZADO = Convert.ToDouble(txtMONTO.Text.ToString());
                }
                if (txtMONEDA.Text == "S" && rdbDOLARES.Checked == true)
                {
                    E_OBJCAJA_KARDEX.AMORTIZADO = Convert.ToDouble(txtMONTO.Text.ToString()) * Convert.ToDouble(Properties.Settings.Default.tipo_cambio);
                }
                if (txtMONEDA.Text == "D" && rdbSOLES.Checked == true)
                {
                    E_OBJCAJA_KARDEX.AMORTIZADO = Convert.ToDouble(txtMONTO.Text.ToString()) / Convert.ToDouble(Properties.Settings.Default.tipo_cambio);
                }
                if (txtMONEDA.Text == "D" && rdbDOLARES.Checked == true)
                {
                    E_OBJCAJA_KARDEX.AMORTIZADO = Convert.ToDouble(txtMONTO.Text.ToString());
                }


                E_OBJCAJA_KARDEX.ID_CAJA = Properties.Settings.Default.id_caja;

                string var = cboTIPO_MOV.SelectedValue.ToString();
                if (var == "I") //es un ingreso
                {

                    if (rdbSOLES.Checked == true) // esta en soles
                    {
                        E_OBJCAJA_KARDEX.IMPORTE_CAJA = Convert.ToDouble(txtMONTO.Text.ToString());
                    }
                    else //sino es dolares y mi importe caja siempre es soles
                    {
                        E_OBJCAJA_KARDEX.IMPORTE_CAJA = Math.Round(Convert.ToDouble(txtMONTO.Text.ToString()) * Convert.ToDouble(Properties.Settings.Default.tipo_cambio), 2);
                    }
                }
                else //entonces es un egreso y registro mi importe caja en negativo
                {
                    if (rdbSOLES.Checked == true) // esta en soles
                    {
                        E_OBJCAJA_KARDEX.IMPORTE_CAJA = (-1) * Convert.ToDouble(txtMONTO.Text.ToString());
                    }
                    else //sino es dolares y mi importe caja siempre es soles
                    {
                        E_OBJCAJA_KARDEX.IMPORTE_CAJA = (-1) * Math.Round(Convert.ToDouble(txtMONTO.Text.ToString()) * Convert.ToDouble(Properties.Settings.Default.tipo_cambio), 2);
                    }
                }

                E_OBJCAJA_KARDEX.OPCION = 1; //ESTA OPCION 1 INSERTA EL NUEVO REGISTRO

                N_OBJVENTAS.CAJA_KARDEX_MANTENIMIENTO(E_OBJCAJA_KARDEX);
            }
            catch (Exception)
            {
                throw;
            }

        }
        #endregion


        public void CONSULTAR_VENTAS(string OPCION)
        {

            if (cboTIPO_MOV.SelectedValue.ToString() == "IPV")
            {

                DataTable dt = new DataTable();
                dt = N_OBJVENTAS.CAPTURAR_TABLA_VENTA(OPCION,Properties.Settings.Default.id_sede.ToString());
                if (dt.Rows.Count > 0)
                {
                    txtPERSONA.Text = dt.Rows[0]["C_DESCRIPCION"].ToString();
                    txtNUM_DOCUMENTO.Text = dt.Rows[0]["V_TIPO_DOC"].ToString() + dt.Rows[0]["V_SERIE"].ToString() + dt.Rows[0]["V_NUMERO"].ToString();
                    txtMONEDA.Text = dt.Rows[0]["V_MONEDA"].ToString();
                    txtSALDO.Text = dt.Rows[0]["V_SALDO"].ToString();
                }
                else
                {
                    MessageBox.Show("ERROR, VERIFICAR SI EL NUMERO DE VENTA ES CORRECTO");
                }
            }
            if (cboTIPO_MOV.SelectedValue.ToString() == "EPC")
            {
                DataTable dt = new DataTable();
                dt = N_OBJVENTAS.CAPTURAR_TABLA_COMPRA(OPCION);
                if (dt.Rows.Count > 0)
                {
                    txtPERSONA.Text = dt.Rows[0]["P_DESCRIPCION"].ToString();
                    txtNUM_DOCUMENTO.Text = dt.Rows[0]["C_TIPO_DOC"].ToString() + dt.Rows[0]["C_SERIE"].ToString() + dt.Rows[0]["C_NUMERO"].ToString();
                    txtMONEDA.Text = dt.Rows[0]["C_MONEDA"].ToString();
                    txtSALDO.Text = dt.Rows[0]["C_SALDO"].ToString();
                }
                else
                {
                    MessageBox.Show("ERROR, VERIFICAR SI EL NUMERO DE COMPRA ES CORRECTO");
                }
            }

        }


        public void ESTADO_TEXBOX_VENTA(int ESTADO)
        {
            if (ESTADO == 1)//ESTADO DE INGRESO POR VENTA
            {
                txtID_DOC.Enabled = true;
                txtPERSONA.ReadOnly = true;
                txtNUM_DOCUMENTO.ReadOnly = true;
                txtMONEDA.ReadOnly = true;
                txtSALDO.ReadOnly = true;
            }
            if (ESTADO == 2)//ESTADOO DE BLOQUEADO
            {
                txtID_DOC.ReadOnly = true;
                txtPERSONA.ReadOnly = true;
                txtNUM_DOCUMENTO.ReadOnly = true;
                txtMONEDA.ReadOnly = true;
                txtSALDO.ReadOnly = true;
            }
            txtID_DOC.Text = string.Empty;
            txtPERSONA.Text = string.Empty;
            txtNUM_DOCUMENTO.Text = string.Empty;
            txtMONEDA.Text = string.Empty;
            txtSALDO.Text = string.Empty;
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

            ESTADO_TRANSACCION(1); //CON ESTO CONTROLAMOS LA ACTIVIDAD O INACTIVIDAD DE LOS CONTROLES
            FILTRAR_CAJA_KARDEX(0, "1", ""); //AQUI ACTUALIZO Y AGO QUE EL FILTRO SEA POR TODOS LO ACTIVOS 
            rdbACTIVOS.Checked = false;
            rdbANULADOS.Checked = false;
            rdbANULADOS.Checked = false;
            txtDATA_BUSQUEDA.Text = string.Empty; //LIMPIAR EL CAMPO DE BUSQUEDA
            dgvMOV_CAJAKARDEX.CurrentCell.Selected = false; //SELECCIONA EL PPRIMER REGISTRO
            SELECCIONAR_REGISTRO_CARGADATA(); //AQUI CARGO POR PRIMERA VEZ TODOS LOS CAMPOS SELECIONADOS DE LA GRILLA
            ESTADO_TEXBOX_VENTA(2);

        }

        private void btnNUEVO_Click(object sender, EventArgs e)
        {
            rdbSOLES.Checked = true;
            ESTADO_TRANSACCION(2); //CON ESTO CONTROLAMOS LA ACTIVIDAD O INACTIVIDAD DE LOS CONTROLES
            dgvMOV_CAJAKARDEX.CurrentCell.Selected = false; //ESTO NO SELECCIONA NINGUN REGISTRO
            LLENAR_COMBO_TIPOMOV();
            LLENAR_COMBO_TIPOPAGO();
            ESTADO_TEXBOX_VENTA(1);
        }

        private void btnGRABAR_Click(object sender, EventArgs e)
        {
            if (VALIDAR_DATOS_CAJA_KARDEX())
            {
                GRABAR_CAJA_KARDEX();
                ESTADO_TRANSACCION(1);//CON ESTO CONTROLAMOS LA ACTIVIDAD O INACTIVIDAD DE LOS CONTROLES
                FILTRAR_CAJA_KARDEX(0, "1", ""); //AQUI ACTUALIZO Y AGO QUE EL FILTRO SEA POR TODOS LO ACTIVOS 
                rdbACTIVOS.Checked = false;
                rdbANULADOS.Checked = false;
                rdbANULADOS.Checked = false;
                txtDATA_BUSQUEDA.Text = string.Empty; //LIMPIAR EL CAMPO DE BUSQUEDA
                dgvMOV_CAJAKARDEX.Rows[1].Selected = true; //SELECCIONA EL PPRIMER REGISTRO
                SELECCIONAR_REGISTRO_CARGADATA(); //AQUI CARGO POR PRIMERA VEZ TODOS LOS CAMPOS SELECIONADOS DE LA GRILLA

            }
            else
            {
                MessageBox.Show("ERROR, FALTAN DATOS NECESARIOS POR INGRESAR");
            }
            ESTADO_TEXBOX_VENTA(2);
        }

        private void btnIMPRIMIR_Click(object sender, EventArgs e)
        {
            if (dgvMOV_CAJAKARDEX.Rows.Count != 0 && rdbACTIVOS.Checked == false && rdbTODOS.Checked == false && rdbANULADOS.Checked == false ) //AQUI VALIDO QUE EXISTAN DATOS EN MI GRIDVIEW PARA PODER IMPRIIMIR MIS DATOS
            {

                if (rdbTICKET.Checked == true) //AQUI GENERO EL ARCHIVO PDF PARA SU IMPRESION
                {
                    string IDMOV = txtID_MOVIMIENTO.Text;
                    string IDEMP = Properties.Settings.Default.id_empresa;
                    String url = String.Format("REPORTES/FRM_REPORTE_RECIBO_EGRESO_INGRESO.aspx?IDMOV={0}&IDEMP={1}", IDMOV, IDEMP);
                    //Response.Redirect(url);
                    /*-------------------------------------JAVASCRIPT--------------------------------------------------------*/
                    //string s = "window.open('" + url + "', 'popup_window', 'width=700,height=400,left=10%,top=10%,resizable=yes');";
                    //ClientScript.RegisterStartupScript(this.GetType(), "script", s, true);
                    /*------------------------------------------------------------------------------------------------------*/
                }
                else //SINO GENERO LA IMPRESION DE LOS TICKET BOLETA
                {
                  /* AGREGAR AL FINAL */  IMPRIMIR_SPOOL(); //imprimo mi spool en mi impresora etiquetera
                }
            }
        }

        private void btnBUSCAR_Click(object sender, EventArgs e)
        {
            if (rdbACTIVOS.Checked == true)//ACTIVOS
            {
                FILTRAR_CAJA_KARDEX(cboTIPO_BUSQUEDA.SelectedIndex, "1", txtDATA_BUSQUEDA.Text.ToString());
                dgvMOV_CAJAKARDEX.CurrentCell.Selected = false; //DESELECCIONO LA FILA SELECIONADA DEL GRIDVIEW
            }
            if (rdbANULADOS.Checked == true)//ANULADOS
            {
                FILTRAR_CAJA_KARDEX(cboTIPO_BUSQUEDA.SelectedIndex, "2", txtDATA_BUSQUEDA.Text.ToString());
            }
            if (rdbTODOS.Checked == true)//TODOS
            {
                FILTRAR_CAJA_KARDEX(cboTIPO_BUSQUEDA.SelectedIndex, "3", txtDATA_BUSQUEDA.Text.ToString());
            }
        }

        private void rdbACTIVOS_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbACTIVOS.Checked == true)
            {
                FILTRAR_CAJA_KARDEX(0, "1", "");
                SELECCIONAR_REGISTRO_CARGADATA();
                btnANULAR.Enabled = true;
            }
        }

        private void rdbANULADOS_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbANULADOS.Checked == true)
            {
                FILTRAR_CAJA_KARDEX(0, "2", "");
                SELECCIONAR_REGISTRO_CARGADATA();
                btnANULAR.Enabled = false;
            }
        }

        private void rdbTODOS_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbTODOS.Checked == true)
            {
                FILTRAR_CAJA_KARDEX(0, "3", "");
                SELECCIONAR_REGISTRO_CARGADATA();
                btnANULAR.Enabled = true;
            }
        }

        private void SELECCIONAR_REGISTRO_CARGADATA()
                {
            try
            {
                //========================================================================
                if (dgvMOV_CAJAKARDEX.Rows.Count != 0)
                {
                    //PLANTILLA: dgvMOV_CAJAKARDEX.CurrentRow.Cells[1].ToString();

                    //txtID_MOVIMIENTO.Text = dgvMOV_CAJAKARDEX.SelectedRow.Cells[1].Text;
                    txtID_MOVIMIENTO.Text = dgvMOV_CAJAKARDEX.CurrentRow.Cells[0].Value.ToString();
                    txtFECHA.Text = dgvMOV_CAJAKARDEX.CurrentRow.Cells[19].Value.ToString();
                    //txtFECHA.Text = Convert.ToDateTime(dgvMOV_CAJAKARDEX.CurrentRow.Cells[19].Value).ToString("dd/MM/yyyy");
                    
                    if (dgvMOV_CAJAKARDEX.CurrentRow.Cells[18].Value.ToString() != "&nbsp;")
                    {
                        txtFECHA_ANULADO.Text = dgvMOV_CAJAKARDEX.CurrentRow.Cells[18].Value.ToString();
                    }
                    else
                    {
                        txtFECHA_ANULADO.Text = string.Empty;
                    }
                    cboTIPO_PAGO.SelectedItem = dgvMOV_CAJAKARDEX.CurrentRow.Cells[3].Value.ToString();
                    cboTIPO_MOV.Text = dgvMOV_CAJAKARDEX.CurrentRow.Cells[4].Value.ToString();
                    if (dgvMOV_CAJAKARDEX.CurrentRow.Cells[6].Value.ToString() == "S")
                    {
                        rdbSOLES.Checked = true;
                    }
                    /*if (dgvMOV_CAJAKARDEX.Rows[Int32.Parse(dgvMOV_CAJAKARDEX.SelectedRows.ToString())].Cells[6].Value.ToString() == "D")
                    {
                        rdbDOLARES.Checked = true;
                    }*/

                    txtMONTO.Text = dgvMOV_CAJAKARDEX.CurrentRow.Cells[8].Value.ToString();
                    txtDESCRIPCION.Text = dgvMOV_CAJAKARDEX.CurrentRow.Cells[1].Value.ToString();
                }
                else
                {
                    txtID_MOVIMIENTO.Text = string.Empty;
                    txtFECHA.Text = string.Empty;
                    txtFECHA_ANULADO.Text = string.Empty;
                    cboTIPO_MOV.SelectedIndex = 0;
                    cboTIPO_PAGO.SelectedIndex = 0;
                    txtMONTO.Text = string.Empty;
                    rdbSOLES.Checked = true;
                    txtDESCRIPCION.Text = string.Empty;
                }
                //========================================================================
            }
            catch (Exception)
            {

                MessageBox.Show("ERROR VERIFIQUE SUS DATOS");
            }

        }

        private void dgvMOV_CAJAKARDEX_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           // SELECCIONAR_REGISTRO_CARGADATA();
        }

        private void btnANULAR_Click(object sender, EventArgs e)
        {
            if (txtCODANULACION.Text.ToString() == "CTDIONYS2016")
            {
                ANULAR_CAJA_KARDEX_REGISTRO();
                FILTRAR_CAJA_KARDEX(0, "2", ""); //FILTRO TODOS Y POR ANULADOS
                rdbANULADOS.Checked = true;
                dgvMOV_CAJAKARDEX.SelectedRows.Equals(0); //SELECCIONA EL PPRIMER REGISTRO  /*REVISAR QUE CUMPLA LA ACCION*/<<<------------
                SELECCIONAR_REGISTRO_CARGADATA(); //AQUI CARGO POR PRIMERA VEZ TODOS LOS CAMPOS SELECIONADOS DE LA GRILLA


                //CON ESTO ANULO LA VENTA DEL CONTROL DE GALERIA PARA MANTENER EL ORDEN - ANULAR EL PAGO Y DEJARLO EN PENDIENTE
                //if (Session["SEDE"].ToString() == "004")
                //{
                //    N_OBJVENTAS.ACTUALIZAR_MODIFICACIONES_CONTROL_GALERIA(txtID_DOC.Text, "2");
                //}
                
            }
            else
            {
                MessageBox.Show("ERROR INGRESAR CLAVE DE AUTORIZACION");
            }
            txtCODANULACION.Text = string.Empty;
        }


        // IMPRESIONES SPOOL >>> REVISAR QUE FUNCIONE CORRECTAMENTE<<<<
        // =============================================================================================================================================== 
        public void IMPRIMIR_SPOOL()
        {
            DataTable DATOS_EMPRESA = new DataTable();
            DATOS_EMPRESA = N_OBJEMPRESA.CONSULTAR_VISTA_EMPRESA(Properties.Settings.Default.id_empresa); //AQUI CARGO LOS DATOS DE MI VISTA V_EMPRESA

            DataTable DATOS_SEDE = new DataTable();
            DATOS_SEDE = N_OBJEMPRESA.CONSULTAR_VISTA_SEDE(Program.id_sede); //AQUI CARGO LOS DATOS DE MI VISTA V_SEDE 

            DataTable DATOS_CAJA_KARDEX = new DataTable();                         //ESTO ME PERMITE CREAR EL DATATABLE PARA LLAMAR A LOS DATOS DE MI CAJA KARDEX
            string ID_MOVIMIENTO = txtID_MOVIMIENTO.Text;                          //ESTO PERMITE GENERAR LA VARIABLE DEL ID_MOVIMIENTO

            DATOS_CAJA_KARDEX = N_OBJVENTAS.LISTA_REGISTRO_CAJA_KARDEX(ID_MOVIMIENTO);        //ESTO ME PERMITE ALMACENAR TODOS LOS DATOS EN UN DATATABLE DE MI 
                                                                                              //CAJA_KARDEX PARA PODER ACCEDER A ELLO EN TODO MOMENTO

            //LIMPIANDO MI SPOOL SI ESQUE UBIERA IMPRESIONES PENDIENTES
            N_OBJVENTAS.SPOOL_ETIQUETERA(Properties.Settings.Default.punto_venta, string.Empty, "2");
            // ========================================================================================


            //AQUI ESTOY OBTENIENDO TODOS LOS DATOS DE LA EMPRESA
            N_OBJVENTAS.SPOOL_ETIQUETERA(Properties.Settings.Default.punto_venta, DATOS_EMPRESA.Rows[0]["DESCRIPCION"].ToString(), "1");      //aqui va el nombre de la empresa
            N_OBJVENTAS.SPOOL_ETIQUETERA(Properties.Settings.Default.punto_venta, "RUC: " + DATOS_EMPRESA.Rows[0]["RUC"].ToString(), "1");    //aqui va el ruc de la empresa
            N_OBJVENTAS.SPOOL_ETIQUETERA(Properties.Settings.Default.punto_venta, "DIRECCION: " + DATOS_EMPRESA.Rows[0]["DIRECCION"].ToString(), "1");
            N_OBJVENTAS.SPOOL_ETIQUETERA(Properties.Settings.Default.punto_venta, DATOS_EMPRESA.Rows[0]["UBIDSN"].ToString() + "-" + DATOS_EMPRESA.Rows[0]["UBIPRN"].ToString() + "-" + DATOS_EMPRESA.Rows[0]["UBIDEN"].ToString(), "1"); //DISTRITO PROVINCIA Y DEPARTAMENTO
            //AQUI ESTOY OBTENIENDO TODOS LOS DATOS DE LA SEDE
            N_OBJVENTAS.SPOOL_ETIQUETERA(Properties.Settings.Default.punto_venta, "-", "1");                                        //imprime una linea de guiones
            N_OBJVENTAS.SPOOL_ETIQUETERA(Properties.Settings.Default.punto_venta, "SEDE: " + DATOS_SEDE.Rows[0]["ID_SEDE"].ToString() + " " + DATOS_SEDE.Rows[0]["DESCRIPCION"].ToString(), "1"); //aqui va el codigo y el nombre de la sede de la empresa 
            //AQUI ESTOY OBTENIENDO TODOS LOS DATOS DEL PUNTO DE VENTA
            N_OBJVENTAS.SPOOL_ETIQUETERA(Properties.Settings.Default.punto_venta, "PV: " + Properties.Settings.Default.punto_venta + " " + Properties.Settings.Default.punto_venta, "1");                 //aqui va el codigo y el nombre del punto de venta
            N_OBJVENTAS.SPOOL_ETIQUETERA(Properties.Settings.Default.punto_venta, "-", "1");
            //N_OBJVENTAS.SPOOL_ETIQUETERA(Session["ID_PUNTOVENTA"].ToString(), "MAQ REG : " + DATOS_VENTA.Rows[0][48].ToString(), "1");          //AQUI SE COLOCA EL NOMBRE DE LA MAQUINA REGISTRADORA
            N_OBJVENTAS.SPOOL_ETIQUETERA(Properties.Settings.Default.punto_venta, DATOS_CAJA_KARDEX.Rows[0]["FECHA"].ToString(), "1");   //aqui va la fecha

            // AQUI VA EL NOMBRE  DEL MOVIMIENTO DE LA VENTA O COMPRA
            string TIP_MOV;
            TIP_MOV = DATOS_CAJA_KARDEX.Rows[0]["TM_DESCRIPCION"].ToString();
            //AQUI ESTOY OBTENIENDO EL MOTIVO DE MOVIMIENTO
            N_OBJVENTAS.SPOOL_ETIQUETERA(Properties.Settings.Default.punto_venta, "RECIBO: " + TIP_MOV, "1");
            //AQUI ESTOY OBTENIENDO EL ID_MOVIMIENTO Y EL IMPORTE TOTAL DEL MOVIMIENTO
            N_OBJVENTAS.SPOOL_ETIQUETERA(Properties.Settings.Default.punto_venta, "#MOV : " + DATOS_CAJA_KARDEX.Rows[0]["ID_MOVIMIENTO"].ToString(), "1");


            if (DATOS_CAJA_KARDEX.Rows[0]["MONEDA"].ToString() == "S")
            {
                N_OBJVENTAS.SPOOL_ETIQUETERA(Properties.Settings.Default.punto_venta, "IMPORTE : " + " S/. " + Convert.ToDouble(DATOS_CAJA_KARDEX.Rows[0]["IMPORTE"]).ToString("N2"), "1");
            }
            else
            {
                N_OBJVENTAS.SPOOL_ETIQUETERA(Properties.Settings.Default.punto_venta, "IMPORTE : " + " US$. " + Convert.ToDouble(DATOS_CAJA_KARDEX.Rows[0]["IMPORTE"]).ToString("N2"), "1");
            }


            //AQUI ESTOY OBTENIENDO GUIONES PARA GENERAR UNA LINEA
            N_OBJVENTAS.SPOOL_ETIQUETERA(Properties.Settings.Default.punto_venta, "-", "1");

            //AQUI ESTOY OBTENIENDO LA DESCRIPCION DEL MOVIMIENTO DE LA CAJA_KARDEX
            N_OBJVENTAS.SPOOL_ETIQUETERA(Properties.Settings.Default.punto_venta, DATOS_CAJA_KARDEX.Rows[0]["DESCRIPCION"].ToString(), "1");

            //AQUI ESTOY OBTENIENDO GUIONES PARA GENERAR UNA LINEA
            N_OBJVENTAS.SPOOL_ETIQUETERA(Properties.Settings.Default.punto_venta, "-", "1");

            N_OBJVENTAS.SPOOL_ETIQUETERA(Properties.Settings.Default.punto_venta, "USUARIO: " + DATOS_CAJA_KARDEX.Rows[0]["EMPLEADO"].ToString(), "1"); //obtenemos la descripcion del cajero o empleado

            //AQUI ESTOY OBTENIENDO GUIONES PARA GENERAR UNA LINEA
            N_OBJVENTAS.SPOOL_ETIQUETERA(Properties.Settings.Default.punto_venta, "-", "1");

            N_OBJVENTAS.SPOOL_ETIQUETERA(Properties.Settings.Default.punto_venta, "RECEPTOR: ", "1");

            //AQUI ESTOY OBTENIENDO GUIONES PARA GENERAR UNA LINEA
            N_OBJVENTAS.SPOOL_ETIQUETERA(Properties.Settings.Default.punto_venta, "NOMBRE: ____________________________", "1");

            //AQUI ESTOY OBTENIENDO GUIONES PARA GENERAR UNA LINEA
            N_OBJVENTAS.SPOOL_ETIQUETERA(Properties.Settings.Default.punto_venta, "DNI: ___________________________", "1");


            N_OBJVENTAS.SPOOL_ETIQUETERA(Properties.Settings.Default.punto_venta, "CORTATICKET", "1");
            
        }

        private void btnIMPRIMIR_REPORTCAJA_Click(object sender, EventArgs e)
        {
            if (rdbTICKET.Checked == true)
            {
                IMPRIMIR_SPOOL_TODOS_MOVCAJA(); //AQUI IMPRIMIMOS TODO LOS MOVIMIENTOS EN UN SOLO REPORTE O IMPRESION EN LA IMPRESORA ETICKETERA
            }
            else
            {
                string ID_EMPRESA = Properties.Settings.Default.id_empresa;
                  
            }
        }

      

        void IMPRIMIR_SPOOL_TODOS_MOVCAJA()
        {
            DataTable DATOS_EMPRESA = new DataTable();
            DATOS_EMPRESA =  N_OBJEMPRESA.CONSULTAR_VISTA_EMPRESA(Properties.Settings.Default.id_empresa); //AQUI CARGO LOS DATOS DE MI VISTA V_EMPRESA

            DataTable DATOS_SEDE = new DataTable();
            DATOS_SEDE = N_OBJEMPRESA.CONSULTAR_VISTA_SEDE(Program.id_sede); //AQUI CARGO LOS DATOS DE MI VISTA V_SEDE 

            DataTable DATOS_CAJA_KARDEX = new DataTable();                         //ESTO ME PERMITE CREAR EL DATATABLE PARA LLAMAR A LOS DATOS DE MI CAJA KARDEX
            string ID_CAJA = Properties.Settings.Default.id_caja;                          //ESTO PERMITE GENERAR LA VARIABLE DEL ID_MOVIMIENTO

            DATOS_CAJA_KARDEX = N_OBJVENTAS.CONSULTA_IMPRESION_CAJA_KARDEX(ID_CAJA);        //ESTO ME PERMITE ALMACENAR TODOS LOS DATOS EN UN DATATABLE DE MI 
                                                                                            //CAJA_KARDEX PARA PODER ACCEDER A ELLO EN TODO MOMENTO

            //LIMPIANDO MI SPOOL SI ESQUE UBIERA IMPRESIONES PENDIENTES
            N_OBJVENTAS.SPOOL_ETIQUETERA(Properties.Settings.Default.punto_venta, string.Empty, "2");
            // ========================================================================================


            N_OBJVENTAS.SPOOL_ETIQUETERA(Properties.Settings.Default.punto_venta, "---- REPORTE DE CAJA ----", "1");

            //AQUI ESTOY OBTENIENDO TODOS LOS DATOS DE LA EMPRESA
            N_OBJVENTAS.SPOOL_ETIQUETERA(Properties.Settings.Default.punto_venta, DATOS_EMPRESA.Rows[0]["DESCRIPCION"].ToString(), "1");      //aqui va el nombre de la empresa
            N_OBJVENTAS.SPOOL_ETIQUETERA(Properties.Settings.Default.punto_venta, "RUC: " + DATOS_EMPRESA.Rows[0]["RUC"].ToString(), "1");    //aqui va el ruc de la empresa
            N_OBJVENTAS.SPOOL_ETIQUETERA(Properties.Settings.Default.punto_venta, "DIRECCION: " + DATOS_EMPRESA.Rows[0]["DIRECCION"].ToString(), "1");
            N_OBJVENTAS.SPOOL_ETIQUETERA(Properties.Settings.Default.punto_venta, DATOS_EMPRESA.Rows[0]["UBIDSN"].ToString() + "-" + DATOS_EMPRESA.Rows[0]["UBIPRN"].ToString() + "-" + DATOS_EMPRESA.Rows[0]["UBIDEN"].ToString(), "1"); //DISTRITO PROVINCIA Y DEPARTAMENTO
            //AQUI ESTOY OBTENIENDO TODOS LOS DATOS DE LA SEDE
            N_OBJVENTAS.SPOOL_ETIQUETERA(Properties.Settings.Default.punto_venta, "-", "1");                                        //imprime una linea de guiones
            N_OBJVENTAS.SPOOL_ETIQUETERA(Properties.Settings.Default.punto_venta, "SEDE: " + DATOS_SEDE.Rows[0]["ID_SEDE"].ToString() + " " + DATOS_SEDE.Rows[0]["DESCRIPCION"].ToString(), "1"); //aqui va el codigo y el nombre de la sede de la empresa 
            //AQUI ESTOY OBTENIENDO TODOS LOS DATOS DEL PUNTO DE VENTA
            N_OBJVENTAS.SPOOL_ETIQUETERA(Properties.Settings.Default.punto_venta, "PV: " + Properties.Settings.Default.punto_venta + " " + Properties.Settings.Default.punto_venta, "1");                 //aqui va el codigo y el nombre del punto de venta
            N_OBJVENTAS.SPOOL_ETIQUETERA(Properties.Settings.Default.punto_venta, "FECHA APERTURA: " + Convert.ToDateTime(DATOS_CAJA_KARDEX.Rows[0]["FECHA_INICIAL"]).ToString("dd/MM/yy"), "1");          //FECHA_INICIAL
            N_OBJVENTAS.SPOOL_ETIQUETERA(Properties.Settings.Default.punto_venta, "-", "1");

            string ANULADO = string.Empty;
            double TOTALANU = 0.00;
            int CONTANU = 0, CONTTOTAL = 0, IPV_CANT = 0, EVA_CANT = 0;
            int IVA_CANT = 0, EGE_CANT = 0;
            double TOTALMOV = 0.00;
            double IPV_EFECTIVO = 0.00, EVA_EFECTIVO = 0.00, IPV_EFECTIVO_OTROS = 0.00;
            double IVA_EFECTIVO = 0.00, EGE_EFECTIVO = 0.00;

            //GENERAR LOS REGISTROS DE INGRESOS POR VENTA
            N_OBJVENTAS.SPOOL_ETIQUETERA(Properties.Settings.Default.punto_venta, "---DETALLE INGRESOS POR VENTA---", "1");
            N_OBJVENTAS.SPOOL_ETIQUETERA(Properties.Settings.Default.punto_venta, string.Empty, "1");
            N_OBJVENTAS.SPOOL_ETIQUETERA(Properties.Settings.Default.punto_venta, "FECHA   TIPMOV   # DOC    M   IMPORTE A", "1");
            for (int i = 0; i < DATOS_CAJA_KARDEX.Rows.Count; i++)
            {
                ANULADO = " ";
                string varMOVIMIENTO = DATOS_CAJA_KARDEX.Rows[i]["ID_TIPOMOV"].ToString();
                if (DATOS_CAJA_KARDEX.Rows[i]["FECHA_ANULADO"] != DBNull.Value && varMOVIMIENTO.ToString() == "IPV")
                {
                    ANULADO = "*";
                    CONTANU = CONTANU + 1;
                    TOTALANU = TOTALANU + Convert.ToDouble(DATOS_CAJA_KARDEX.Rows[i]["IMPORTE"]); //TOTALIZANDO LOS ANULADOS
                }

                //==============================================================================================================
                //OBTENGO EL VALOR DE MI CAMPO ID_TIPOMOV PARA VERIFICAR SI TIENE DATO O NO , PARA REALIZAR LA COMPARACIONES
                string varID_TIPOPAGO = DATOS_CAJA_KARDEX.Rows[i]["ID_TIPOPAGO"].ToString();
                if (varMOVIMIENTO == "IPV")
                {
                    N_OBJVENTAS.SPOOL_ETIQUETERA(Properties.Settings.Default.punto_venta, Convert.ToDateTime(DATOS_CAJA_KARDEX.Rows[i]["FECHA"]).ToString("dd/MM/yy") + " " + DATOS_CAJA_KARDEX.Rows[i]["ID_TIPOMOV"].ToString() + " " +
                    DATOS_CAJA_KARDEX.Rows[i]["NUMERO"].ToString() + "  " + DATOS_CAJA_KARDEX.Rows[i]["MONEDA"].ToString() + " " + DATOS_CAJA_KARDEX.Rows[i]["IMPORTE"].ToString() + " " + ANULADO, "1");
                }

                //AQUI PROCESO LA INFORMACION PARA OBTENER LAS SUMAS DE LOS INGRESOS POR VENTA EN EFECTIVO Y QUE NO ESTEN ANULADOS
                if (varMOVIMIENTO == "IPV" && varID_TIPOPAGO == "0001" && DATOS_CAJA_KARDEX.Rows[i]["FECHA_ANULADO"] == DBNull.Value)
                {
                    IPV_EFECTIVO += Convert.ToDouble(DATOS_CAJA_KARDEX.Rows[i]["IMPORTE"]);
                    IPV_CANT += 1;
                }

                //AQUI PROCESO LA INFORMACION PARA OBTENER LAS SUMAS DE LOS INGRESOS POR VENTA CON TARJETA CREDITO O DEBITO Y QUE NO ESTEN ANULADOS
                if (varMOVIMIENTO == "IPV" && (varID_TIPOPAGO == "0002" || varID_TIPOPAGO == "0003") && DATOS_CAJA_KARDEX.Rows[i]["FECHA_ANULADO"] == DBNull.Value)
                {
                    IPV_EFECTIVO_OTROS += Convert.ToDouble(DATOS_CAJA_KARDEX.Rows[i]["IMPORTE"]);
                }

                //AQUI OBTENGO EL TOTAL DE ACTIVOS
                if (DATOS_CAJA_KARDEX.Rows[i]["FECHA_ANULADO"] == DBNull.Value && varMOVIMIENTO == "IPV")
                {
                    CONTTOTAL += 1;
                }

            }
            N_OBJVENTAS.SPOOL_ETIQUETERA(Properties.Settings.Default.punto_venta, "-", "1");
            N_OBJVENTAS.SPOOL_ETIQUETERA(Properties.Settings.Default.punto_venta, "TOTAL ANULADOS : " + CONTANU + " DOC  S/. " + TOTALANU.ToString("N2"), "1");//IMPRIMIENDO TOTAL DE ANULADOS
            N_OBJVENTAS.SPOOL_ETIQUETERA(Properties.Settings.Default.punto_venta, "TOTAL VENTAS   : " + CONTTOTAL + " DOC  S/. " + (IPV_EFECTIVO + IPV_EFECTIVO_OTROS).ToString("N2"), "1");//IMPRIMIENDO TOTAL DE ANULADOS

            N_OBJVENTAS.SPOOL_ETIQUETERA(Properties.Settings.Default.punto_venta, string.Empty, "1");                          // imprime una espacio
            N_OBJVENTAS.SPOOL_ETIQUETERA(Properties.Settings.Default.punto_venta, "T.V. EFECTIVO (S/.): " + IPV_EFECTIVO.ToString("N2"), "1");//IMPRIMIENDO TOTAL DE EFECTIVO
            N_OBJVENTAS.SPOOL_ETIQUETERA(Properties.Settings.Default.punto_venta, "T.V. OTROS (S/.): " + IPV_EFECTIVO_OTROS.ToString("N2"), "1");//IMPRIMIENDO TOTAL DE EFECTIVO

            //GENERAR LOS REGISTROS DE INGRESOS VARIOS
            N_OBJVENTAS.SPOOL_ETIQUETERA(Properties.Settings.Default.punto_venta, string.Empty, "1");                          // imprime una espacio
            N_OBJVENTAS.SPOOL_ETIQUETERA(Properties.Settings.Default.punto_venta, "-----DETALLE INGRESOS OTROS-----", "1");

            for (int i = 0; i < DATOS_CAJA_KARDEX.Rows.Count; i++)
            {
                ANULADO = " ";
                if (DATOS_CAJA_KARDEX.Rows[i]["FECHA_ANULADO"] != DBNull.Value)
                {
                    ANULADO = "*";
                }

                string varID_TIPOMOV = DATOS_CAJA_KARDEX.Rows[i]["ID_TIPOMOV"].ToString(); //OBTENGO EL VALOR DE MI CAMPO ID_COMVENTA PARA VERIFICAR SI TIENE DATO O NO , PARA REALIZAR LA COMPARACIONES
                if (varID_TIPOMOV == "IVA")
                {
                    N_OBJVENTAS.SPOOL_ETIQUETERA(Properties.Settings.Default.punto_venta, Convert.ToDateTime(DATOS_CAJA_KARDEX.Rows[i]["FECHA"]).ToString("dd/MM/yy") + " " + DATOS_CAJA_KARDEX.Rows[i]["ID_TIPOMOV"].ToString() + " " +
                    DATOS_CAJA_KARDEX.Rows[i]["ID_MOVIMIENTO"].ToString() + "  " + DATOS_CAJA_KARDEX.Rows[i]["MONEDA"].ToString() + "  " + DATOS_CAJA_KARDEX.Rows[i]["IMPORTE"].ToString() + " " + ANULADO, "1");
                }

                //AQUI CALCULO EL TOTAL DE LOS EGRESOS GERENCIA
                if (varID_TIPOMOV == "IVA" && DATOS_CAJA_KARDEX.Rows[i]["FECHA_ANULADO"] == DBNull.Value)
                {
                    IVA_EFECTIVO += Convert.ToDouble(DATOS_CAJA_KARDEX.Rows[i]["IMPORTE"]);
                    IVA_CANT += 1;
                }

            }

            N_OBJVENTAS.SPOOL_ETIQUETERA(Properties.Settings.Default.punto_venta, string.Empty, "1");                          // imprime una espacio
            N_OBJVENTAS.SPOOL_ETIQUETERA(Properties.Settings.Default.punto_venta, "TOTAL IVA : " + IVA_EFECTIVO.ToString("N2"), "1");//IMPRIMIENDO TOTAL DE EFECTIVO

            //GENERAR LOS REGISTROS DE EGRESOS
            N_OBJVENTAS.SPOOL_ETIQUETERA(Properties.Settings.Default.punto_venta, string.Empty, "1");                          // imprime una espacio
            N_OBJVENTAS.SPOOL_ETIQUETERA(Properties.Settings.Default.punto_venta, "-------DETALLE DE EGRESOS-------", "1");

            for (int i = 0; i < DATOS_CAJA_KARDEX.Rows.Count; i++)
            {
                ANULADO = " ";
                if (DATOS_CAJA_KARDEX.Rows[i]["FECHA_ANULADO"] != DBNull.Value)
                {
                    ANULADO = "*";
                }

                string varID_TIPOMOV = DATOS_CAJA_KARDEX.Rows[i]["ID_TIPOMOV"].ToString(); //OBTENGO EL VALOR DE MI CAMPO ID_COMVENTA PARA VERIFICAR SI TIENE DATO O NO , PARA REALIZAR LA COMPARACIONES

                if (varID_TIPOMOV == "EGE" || varID_TIPOMOV == "EVA")
                {
                    N_OBJVENTAS.SPOOL_ETIQUETERA(Properties.Settings.Default.punto_venta, Convert.ToDateTime(DATOS_CAJA_KARDEX.Rows[i]["FECHA"]).ToString("dd/MM/yy") + " " + DATOS_CAJA_KARDEX.Rows[i]["ID_TIPOMOV"].ToString() + " " +
                    DATOS_CAJA_KARDEX.Rows[i]["ID_MOVIMIENTO"].ToString() + "  " + DATOS_CAJA_KARDEX.Rows[i]["MONEDA"].ToString() + "  " + DATOS_CAJA_KARDEX.Rows[i]["IMPORTE"].ToString() + " " + ANULADO, "1");
                }

                //AQUI CALCULO EL TOTAL DE LOS EGRESOS GERENCIA
                if (varID_TIPOMOV == "EGE" && DATOS_CAJA_KARDEX.Rows[i]["FECHA_ANULADO"] == DBNull.Value)
                {
                    EGE_EFECTIVO += Convert.ToDouble(DATOS_CAJA_KARDEX.Rows[i]["IMPORTE"]);
                    EGE_CANT += 1;
                }

                //AQUI CALCULO EL TOTAL DE LOS EGRESOS VARIOS
                if (varID_TIPOMOV == "EVA" && DATOS_CAJA_KARDEX.Rows[i]["FECHA_ANULADO"] == DBNull.Value)
                {
                    EVA_EFECTIVO += Convert.ToDouble(DATOS_CAJA_KARDEX.Rows[i]["IMPORTE"]);
                    EVA_CANT += 1;
                }

            }
            N_OBJVENTAS.SPOOL_ETIQUETERA(Properties.Settings.Default.punto_venta, string.Empty, "1");                          // imprime una espacio
            N_OBJVENTAS.SPOOL_ETIQUETERA(Properties.Settings.Default.punto_venta, "TOTAL EGE: " + EGE_EFECTIVO.ToString("N2"), "1");//IMPRIMIENDO TOTAL DE EFECTIVO
            N_OBJVENTAS.SPOOL_ETIQUETERA(Properties.Settings.Default.punto_venta, "TOTAL EVA: " + EVA_EFECTIVO.ToString("N2"), "1");//IMPRIMIENDO TOTAL DE EFECTIVO
            N_OBJVENTAS.SPOOL_ETIQUETERA(Properties.Settings.Default.punto_venta, string.Empty, "1");
            N_OBJVENTAS.SPOOL_ETIQUETERA(Properties.Settings.Default.punto_venta, "-", "1");                          // imprime una linea de guiones
            N_OBJVENTAS.SPOOL_ETIQUETERA(Properties.Settings.Default.punto_venta, "SALDO EFECTIVO CAJA: " + ((IPV_EFECTIVO + IVA_EFECTIVO) - (EGE_EFECTIVO + EVA_EFECTIVO)).ToString("N2"), "1");//IMPRIMIENDO TOTAL DE EFECTIVO
                                                                                                                                                                                             //=======================================================================================================================================================

            N_OBJVENTAS.SPOOL_ETIQUETERA(Properties.Settings.Default.punto_venta, string.Empty, "1");
            N_OBJVENTAS.SPOOL_ETIQUETERA(Properties.Settings.Default.punto_venta, string.Empty, "1");
            N_OBJVENTAS.SPOOL_ETIQUETERA(Properties.Settings.Default.punto_venta, "-", "1");                          // imprime una linea de guiones
            N_OBJVENTAS.SPOOL_ETIQUETERA(Properties.Settings.Default.punto_venta, "V.B: " + Properties.Settings.Default.nomempleado, "1"); // obtenemos el NOMBRE DEL EMPLEADO
            N_OBJVENTAS.SPOOL_ETIQUETERA(Properties.Settings.Default.punto_venta, "  " + Properties.Settings.Default.id_empleado, "1"); // obtenemos el USUARIO/DNI DEL EMPLEADO
            N_OBJVENTAS.SPOOL_ETIQUETERA(Properties.Settings.Default.punto_venta, string.Empty, "1");
            N_OBJVENTAS.SPOOL_ETIQUETERA(Properties.Settings.Default.punto_venta, string.Empty, "1");
            N_OBJVENTAS.SPOOL_ETIQUETERA(Properties.Settings.Default.punto_venta, string.Empty, "1");
            N_OBJVENTAS.SPOOL_ETIQUETERA(Properties.Settings.Default.punto_venta, "-", "1");                          // imprime una linea de guiones
            N_OBJVENTAS.SPOOL_ETIQUETERA(Properties.Settings.Default.punto_venta, "V.B: ADMINISTRACION", "1");

            N_OBJVENTAS.SPOOL_ETIQUETERA(Properties.Settings.Default.punto_venta, "FECHA IMPRESION : " + DateTime.Now.ToString("g"), "1"); //formato de fecha g = 6/15/2008 9:15 PM
            N_OBJVENTAS.SPOOL_ETIQUETERA(Properties.Settings.Default.punto_venta, "CORTATICKET", "1");                          // imprime una linea de guiones

        }

        private void button2_Click(object sender, EventArgs e)
        {
            CONSULTAR_VENTAS(txtID_DOC.Text);
        }

        private void cboTIPO_MOV_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTIPO_MOV.SelectedValue.ToString() == "EPC")
            {
                ESTADO_TEXBOX_VENTA(1);
            }
            if (cboTIPO_MOV.SelectedValue.ToString() == "EVA")
            {
                ESTADO_TEXBOX_VENTA(2);
            }
            if (cboTIPO_MOV.SelectedValue.ToString() == "IPV")
            {
                ESTADO_TEXBOX_VENTA(1);
            }
            if (cboTIPO_MOV.SelectedValue.ToString() == "IVA")
            {
                ESTADO_TEXBOX_VENTA(2);
            }
            if (cboTIPO_MOV.SelectedValue.ToString() == "EGE")
            {
                ESTADO_TEXBOX_VENTA(2);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {

            /*--------------------------VARIABLES DE RETORNO A CAJA--------------------------*/
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
            /*---------------------------------------------------------------------------------*/
        }

        private void dgvMOV_CAJAKARDEX_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SELECCIONAR_REGISTRO_CARGADATA();
        }
    }
}
