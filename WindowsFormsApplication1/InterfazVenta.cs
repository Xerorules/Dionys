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
using System.Runtime.InteropServices;
using System.Collections;
using System.Data.SqlClient;
using System.Configuration;

namespace WindowsFormsApplication1
{
    public partial class InterfazVenta : Form
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["sql"].ConnectionString);
        #region variables globales 
        public string v_id_caja;
        public string v_serie;
        public string v_id_puntoventa;
        public string v_id_empleado;
        public string v_id_empresa;
        public string v_nombre_empleado;
        public string v_tipo_cambio;
        public string v_sede;
        public string v_fchapertura;
        public string v_fchacierre;
        public string v_saldo_ini;
        public string v_saldo_fin;
        /*----                       ----*/
        public string v_tipo_doc;
        public string v_ind_tipo_doc;
        public string v_id_bien;
        public string v_desc_bien;
        public string v_precio_bien;
        public string v_llamabien;
        /*-------------------------------*/
        #endregion

        #region variables de retorno buscar cliente
        public string bc_id_cliente;
        public string bc_ruc_dni;
        public string bc_descripcion;
        
        #endregion

        public string[] valor = new string[20];
        public string[] idbien = new string[20];
        public string[] PRECIO_BIEN = new string[20];
        public String MON = "";
        public String WEB = "";
        public double VUELTO = 0.00, PAGA = 0.00;
        
        //public DataTable detallebien = new DataTable();
        public DataTable vPdt_detBien = new DataTable();

        public InterfazVenta()
        {
            InitializeComponent();
            
        }

        private void InterfazVenta_Load(object sender, EventArgs e)
        {
            lblEmpresa.Text = Properties.Settings.Default.nomempresa;
            lblUsuario.Text = Properties.Settings.Default.nomempleado;
            lblSede.Text = Properties.Settings.Default.nomsede;
            lblFecha.Text = DateTime.Today.ToShortDateString();
            txtCLIENTE_ID.Enabled = false;
            TIPO_PAGO();
            LLENAR_CLASE_BIEN();
            LLENAR_MENU_BIENES();
            ESTRUCTURA_DETALLEBIEN();
            lblCajaIDVentas.Text = Properties.Settings.Default.id_caja;
            dgvBIEN_VENTA.Visible = false;
            LLENAR_GRILLA();
           // DataTable vPdt_detBien = (DataTable)detalle;

            /*----------*/
            //crea boton Eliminar en el gridview
            DataGridViewButtonColumn colBotonEliminar = new DataGridViewButtonColumn();
            colBotonEliminar.Name = "colBotonEliminar";
            colBotonEliminar.HeaderText = "Eliminar";
            colBotonEliminar.Text = "Eliminar";
            colBotonEliminar.UseColumnTextForButtonValue = true;
            this.dgvBIEN_VENTA.Columns.Add(colBotonEliminar);
                        
            /*-------------------------------------------------------------------------------------------*/
            txtCANTIDAD_VENTA.Text = "1";
                txtPRECIO_VENTA.Text = string.Empty;
            
                 if (v_id_bien != string.Empty)  //AQUI EJECUTO EL LLENADO DEL BIEN SI ESQUE UBIERAN DATOS QUE REGISTRAR
                 {

                OBTENER_ID_BIEN_Y_LLENAR_GRILLA(v_id_bien, v_desc_bien, v_precio_bien);

                        v_id_bien = string.Empty;
                        v_desc_bien = string.Empty;
                        v_precio_bien = string.Empty;
                 }
                
                 LLENAR_GRILLA(); //ESTO PERMITE QUE SE MUESTRE LOS DATOS DE LA GRILLA A PESAR QUE SE AGA EL AUTOPOSBAC
                 ACTUALIZAR_TOTALES(); //ESTO DEVUELVE LA ACTUALIZACION DE TOTALES
             }
             


        #region OBJETOS
        N_VENTA N_OBJVENTAS = new N_VENTA();
        E_VENTA E_OBJVENTAS = new E_VENTA();
        E_MANT_CLIENTE E_OBJMANT_CLIENTE = new E_MANT_CLIENTE();
        E_VENTA_Y_DETALLE E_OBJMANT_VENTADET = new E_VENTA_Y_DETALLE();
        E_CAJA_KARDEX E_OBJCAJA_KARDEX = new E_CAJA_KARDEX();


        #endregion

       


        void LLENAR_CLASE_BIEN()
        {
           
            if ((v_id_puntoventa == "PV003") || (v_id_puntoventa == "PV008") || (v_id_puntoventa == "PV009"))
            { //AQUI VAN LOS BIENES PARA RESTAURANT

                List<ListaTipoProd> List = new List<ListaTipoProd>();

                List.Add(new ListaTipoProd { texto = "BEBIDAS", value = "C2" });
                List.Add(new ListaTipoProd { texto = "COMIDA CRIOLLA", value = "C3" });
                List.Add(new ListaTipoProd { texto = "COMIDA TIPICA", value = "C4" });
                List.Add(new ListaTipoProd { texto = "COMIDA MARINA", value = "C5" });
                List.Add(new ListaTipoProd { texto = "POLLOS Y PARRILLAS", value = "C6" });

                cboCLASE_BIEN.DataSource = List;
                cboCLASE_BIEN.DisplayMember = "texto";
                cboCLASE_BIEN.ValueMember = "value";
                cboCLASE_BIEN.SelectedIndex = 0;
                cboTIPO_DOC.SelectedIndex = 0;
                
            }
            else
            {
                List<ListaTipoProd> List = new List<ListaTipoProd>();
                List.Add(new ListaTipoProd { texto = "SERVICIOS", value = "C1" });

                cboCLASE_BIEN.DataSource = List;
                cboCLASE_BIEN.DisplayMember = "texto";
                cboCLASE_BIEN.SelectedIndex = 0;
            }

        }


        void TIPO_PAGO()
        {
            
                List<ListaTipoProd> List = new List<ListaTipoProd>();

                List.Add(new ListaTipoProd { texto = "EFECTIVO", value = "0001" });
                List.Add(new ListaTipoProd { texto = "TARJETA CREDITO", value = "0002" });
                List.Add(new ListaTipoProd { texto = "TARJETA DEBITO", value = "0003" });
                List.Add(new ListaTipoProd { texto = "DEPOSITO BANCARIO", value = "0004" });
                List.Add(new ListaTipoProd { texto = "TRANSFERENCIA BANCARIA", value = "0005" });
            List.Add(new ListaTipoProd { texto = "CHEQUE BANCARIO", value="0006"});

                cboTIPOPAGO.DataSource = List;
                cboTIPOPAGO.DisplayMember = "texto";
                cboTIPOPAGO.ValueMember = "value";
                cboTIPOPAGO.SelectedIndex = 0;
               
        }
        


        void LLENAR_MENU_BIENES()
        {

            DataTable dt = new DataTable();
            E_OBJVENTAS.ID_CLASE = cboCLASE_BIEN.SelectedValue.ToString();
            E_OBJVENTAS.ID_EMPRESA = Properties.Settings.Default.id_empresa;
            dt = N_OBJVENTAS.BIEN_X_CLASE(E_OBJVENTAS); //llenar el datatable con los datos del filtrado de bienes por clase

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                if (i < 20) //esto controla los 16 botones asignados para los platos
                {
                    valor[i] = dt.Rows[i][1].ToString();     //esto permite obtener la descripcion y el precio de los bienes
                    idbien[i] = dt.Rows[i][0].ToString();     //esto permite obtener los codigos de cada bien que contiene el datatable
                    PRECIO_BIEN[i] = dt.Rows[i][2].ToString();
                }

            }

            btnBIEN01.Text = valor[0];
            btnBIEN02.Text = valor[1];
            btnBIEN03.Text = valor[2];
            btnBIEN04.Text = valor[3];
            btnBIEN05.Text = valor[4];
            btnBIEN06.Text = valor[5];
            btnBIEN07.Text = valor[6];
            btnBIEN08.Text = valor[7];
            btnBIEN09.Text = valor[8];
            btnBIEN10.Text = valor[9];
            btnBIEN11.Text = valor[10];
            btnBIEN12.Text = valor[11];
            btnBIEN13.Text = valor[12];
            btnBIEN14.Text = valor[13];
            btnBIEN15.Text = valor[14];
            btnBIEN16.Text = valor[15];
            btnBIEN17.Text = valor[16];
            btnBIEN18.Text = valor[17];
            btnBIEN19.Text = valor[18];
            btnBIEN20.Text = valor[19];
        }

        void ESTRUCTURA_DETALLEBIEN()
        {
            
            DataColumn colum = vPdt_detBien.Columns.Add("ID_BIEN", typeof(String));
            colum.Unique = true;
            vPdt_detBien.Columns.Add(new DataColumn("CANT", typeof(double)));
            vPdt_detBien.Columns.Add(new DataColumn("DESCRIPCION", typeof(String)));
            vPdt_detBien.Columns.Add(new DataColumn("PRECIO", typeof(Double)));
            vPdt_detBien.Columns.Add(new DataColumn("IMPORTE", typeof(Double)));
            vPdt_detBien.PrimaryKey = new DataColumn[] { vPdt_detBien.Columns[0] };
            //estructura de la tabladetalle
            
        }

        void OBTENER_ID_BIEN_Y_LLENAR_GRILLA(string ID_BIEN, string DESCRIPCION, string PRECIO)
        {
            if (dgvBIEN_VENTA.Visible == false) { dgvBIEN_VENTA.Visible = true; }
            DataTable dt = vPdt_detBien;
            try
            {
                DataRow row = dt.NewRow();
                row["ID_BIEN"] = ID_BIEN;
                row["CANT"] = Convert.ToDouble(txtCANTIDAD_VENTA.Text); //
                row["DESCRIPCION"] = DESCRIPCION;
                if (txtPRECIO_VENTA.Text != string.Empty) // si es vacio tomo el precio del texbox precioventa
                {
                    row["PRECIO"] = Convert.ToDouble(txtPRECIO_VENTA.Text);
                }
                else //sino tomo el precio de la base de datos q esta en el parametro PRECIO
                {
                    row["PRECIO"] = Convert.ToDouble(PRECIO);
                }

                row["IMPORTE"] = Convert.ToDouble(row["PRECIO"]) * Convert.ToDouble(row["CANT"]);
                dt.Rows.Add(row);
                dt.AcceptChanges();
                
                LLENAR_GRILLA();
                ACTUALIZAR_TOTALES();

                //aqui limpio la data de ingreso de precio y cantidad de cada bien
                txtCANTIDAD_VENTA.Text = "1";
                txtPRECIO_VENTA.Text = string.Empty;

                txtCANTIDAD_VENTA.Focus();
            }
            catch (Exception)
            {

                // MessageBox.Show("EL BIEN YA ESTA EN LA LISTA");

            }
        }

        void LLENAR_GRILLA()
        {
            DataTable dt = vPdt_detBien;
            dgvBIEN_VENTA.DataSource = dt;
            
        }

        public void ACTUALIZAR_TOTALES()
        {
            double subTotal, igv, total = 0;
            DataTable dt = (DataTable)vPdt_detBien;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                total = total + Convert.ToDouble(dt.Rows[i][4].ToString());

            }
            subTotal = (total / 1.18);
            igv = total - subTotal;


            lblSUBTOTAL.Text = subTotal.ToString("N2");
            lblIGV.Text = igv.ToString("N2");
            lblTOTAL.Text = total.ToString("N2");
            
        }
        /*-----------------------AUTOCOMPLETAR---------------------------*/
        void autocompletar_DESCRIPCION()
        {
            try
            {
                txtCLIENTE_VENTA.AutoCompleteMode = AutoCompleteMode.Suggest;
                txtCLIENTE_VENTA.AutoCompleteSource = AutoCompleteSource.CustomSource;
                txtCLIENTE_RUC.AutoCompleteMode = AutoCompleteMode.Suggest;
                txtCLIENTE_RUC.AutoCompleteSource = AutoCompleteSource.CustomSource;
                AutoCompleteStringCollection col = new AutoCompleteStringCollection();
                AutoCompleteStringCollection ruc = new AutoCompleteStringCollection();
                
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT DESCRIPCION FROM CLIENTE", con);
               /* DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);*/
                SqlDataReader dr = null;
                
                dr = cmd.ExecuteReader();
                
                while (dr.Read())
                {
                    col.Add(dr["DESCRIPCION"].ToString());
                }
                dr.Close();
                txtCLIENTE_VENTA.AutoCompleteCustomSource = col;
                con.Close();
                con.Open();
                if (txtCLIENTE_VENTA.Text.Length >= 6) {
                    SqlCommand cmv = new SqlCommand("SELECT ID_CLIENTE,RUC_DNI FROM CLIENTE where DESCRIPCION = '" + txtCLIENTE_VENTA.Text + "'", con);
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmv);
                    da.Fill(dt);
                    txtCLIENTE_ID.Text = dt.Rows[0][0].ToString();
                    txtCLIENTE_RUC.Text = dt.Rows[0][1].ToString();
                    con.Close();
                } else { con.Close();}
            }

            catch
            {
            }
        }

        void autocompletar_RUCDNI()
        {
            try
            {

                
                txtCLIENTE_RUC.AutoCompleteMode = AutoCompleteMode.Suggest;
                txtCLIENTE_RUC.AutoCompleteSource = AutoCompleteSource.CustomSource;
                AutoCompleteStringCollection col = new AutoCompleteStringCollection();

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT RUC_DNI FROM CLIENTE", con);
                
                SqlDataReader dr = null;

                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    col.Add(dr["RUC_DNI"].ToString());
                }
                dr.Close();
                txtCLIENTE_RUC.AutoCompleteCustomSource = col;
                con.Close();
                con.Open();
                if (txtCLIENTE_RUC.Text.Length >=4)
                {
                    SqlCommand cmv = new SqlCommand("SELECT ID_CLIENTE,DESCRIPCION FROM CLIENTE where RUC_DNI = '" + txtCLIENTE_RUC.Text + "'", con);
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmv);
                    da.Fill(dt);
                    txtCLIENTE_ID.Text = dt.Rows[0][0].ToString();
                    txtCLIENTE_VENTA.Text = dt.Rows[0][1].ToString();
                    con.Close();
                }
                else { con.Close(); }
            }

            catch
            {
            }
        }


        /*---------------------------------------------------------------*/


        private void cboCLASE_BIEN_SelectedIndexChanged(object sender, EventArgs e)
        {
            LLENAR_MENU_BIENES();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtCLIENTE_VENTA.Text = string.Empty;
            txtCLIENTE_ID.Text = string.Empty;
            txtCLIENTE_RUC.Text = string.Empty;
            
        }

        #region
        private void btnBIEN01_Click_1(object sender, EventArgs e)
        {
            if (idbien[0] != null)
            {
                OBTENER_ID_BIEN_Y_LLENAR_GRILLA(idbien[0].ToString(), valor[0].ToString(), PRECIO_BIEN[0].ToString());

            }
        }

        private void btnBIEN02_Click(object sender, EventArgs e)
        {
            if (idbien[1] != null)
            {
                OBTENER_ID_BIEN_Y_LLENAR_GRILLA(idbien[1].ToString(), valor[1].ToString(), PRECIO_BIEN[1].ToString());

            }
        }

        protected void btnBIEN03_Click(object sender, EventArgs e)
        {
            if (idbien[2] != null)
            {
                OBTENER_ID_BIEN_Y_LLENAR_GRILLA(idbien[2].ToString(), valor[2].ToString(), PRECIO_BIEN[2].ToString());
            }
        }

        protected void btnBIEN04_Click(object sender, EventArgs e)
        {
            if (idbien[3] != null)
            {
                OBTENER_ID_BIEN_Y_LLENAR_GRILLA(idbien[3].ToString(), valor[3].ToString(), PRECIO_BIEN[3].ToString());
            }
        }

        protected void btnBIEN05_Click(object sender, EventArgs e)
        {
            if (idbien[4] != null)
            {
                OBTENER_ID_BIEN_Y_LLENAR_GRILLA(idbien[4].ToString(), valor[4].ToString(), PRECIO_BIEN[4].ToString());
            }
        }

        protected void btnBIEN06_Click(object sender, EventArgs e)
        {
            if (idbien[5] != null)
            {
                OBTENER_ID_BIEN_Y_LLENAR_GRILLA(idbien[5].ToString(), valor[5].ToString(), PRECIO_BIEN[5].ToString());
            }
        }

        protected void btnBIEN07_Click(object sender, EventArgs e)
        {
            if (idbien[6] != null)
            {
                OBTENER_ID_BIEN_Y_LLENAR_GRILLA(idbien[6].ToString(), valor[6].ToString(), PRECIO_BIEN[6].ToString());
            }
        }

        protected void btnBIEN08_Click(object sender, EventArgs e)
        {
            if (idbien[7] != null)
            {
                OBTENER_ID_BIEN_Y_LLENAR_GRILLA(idbien[7].ToString(), valor[7].ToString(), PRECIO_BIEN[7].ToString());
            }
        }

        protected void btnBIEN09_Click(object sender, EventArgs e)
        {
            if (idbien[8] != null)
            {
                OBTENER_ID_BIEN_Y_LLENAR_GRILLA(idbien[8].ToString(), valor[8].ToString(), PRECIO_BIEN[8].ToString());
            }
        }

        protected void btnBIEN10_Click(object sender, EventArgs e)
        {
            if (idbien[9] != null)
            {
                OBTENER_ID_BIEN_Y_LLENAR_GRILLA(idbien[9].ToString(), valor[9].ToString(), PRECIO_BIEN[9].ToString());
            }
        }

        protected void btnBIEN11_Click(object sender, EventArgs e)
        {
            if (idbien[10] != null)
            {
                OBTENER_ID_BIEN_Y_LLENAR_GRILLA(idbien[10].ToString(), valor[10].ToString(), PRECIO_BIEN[10].ToString());
            }
        }

        protected void btnBIEN12_Click(object sender, EventArgs e)
        {
            if (idbien[11] != null)
            {
                OBTENER_ID_BIEN_Y_LLENAR_GRILLA(idbien[11].ToString(), valor[11].ToString(), PRECIO_BIEN[11].ToString());
            }
        }

        protected void btnBIEN13_Click(object sender, EventArgs e)
        {
            if (idbien[12] != null)
            {
                OBTENER_ID_BIEN_Y_LLENAR_GRILLA(idbien[12].ToString(), valor[12].ToString(), PRECIO_BIEN[12].ToString());
            }
        }

        protected void btnBIEN14_Click(object sender, EventArgs e)
        {
            if (idbien[13] != null)
            {
                OBTENER_ID_BIEN_Y_LLENAR_GRILLA(idbien[13].ToString(), valor[13].ToString(), PRECIO_BIEN[13].ToString());
            }
        }

        protected void btnBIEN15_Click(object sender, EventArgs e)
        {
            if (idbien[14] != null)
            {
                OBTENER_ID_BIEN_Y_LLENAR_GRILLA(idbien[14].ToString(), valor[14].ToString(), PRECIO_BIEN[14].ToString());
            }
        }

        protected void btnBIEN16_Click(object sender, EventArgs e)
        {
            if (idbien[15] != null)
            {
                OBTENER_ID_BIEN_Y_LLENAR_GRILLA(idbien[15].ToString(), valor[15].ToString(), PRECIO_BIEN[15].ToString());
            }
        }
        protected void btnBIEN17_Click(object sender, EventArgs e)
        {
            if (idbien[16] != null)
            {
                OBTENER_ID_BIEN_Y_LLENAR_GRILLA(idbien[16].ToString(), valor[16].ToString(), PRECIO_BIEN[16].ToString());
            }
        }
        protected void btnBIEN18_Click(object sender, EventArgs e)
        {
            if (idbien[17] != null)
            {
                OBTENER_ID_BIEN_Y_LLENAR_GRILLA(idbien[17].ToString(), valor[17].ToString(), PRECIO_BIEN[17].ToString());
            }
        }
        protected void btnBIEN19_Click(object sender, EventArgs e)
        {
            if (idbien[18] != null)
            {
                OBTENER_ID_BIEN_Y_LLENAR_GRILLA(idbien[18].ToString(), valor[18].ToString(), PRECIO_BIEN[18].ToString());
            }
        }
        protected void btnBIEN20_Click(object sender, EventArgs e)
        {
            if (idbien[19] != null)
            {
                OBTENER_ID_BIEN_Y_LLENAR_GRILLA(idbien[19].ToString(), valor[19].ToString(), PRECIO_BIEN[19].ToString());
            }
        }

        #endregion

        
        public void Eliminar_Registro(String cod)
        {
            DataTable dt = (DataTable)vPdt_detBien;
            DataRow row;
            row = dt.Rows.Find(cod);
            row.Delete();
            row.AcceptChanges();
            LLENAR_GRILLA();
            ACTUALIZAR_TOTALES();
        }








        private void dgvBIEN_VENTA_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
           
            if (this.dgvBIEN_VENTA.Columns[e.ColumnIndex].Name == "colBotonEliminar")
                {
                    
                    
                    dgvBIEN_VENTA.Rows.RemoveAt(e.RowIndex);
                    DataTable dt = (DataTable)vPdt_detBien;
                    dt.Rows.RemoveAt(e.RowIndex);
                    

                
                }
            ACTUALIZAR_TOTALES();
            
        }

        /*------------------------------------PARTE VENTAS---------------------------------------*/
        void MANTENIMIENTO_VENTA()
        {
            try
            {
                E_OBJMANT_VENTADET.ID_VENTA = string.Empty;
                E_OBJMANT_VENTADET.SERIE = Properties.Settings.Default.serie;
                E_OBJMANT_VENTADET.TIPO_DOC = cboTIPO_DOC.SelectedItem.ToString();
                E_OBJMANT_VENTADET.MONEDA = "S";
                E_OBJMANT_VENTADET.VALOR_VENTA = Convert.ToDouble(lblSUBTOTAL.Text);
                E_OBJMANT_VENTADET.IGV = Convert.ToDouble(lblIGV.Text);
                E_OBJMANT_VENTADET.TOTAL = Convert.ToDouble(lblTOTAL.Text);
                E_OBJMANT_VENTADET.SALDO = 0.00;
                E_OBJMANT_VENTADET.ID_SEDE = v_sede;
                E_OBJMANT_VENTADET.ID_PEDIDO = null;
                E_OBJMANT_VENTADET.ID_CLIENTE = txtCLIENTE_ID.Text;
                E_OBJMANT_VENTADET.CLIENTE = txtCLIENTE_VENTA.Text;
                E_OBJMANT_VENTADET.ACCION = "1";

                N_OBJVENTAS.MANTENIMIENTO_VENTA(E_OBJMANT_VENTADET); //AQUI CARGO LA VENTA
                MANTENIMIENTO_VENTADETALLE();                        // AQUI CARGO EL DETALLE DE LA VENTA
                MANTENIMIENTO_CAJA_KARDEX();//AQUI LLAMO A MI PROCEDIMIENTO PAR GENERAR EL INGRESO EN CAJA KARDEX
                //IMPRIMIR_SPOOL();   //
                //this.Refresh();
            }
            catch (Exception)
            {

                
                MessageBox.Show("REGISTRA TODOS LOS CAMPOS NECESARIOS PARA LA VENTA", "Alerta de Venta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }


            LIMPIAR_VENTA();
            

        }

        void LIMPIAR_VENTA()
        {
            DataTable dt = (DataTable)vPdt_detBien;
            cboTIPO_DOC.SelectedValue = "TB";
            txtCLIENTE_VENTA.Text = string.Empty;
            lblSUBTOTAL.Text = string.Empty;
            lblIGV.Text = string.Empty;
            lblTOTAL.Text = string.Empty;
            txtPAGA.Text = string.Empty;
            
            dt.Clear();
            

        }


        void MANTENIMIENTO_VENTADETALLE()
        {
            DataTable detalleVenta = (DataTable)vPdt_detBien;

            try
            {
                for (int i = 0; i < dgvBIEN_VENTA.Rows.Count; i++)
                {
                    E_OBJMANT_VENTADET.ID_VENTA = E_OBJMANT_VENTADET.ID_VENTA;
                    E_OBJMANT_VENTADET.ID_BIEN = dgvBIEN_VENTA.Rows[i].Cells[1].Value.ToString();
                    E_OBJMANT_VENTADET.ITEM = i + 1;
                   // Label can = dgvBIEN_VENTA.Rows[i].FindControl("Label1") as Label;
                    E_OBJMANT_VENTADET.CANTIDAD = Convert.ToDouble(dgvBIEN_VENTA.Rows[i].Cells[2].Value.ToString());
                   // Label pre = dgvBIEN_VENTA.Rows[i].FindControl("Label2") as Label;
                    E_OBJMANT_VENTADET.PRECIO = Convert.ToDouble(dgvBIEN_VENTA.Rows[i].Cells[4].Value.ToString());
                    E_OBJMANT_VENTADET.IMPORTE = Convert.ToDouble(dgvBIEN_VENTA.Rows[i].Cells[5].Value.ToString());
                    E_OBJMANT_VENTADET.SALDO_CANTIDAD = 0.00;
                    //1 = VENTA_DIRECTA Y NECESITO GRABAR EL DETALLE DE PEDIDO Y EL DETALLE DE LA VENTA 
                    E_OBJMANT_VENTADET.GRABA_PEDIDO_DETALLE = "1";

                    N_OBJVENTAS.MANTENIMIENTO_VENTADETALLE(E_OBJMANT_VENTADET);
                }
            }
            catch (Exception)
            {

                //Response.Write("<script>window.alert('NO ESCOGISTE NINGUN BIEN A VENDER');</script>");
            }

        }


        public void MANTENIMIENTO_EEECAJA_KARDEX()
        {
            try
            {
                E_OBJCAJA_KARDEX.ID_MOVIMIENTO = string.Empty;

                if (cboTIPOPAGO.SelectedItem.ToString() == "EFECTIVO")
                {
                    E_OBJCAJA_KARDEX.DESCRIPCION = "VENTA DIRECTA";
                }
                else
                {
                    E_OBJCAJA_KARDEX.DESCRIPCION = "VENTA DIRECTA " + txtTIPO_PAGO.Text;
                }

                E_OBJCAJA_KARDEX.ID_COMPVENT = E_OBJMANT_VENTADET.ID_VENTA; //id de la venta

                E_OBJCAJA_KARDEX.ID_TIPOPAGO = cboTIPOPAGO.SelectedValue.ToString(); // AQUI SE ANOTA EL PAGO POR EL CONCEPTO QUE SE ELIGIO

                E_OBJCAJA_KARDEX.ID_TIPOMOV = "IPV"; //ingreso por venta 
                E_OBJCAJA_KARDEX.IMPORTE = Convert.ToDouble(lblTOTAL.Text.ToString());
                E_OBJCAJA_KARDEX.MONEDA = "S";
                E_OBJCAJA_KARDEX.TIPO_CAMBIO = Convert.ToDouble(Properties.Settings.Default.tipo_cambio);
                E_OBJCAJA_KARDEX.AMORTIZADO = Convert.ToDouble(lblTOTAL.Text.ToString());
                E_OBJCAJA_KARDEX.ID_CAJA = Properties.Settings.Default.id_caja;
                E_OBJCAJA_KARDEX.IMPORTE_CAJA = Convert.ToDouble(lblTOTAL.Text.ToString());
                E_OBJCAJA_KARDEX.OPCION = 1;

                N_OBJVENTAS.CAJA_KARDEX_MANTENIMIENTO(E_OBJCAJA_KARDEX);
            }
            catch (Exception)
            {

                throw;
            }

        }


        public void MANTENIMIENTO_CAJA_KARDEX()
        {
            try
            {
                E_OBJCAJA_KARDEX.ID_MOVIMIENTO = string.Empty;

                if (cboTIPOPAGO.SelectedItem.ToString() == "EFECTIVO")
                {
                    E_OBJCAJA_KARDEX.DESCRIPCION = "VENTA DIRECTA";
                }
                else
                {
                    E_OBJCAJA_KARDEX.DESCRIPCION = "VENTA DIRECTA " + txtTIPO_PAGO.Text;
                }

                E_OBJCAJA_KARDEX.ID_COMPVENT = E_OBJMANT_VENTADET.ID_VENTA; //id de la venta

                E_OBJCAJA_KARDEX.ID_TIPOPAGO = cboTIPOPAGO.SelectedValue.ToString(); // AQUI SE ANOTA EL PAGO POR EL CONCEPTO QUE SE ELIGIO

                E_OBJCAJA_KARDEX.ID_TIPOMOV = "IPV"; //ingreso por venta 
                E_OBJCAJA_KARDEX.IMPORTE = Convert.ToDouble(lblTOTAL.Text.ToString());
                E_OBJCAJA_KARDEX.MONEDA = "S";
                E_OBJCAJA_KARDEX.TIPO_CAMBIO = Convert.ToDouble(Properties.Settings.Default.tipo_cambio);
                E_OBJCAJA_KARDEX.AMORTIZADO = Convert.ToDouble(lblTOTAL.Text.ToString());
                E_OBJCAJA_KARDEX.ID_CAJA = Properties.Settings.Default.id_caja;
                E_OBJCAJA_KARDEX.IMPORTE_CAJA = Convert.ToDouble(lblTOTAL.Text.ToString());
                E_OBJCAJA_KARDEX.OPCION = 1;

                N_OBJVENTAS.CAJA_KARDEX_MANTENIMIENTO(E_OBJCAJA_KARDEX);
            }
            catch (Exception)
            {

                throw;
            }
        }




        private void button3_Click(object sender, EventArgs e)
        {
            if (VALIDAR_DATOS())  
            {

                if (txtPAGA.Text.ToString() != string.Empty)
                {
                    if (Convert.ToDouble(txtPAGA.Text) >= Convert.ToDouble(lblTOTAL.Text))
                    {
                        double TOTAL = Convert.ToDouble(lblTOTAL.Text);
                        PAGA = Convert.ToDouble(txtPAGA.Text);
                        VUELTO = Convert.ToDouble(Convert.ToDouble(PAGA - TOTAL).ToString("N2"));
                        
                    }
                    else
                    {
                        MessageBox.Show("INGRESAR UN MONTO MAYOR AL MONTO TOTAL", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
                //CREAR MESSAGEBOX DE PREGUNTA PARA FINALIZAR VENTA
                //MessageBox.Show("¿QUIERE REALIZAR LA VENTA?", "!!ATENCION!!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                DialogResult result = MessageBox.Show("¿QUIERE REALIZAR LA VENTA?", "!!ATENCION!!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    MANTENIMIENTO_VENTA();
                    cboTIPO_DOC.SelectedIndex = 0;//REGRESANDO EL TIPO DE DOC A BOLETA DE VENTA
                    cboCLASE_BIEN.SelectedIndex = 0;
                    txtCLIENTE_ID.Text = string.Empty;
                    txtCLIENTE_RUC.Text = string.Empty;
                    txtCLIENTE_VENTA.Text = string.Empty;
                }
                else if (result == DialogResult.Cancel)
                {
                    txtCLIENTE_ID.Text = string.Empty;
                    txtCLIENTE_RUC.Text = string.Empty;
                    txtCLIENTE_VENTA.Text = string.Empty;
                    LIMPIAR_VENTA();
                }
                
                     
                
                
            }
            else
            {
                MessageBox.Show("ERROR, NO SE SELECCIONARON NI SE LLENARON TODOS LOS DATOS CORRECTOS, VUELVA A INTENTARLO...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        
        private void button1_Click(object sender, EventArgs e)
        {
            CAJA OBJCAJA = new CAJA();
             
            OBJCAJA.txtIDcaja.Text = Properties.Settings.Default.id_caja;
            OBJCAJA.id_empleado = v_id_empleado;
            OBJCAJA.id_puntoventa = v_id_puntoventa;
            OBJCAJA.sede = v_sede;
            OBJCAJA.tipo_cambio = v_tipo_cambio;
            OBJCAJA.nombre_empleado = v_nombre_empleado;
            OBJCAJA.id_empresa = v_id_empresa;
            OBJCAJA.Visible=true;
            this.Close();
        }

        private void txtCLIENTE_VENTA_TextChanged(object sender, EventArgs e)
        {
            autocompletar_DESCRIPCION();
        }

        private void txtCLIENTE_RUC_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtCLIENTE_VENTA_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtCLIENTE_RUC_TextChanged(object sender, EventArgs e)
        {
            autocompletar_RUCDNI();
        }

        private bool VALIDAR_DATOS()
        {
            bool retorno = false;
            if (dgvBIEN_VENTA.Rows.Count > 0)
            {
                /*
                           if (cboTIPO_DOC.SelectedIndex == 1) //si es ticket factura?
                           {
                             if (Convert.ToDouble(lblTOTAL.Text) < 700) //solo permitir hacer ticket factura <= a 700
                               {
                                if (txtID_CLIENTE.Text != string.Empty)
                                  {
                                     if(cboTIPO_PAGO.SelectedItem.Text != "EFECTIVO") //SI EL PAGO ES EN EFECTIVO
                                         {
                                               if (txtTIPO_PAGO.Text != string.Empty) //SI EL CAMPO DONDE SE LLENA LA OPERACION YL NUMERO Y TODOS DATOS DEL DOCUMENTO DE OPERACION ESTA LLENO
                                               {
                                                   if (txtPAGA.Text != string.Empty)
                                                   {

                                                       retorno = true;

                                                   }
                                                   else
                                                   {
                                                       retorno = false;
                                                   }
                                               }
                                                   else
                                                   {
                                                       retorno = false;
                                                   }
                                         }
                                         else
                                         {
                                           retorno = true;
                                         }

                                       }
                                   else //el id cliente esta vacio y es factura 
                                   {
                                       retorno = false;
                                   }
                               }
                               else //en este caso la factura es > a 700 entonces no se debe generar la venta
                               {
                                   retorno = false;
                               }

                           }
                     */
                if (cboTIPO_DOC.SelectedIndex == 0)//si es boleta entonces
                {
                    if (Convert.ToDouble(lblTOTAL.Text) >= 700)  //tiene q escoger un cliente si la boleta es >= que 700
                    {
                        if (txtCLIENTE_ID.Text != string.Empty) //
                        {
                            if (cboTIPOPAGO.SelectedItem.ToString() != "EFECTIVO") //SI EL PAGO ES EN EFECTIVO
                            {
                                if (cboTIPOPAGO.Text != string.Empty) //SI EL CAMPO DONDE SE LLENA LA OPERACION YL NUMERO Y TODOS DATOS DEL DOCUMENTO DE OPERACION ESTA LLENO
                                {
                                    if (txtPAGA.Text != string.Empty)
                                    {
                                        retorno = true;
                                    }
                                    else
                                    {
                                        retorno = false;
                                    }
                                }
                                else
                                {
                                    retorno = false;
                                }
                            }
                            else
                            {
                                retorno = true;
                            }
                        }
                        else //el id_cliente est vacio
                        {
                            retorno = false;
                        }
                    }
                    else // es boleta y < de 700 entonces no interesa los datos del cliente
                    {
                        if (txtPAGA.Text != string.Empty)
                        {

                            if (Convert.ToDouble(txtPAGA.Text.ToString()) >= Convert.ToDouble(lblTOTAL.Text.ToString()))
                            {
                                if (cboTIPOPAGO.SelectedItem.ToString() != "EFECTIVO") //SI EL PAGO ES EN EFECTIVO
                                {
                                    if (cboTIPOPAGO.Text != string.Empty) //SI EL CAMPO DONDE SE LLENA LA OPERACION YL NUMERO Y TODOS DATOS DEL DOCUMENTO DE OPERACION ESTA LLENO
                                    {
                                        retorno = true;
                                    }
                                    else
                                    {
                                        retorno = false;
                                    }
                                }
                                else
                                {
                                    retorno = true;
                                }
                            }
                            else
                            {
                                retorno = false;
                            }
                        }
                        else
                        {
                            retorno = false;
                        }
                    }

                }

            }
            return retorno;
        }


    }
}
