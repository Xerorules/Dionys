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
using System.Data.SqlClient;
using System.Data.Sql;
using System.Configuration;

namespace WindowsFormsApplication1
{
    public partial class BUSCAR_CLIENTE : Form
    {
        public string bc_id_caja;
        public string bc_id_puntoventa;
        public string bc_id_empleado;
        public string bc_id_empresa;
        public string bc_nombre_empleado;
        public string bc_tipo_cambio;
        public string bc_sede;
        public string bc_fchapertura;
        public string bc_fchacierre;
        public string bc_saldo_ini;
        public string bc_saldo_fin;

        public string[] bcvalor = new string[20];
        public string[] bcidbien = new string[20];
        public string[] bcPRECIO_BIEN = new string[20];
        public DataTable detalle = new DataTable();



        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["sql"].ConnectionString);
        public string bc_id_cliente;
        string vFILTRO = "";
        public BUSCAR_CLIENTE()
        {

            InitializeComponent();
        }

        private void BUSCAR_CLIENTE_Load(object sender, EventArgs e)
        {
            llenar_tipo_cliente();
            P_LISTAR_DEPARTAMENTO();//AQUI CARGAMOS LA LISTA DE DEPARTAMENTOS

            vFILTRO = " ESTADO = 1";

            //crea botones en el gridview
            DataGridViewButtonColumn colBotones = new DataGridViewButtonColumn();
            colBotones.Name = "colBotones";
            colBotones.HeaderText = "Seleccionar";
            colBotones.Text = "Seleccionar";
            colBotones.UseColumnTextForButtonValue = true;
            this.dgvClientes.Columns.Add(colBotones);
            //------------------------------------------------------------///
            CARGAR_DATOS(CONCATENAR_CONDICION());
            cboMC_DEPARTAMENTO_SelectedIndexChanged(sender, e);
            cboMC_PROVINCIA_SelectedIndexChanged(sender, e);
            //DataTable detalle = (DataTable)OBJINT.vPdt_detBien;



        }

        #region OBJETOS
        E_MANT_CLIENTE E_OBJCLIENTE = new E_MANT_CLIENTE();
        N_VENTA N_OBJCLIENTE = new N_VENTA();

       



        #endregion

        private void cboMC_DEPARTAMENTO_SelectedIndexChanged(object sender, EventArgs e)
        {
            P_LISTAR_PROVINCIA(cboMC_DEPARTAMENTO.SelectedValue.ToString());
            cboMC_PROVINCIA_SelectedIndexChanged(sender, e);
        }

        private void cboMC_PROVINCIA_SelectedIndexChanged(object sender, EventArgs e)
        {
            P_LISTAR_DISTRITO(cboMC_PROVINCIA.SelectedValue.ToString());
        }

        void P_LISTAR_DEPARTAMENTO()
        {
            DataTable dt = N_OBJCLIENTE.LISTAR_DEPARTAMENTO();
            cboMC_DEPARTAMENTO.DataSource = dt;
            cboMC_DEPARTAMENTO.ValueMember = "UBIDEP";
            cboMC_DEPARTAMENTO.DisplayMember = "UBIDEN";

            //cboMC_DEPARTAMENTO.DataBind();
        }
        void P_LISTAR_PROVINCIA(string depart)
        {
            DataTable dt = N_OBJCLIENTE.LISTAR_PROVINCIA(depart);
            cboMC_PROVINCIA.DataSource = dt;
            cboMC_PROVINCIA.ValueMember = "UBIPRV";
            cboMC_PROVINCIA.DisplayMember = "UBIPRN";

            //cboMC_PROVINCIA.DataBind();
        }
        void P_LISTAR_DISTRITO(string prov)
        {
            DataTable dt = N_OBJCLIENTE.LISTAR_DISTRITO(prov);
            cboMC_DISTRITO.DataSource = dt;
            cboMC_DISTRITO.ValueMember = "UBIDST";
            cboMC_DISTRITO.DisplayMember = "UBIDSN";

            //cboMC_DISTRITO.DataBind();
        }

        private void cboMC_DISTRITO_SelectedIndexChanged(object sender, EventArgs e)
        {
            //
        }

