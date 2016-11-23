using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Reflection;
using System.Data.Sql;
using System.Data.SqlClient;
using CAPA_ENTIDAD;
using CAPA_NEGOCIO;
using System.Threading;
using System.Globalization;



namespace WindowsFormsApplication1
{
    public partial class LOGIN : Form
    {
        //public string iduser;
        public  string idcaja;
        public string saldo_inicial;
        public string id_puntoventa;
        public LOGIN()
        {
            
            InitializeComponent();
            
        }

        private void LOGIN_Load(object sender, EventArgs e)
        {
            LISTAR_EMPRESA();
            comboBox1_SelectedIndexChanged(sender, e);
            comboBox2_SelectedIndexChanged(sender, e);
        }

        #region OBJETOS
        N_LOGUEO OBJLOGUEO = new N_LOGUEO();
        E_LOGUEO OBJLOGUEOE = new E_LOGUEO();
        N_VENTA N_OBJVENTAS = new N_VENTA();
        E_MANTENIMIENTO_CAJA E_OBJ_MANTCAJA = new E_MANTENIMIENTO_CAJA();
        E_VARIABLES_GLOBALES OBJVARIABLES = new E_VARIABLES_GLOBALES();
        
        #endregion

        private void LISTAR_EMPRESA()
        {
            comboBox1.DataSource = OBJLOGUEO.LISTAR_EMPRESA();
            comboBox1.ValueMember = "ID_EMPRESA";
            comboBox1.DisplayMember = "DESCRIPCION";
            
        }
        private void LISTAR_SEDE(string ID_EMPRESA)
        {
            comboBox2.DataSource = OBJLOGUEO.LISTAR_SEDE(ID_EMPRESA);
            comboBox2.ValueMember = "ID_SEDE";
            comboBox2.DisplayMember= "DESCRIPCION";
            
        } 
        private void LISTA_PUNTOVENTA(string ID_SEDE)
        {
            comboBox3.DataSource = OBJLOGUEO.PUNTO_VENTA(ID_SEDE);
            comboBox3.ValueMember = "PK_PUNTO_VENTA";
            comboBox3.DisplayMember = "DESCRIPCION";
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            LISTAR_SEDE(comboBox1.SelectedValue.ToString());
            //comboBox2_SelectedIndexChanged(sender, e);
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            LISTA_PUNTOVENTA(comboBox2.SelectedValue.ToString());
        }

        private void InformationProcessed()
        {
            // This code will set the DialogResult for a form.
            DialogResult = DialogResult.Yes;
            // OR
            // This code will set the DialogResult for a button.
            btnINGRESAR.DialogResult = DialogResult.No;
        }
        private void btnINGRESAR_Click(object sender, EventArgs e)
        {
            VALIDAR_USUARIO();
            OBJVARIABLES.id_puntoventa = VG_ID_PUNTOVENTA();
            
        }

       

        #region VARIABLES_GLOBALES
        private string VG_SEDE()
        {
            string var, sede;
            var = comboBox3.SelectedValue.ToString();
            sede = var.Substring(0, 3);

            return sede;
        }
        private string VG_SERIE()
        {
            string var, serie;
            var = comboBox3.SelectedValue.ToString();
            serie = var.Substring(4, 4);

            return serie;
        }
        private string VG_ID_PUNTOVENTA()
        {
            string var, ID_PUNTOVENTA;
                var = comboBox3.SelectedValue.ToString();
                ID_PUNTOVENTA = var.Substring(9, 5);
                
            return ID_PUNTOVENTA;
        }
        private string VG_SEDE_DESCRIPCION()
        {
            string var, SEDE_DESCRIPCION;
            var = comboBox3.SelectedValue.ToString();
            SEDE_DESCRIPCION = var.Substring(15, var.Length - 15).ToString();

            return SEDE_DESCRIPCION;
        }

