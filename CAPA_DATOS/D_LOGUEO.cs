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

        SqlConnection con = new SqlConnection("Server=JOHNNYCASA;User ID=DESARROLLOTI2;Password=DESARROLLOTI;Database=DBDIONYS");

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

    }
}