        void autocompletar_DESCRIPCION()
        {
            try
            {
                textBox1.AutoCompleteMode = AutoCompleteMode.Suggest;
                textBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;
                AutoCompleteStringCollection col = new AutoCompleteStringCollection();


                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT DESCRIPCION FROM CLIENTE", con);
                SqlDataReader dr = null;
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    col.Add(dr["DESCRIPCION"].ToString());

                }
                dr.Close();

                textBox1.AutoCompleteCustomSource = col;

                con.Close();
            }
            catch
            {
            }
        }
        void autocompletar_dni_ruc()
        {
            try
            {
                txtFDNI.AutoCompleteMode = AutoCompleteMode.Suggest;
                txtFDNI.AutoCompleteSource = AutoCompleteSource.CustomSource;
                AutoCompleteStringCollection col = new AutoCompleteStringCollection();

                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT RUC_DNI FROM CLIENTE", con);
                SqlDataReader dr = null;
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    col.Add(dr["RUC_DNI"].ToString());
                }
                dr.Close();

                txtFDNI.AutoCompleteCustomSource = col;
                con.Close();
            }
            catch
            {
            }
        }

       
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            autocompletar_DESCRIPCION();
            vFILTRO = " ESTADO = 1";
            CARGAR_DATOS(CONCATENAR_CONDICION());

        }

        private void txtFDNI_TextChanged(object sender, EventArgs e)
        {
            autocompletar_dni_ruc();
            vFILTRO = " ESTADO = 1";
            CARGAR_DATOS(CONCATENAR_CONDICION());
        }


        public void CARGAR_DATOS(string pCONDICION)
        {
            DataTable dt = new DataTable();
            dt= N_OBJCLIENTE.CONSULTA_LISTA_CLIENTES(pCONDICION);
            dgvClientes.DataSource = dt;
            
        }

        public string CONCATENAR_CONDICION()
        {
            if (textBox1.Text != string.Empty)
            {
                vFILTRO = " DESCRIPCION LIKE '%" + textBox1.Text + "%'";
            }

            if (txtFDNI.Text != string.Empty)
            {
                vFILTRO += " AND RUC_DNI LIKE '%" + txtFDNI.Text + "%'";
            }
            if (cboTipoCliente.SelectedIndex != 0)
            {
                vFILTRO += " AND TIPO_CLIENTE = '" + cboTipoCliente.SelectedValue + "'";
            }
            if (cboMC_DEPARTAMENTO.SelectedIndex != 0)
            {
                vFILTRO += " AND UBIDEN = '%" + cboMC_DEPARTAMENTO.SelectedItem + "%'";
            }
            if (cboMC_PROVINCIA.SelectedIndex != 0)
            {
                vFILTRO += " AND UBIPRN = '%" + cboMC_PROVINCIA.SelectedItem + "%'";
            }
            if (cboMC_DISTRITO.SelectedIndex != 0)
            {
                vFILTRO += " AND UBIDSN = '%" + cboMC_DISTRITO.SelectedItem + "%'";
            }

            

            return vFILTRO;
        }

        public void llenar_tipo_cliente()
            {
            List<ListaTipoProd> List = new List<ListaTipoProd>();

            List.Add(new ListaTipoProd { texto = "P. NATURAL", value = "PN" });
            List.Add(new ListaTipoProd { texto = "P. JURIDICA", value = "PJ" });
            
            cboTipoCliente.DataSource = List;
            cboTipoCliente.DisplayMember = "texto";
            cboTipoCliente.ValueMember = "value";
            cboTipoCliente.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            vFILTRO = " ESTADO = 1";
            CARGAR_DATOS(CONCATENAR_CONDICION());
            
        }

        private void dgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dgvClientes.Columns[e.ColumnIndex].Name == "colBotones")
            {
               // T_DETALLE detalle = new T_DETALLE();
                InterfazVenta OBJINT = new InterfazVenta();
                string id_CLIENTE_dgv = dgvClientes.Rows[e.RowIndex].Cells["ID_CLIENTE"].Value.ToString();
                string id_DNIRUC_dgv = dgvClientes.Rows[e.RowIndex].Cells["RUC_DNI"].Value.ToString();
                string id_DESCRIPCION_dgv = dgvClientes.Rows[e.RowIndex].Cells["DESCRIPCION"].Value.ToString();
              
                /*-------------REVISAR CODIGO---------------*/
                OBJINT.txtCLIENTE_VENTA.Text = dgvClientes.Rows[e.RowIndex].Cells["DESCRIPCION"].Value.ToString();

                OBJINT.txtCLIENTE_RUC.Text = dgvClientes.Rows[e.RowIndex].Cells["RUC_DNI"].Value.ToString();

                OBJINT.txtCLIENTE_ID.Text = dgvClientes.Rows[e.RowIndex].Cells["ID_CLIENTE"].Value.ToString();
                
               /*-------------REVISAR CODIGO---------------*/
                OBJINT.v_id_caja = Program.id_caja;
                OBJINT.lblCajaIDVentas.Text = Program.id_caja;
                OBJINT.v_id_puntoventa = bc_id_puntoventa;
                OBJINT.v_id_empleado = bc_id_empleado;
                OBJINT.v_id_empresa = bc_id_empresa;
                OBJINT.v_nombre_empleado = bc_nombre_empleado;
                OBJINT.v_tipo_cambio = bc_tipo_cambio;
                OBJINT.v_sede = bc_sede;
                OBJINT.v_fchapertura = bc_fchapertura;
                OBJINT.v_fchacierre = bc_fchacierre;
                OBJINT.v_saldo_ini = bc_saldo_ini;
                OBJINT.v_saldo_fin = bc_saldo_fin;
                //OBJINT.Visible = true;/*REVISAR HACER QUE MANDE VALORES SIN LODEAR*/
                this.Close();
            }

        }
    }
}