        #endregion

        
        private void VALIDAR_USUARIO()
        {
            string USUARIO = txtDNI_USUARIO.Text.ToString();
            string CONTRASENA = txtCLAVE.Text.ToString();
            string ID_SEDE = VG_SEDE();
            
        DataTable dt = OBJLOGUEO.VALIDAR_USUARIO(USUARIO, CONTRASENA, ID_SEDE);


            if (dt.Rows.Count != 0)
            {

                OBJVARIABLES.id_puntoventa = VG_ID_PUNTOVENTA();
                OBJVARIABLES.Idcaja = string.Empty;
                OBJVARIABLES.id_empresa = comboBox1.SelectedValue.ToString();
                OBJVARIABLES.id_empleado = dt.Rows[0]["ID_EMPLEADO"].ToString();
                OBJVARIABLES.nombre_empleado = dt.Rows[0]["NOMBRE"].ToString();
                OBJVARIABLES.tipo_cambio = String.Empty;
                OBJVARIABLES.sede = VG_SEDE();

                label7.Text = "BIENVENIDO(A)...";
                VALIDAR_ASIGNAR_CAJA();
                VALIDAR_TIPO_CAMBIO();

                CAJA OBJCAJA = new CAJA();
                
                OBJCAJA.txtIDcaja.Text = OBJVARIABLES.Idcaja.ToString();
                Properties.Settings.Default.id_caja = OBJVARIABLES.Idcaja.ToString();
                Properties.Settings.Default.serie = VG_SERIE();
                Properties.Settings.Default.tipo_cambio = OBJVARIABLES.tipo_cambio;
                Properties.Settings.Default.punto_venta = VG_ID_PUNTOVENTA();
                Properties.Settings.Default.id_empleado = OBJVARIABLES.id_empleado;
                Properties.Settings.Default.nomempleado = OBJVARIABLES.nombre_empleado;
                Properties.Settings.Default.Save();
                Properties.Settings.Default.Upgrade();
                OBJCAJA.id_caja = Properties.Settings.Default.id_caja;
                OBJCAJA.id_puntoventa = OBJVARIABLES.id_puntoventa;
                OBJCAJA.id_empleado = OBJVARIABLES.id_empleado;
                OBJCAJA.id_empresa = OBJVARIABLES.id_empresa;

                OBJCAJA.nombre_empleado = OBJVARIABLES.nombre_empleado;
                OBJCAJA.tipo_cambio = OBJVARIABLES.tipo_cambio;
                OBJCAJA.sede = OBJVARIABLES.sede;
                
                /*---VARIABLE id_sede GUARDA VALOR AUN DESPUES DE CERRAR LA APLICACION---*/
                Properties.Settings.Default.id_sede = OBJVARIABLES.sede;
                Properties.Settings.Default.Save();
                Properties.Settings.Default.Upgrade();
                Program.id_sede = OBJVARIABLES.sede;
                /*-----------------------------------------------------------------------*/
                /*----VARIABLE punto_venta GUARDA VALOR AUN DESPUES DE CERRAR LA APP-----*/
                Properties.Settings.Default.punto_venta = OBJVARIABLES.id_puntoventa;
                Properties.Settings.Default.Save();
                Properties.Settings.Default.Upgrade();
                /*-----------------------------------------------------------------------*/
                /*----VARIABLE id_empresa GUARDA VALOR AUN DESPUES DE CERRAR LA APP-----*/
                Properties.Settings.Default.id_empresa = OBJVARIABLES.id_empresa;
                Properties.Settings.Default.Save();
                Properties.Settings.Default.Upgrade();
                /*-----------------------------------------------------------------------*/
                /*----VARIABLE id_empresa GUARDA VALOR AUN DESPUES DE CERRAR LA APP-----*/
                Properties.Settings.Default.nomempleado = OBJVARIABLES.nombre_empleado;
                Properties.Settings.Default.Save();
                Properties.Settings.Default.Upgrade();
                /*-----------------------------------------------------------------------*/
                /*----------------SETEANDO  NOM_SEDE----------------------------------*/
                if (Properties.Settings.Default.id_sede == "001") { Properties.Settings.Default.nomsede = "TOBOGANES DE SANTA ANA"; }
                Properties.Settings.Default.Save();
                Properties.Settings.Default.Upgrade();
                if (Properties.Settings.Default.id_sede == "002") { Properties.Settings.Default.nomsede = "CLUB LAS LEÑAS"; }
                Properties.Settings.Default.Save();
                Properties.Settings.Default.Upgrade();
                if (Properties.Settings.Default.id_sede == "003") { Properties.Settings.Default.nomsede = "COMPLEJO TURISTICO DIONYS SAC"; }
                Properties.Settings.Default.Save();
                Properties.Settings.Default.Upgrade();
                if (Properties.Settings.Default.id_sede == "004") { Properties.Settings.Default.nomsede = "CENTRO COMERCIAL DIONYS"; }
                Properties.Settings.Default.Save();
                Properties.Settings.Default.Upgrade();
                if (Properties.Settings.Default.id_sede == "005") { Properties.Settings.Default.nomsede = "ASESOR"; }
                Properties.Settings.Default.Save();
                Properties.Settings.Default.Upgrade();
                /*-----------------------------------------------------------------------*/
                /*-----------------------------------------------------------------------*/
                /*----------------SETEANDO  NOM_EMPRESA----------------------------------*/
                if (Properties.Settings.Default.id_empresa == "001") { Properties.Settings.Default.nomempresa = "CENTRO DE RECREACIONES DIONYS SAC"; }
                Properties.Settings.Default.Save();
                Properties.Settings.Default.Upgrade();
                if (Properties.Settings.Default.id_empresa == "002") { Properties.Settings.Default.nomempresa = "HOSTAL DIONYS SAC"; }
                Properties.Settings.Default.Save();
                Properties.Settings.Default.Upgrade();
                if (Properties.Settings.Default.id_empresa == "003") { Properties.Settings.Default.nomempresa = "COMPLEJO TURISTICO DIONYS SAC"; }
                Properties.Settings.Default.Save();
                Properties.Settings.Default.Upgrade();
                if (Properties.Settings.Default.id_empresa == "004") { Properties.Settings.Default.nomempresa = "CENTRO COMERCIAL DIONYS"; }
                Properties.Settings.Default.Save();
                Properties.Settings.Default.Upgrade();
                if (Properties.Settings.Default.id_empresa == "005") { Properties.Settings.Default.nomempresa = "INTERCOMPANY & SEÑOR DE HUANCA"; }
                Properties.Settings.Default.Save();
                Properties.Settings.Default.Upgrade();
                /*-----------------------------------------------------------------------*/
                OBJCAJA.Show();
                this.Visible = false;




            }
            else
            {
                label7.Text = " !!! ERROR ... VUELVA A INGRESAR LOS DATOS";
            }
        }

        

