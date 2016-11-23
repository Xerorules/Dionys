using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

using System.Data.SqlClient;
using System.Data;
using System.Data.Sql;
using CAPA_ENTIDAD;

namespace CAPA_DATOS
{
    public class D_LOGUEO
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["sql"].ConnectionString);




        // VALIDACION DE USUARIOS CON BASE DE DATOS
        // ==========================================

        public DataTable VALIDAR_USUARIO(string USUARIO, string CONTRASENA, string ID_SEDE)
        {
            SqlCommand cmd = new SqlCommand("SP_VALIDAR_LOGIN", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@DNI_USUARIO", USUARIO);
            cmd.Parameters.AddWithValue("@CONTRASENA", CONTRASENA);
            cmd.Parameters.AddWithValue("@ID_SEDE", ID_SEDE);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }

        public DataTable LISTAR_EMPRESA()
        {
            SqlDataAdapter da = new SqlDataAdapter("SP_LISTAR_EMPRESA", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable LISTAR_SEDE(string ID_EMPRESA)
        {
            SqlCommand cmd = new SqlCommand("SP_LISTAR_SEDE", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID_EMPRESA", ID_EMPRESA);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }

        public DataTable PUNTO_VENTA(string ID_SEDE)
        {
            SqlCommand cmd = new SqlCommand("LISTAR_PUNTOVENTA", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID_SEDE", ID_SEDE);
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            da.Fill(dt);


            return dt;
        }

        public DataTable CONSULTAR_VISTA_EMPRESA(String ID_EMPRESA)
        {
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = @"SELECT ID_EMPRESA,DESCRIPCION,RUC ,TELEFONO_1,TELEFONO_2,DIRECCION,EMAIL,WEB_SITE,
		                        ESTADO,UBIDST,UBIPAI,UBIDEP,UBIDEN,UBIPRV,UBIPRN,UBIDSN  FROM V_EMPRESA WHERE ID_EMPRESA='" + ID_EMPRESA + "'";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;

            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            SqlDataAdapter data = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            data.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable CONSULTAR_VISTA_SEDE(String ID_SEDE)
        {
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = @"SELECT ID_SEDE, DESCRIPCION, DIRECCION, 
                                TELEFONO_1, TELEFONO_2, CONTACTO, ESTADO, ID_EMPRESA, UBIDST, UBIDSN, UBIDEN,
                                UBIPRN  FROM V_SEDE WHERE ID_SEDE='" + ID_SEDE + "'";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;

            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            SqlDataAdapter data = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            data.Fill(dt);
            con.Close();
            return dt;
        }



    }
}