        private void VALIDAR_TIPO_CAMBIO()
        {
            OBJVARIABLES.tipo_cambio = N_OBJVENTAS.CONSULTAR_TIPO_CAMBIO().Rows[0]["TIPO_CAMBIO"].ToString();
        }



        private void VALIDAR_ASIGNAR_CAJA()
        {
            E_OBJ_MANTCAJA.ID_CAJA = string.Empty;
            E_OBJ_MANTCAJA.SALDO_INICIAL = 0.00;

            E_OBJ_MANTCAJA.ID_EMPLEADO = OBJVARIABLES.id_empleado;
            E_OBJ_MANTCAJA.ID_PUNTOVENTA = OBJVARIABLES.id_puntoventa;
            E_OBJ_MANTCAJA.OBSERVACION = string.Empty;

            E_OBJ_MANTCAJA.OPCION = 3; //OPCION 3 ES PARA VALIDAR LOS DATOS
            DataTable DT = new DataTable();
            DT = N_OBJVENTAS.MANTENIMIENTO_CAJA(E_OBJ_MANTCAJA);

            if (DT.Rows.Count != 0) //SI ES DIFERENTE DE 0 ES PORQUE EL USUARIO  ID_USUARIO Y EL PUNTO DE VENTA ID_PUNTOVENTA TIENE CAJA APERTURADA
            {
                OBJVARIABLES.Idcaja = DT.Rows[0]["ID_CAJA"].ToString();
                
            }


        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
