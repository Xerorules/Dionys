using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using System.Data;
using System.Data.Sql;
using CAPA_ENTIDAD;
using System.Configuration;

namespace CAPA_DATOS
{
    public class D_VENTA
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["sql"].ConnectionString);
        public DataTable TIPO_BIEN()
        {
            SqlCommand cmd = new SqlCommand("SP_LISTAR_TIPOBIEN", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable FILTRAR_BIEN(E_VENTA OBJ_VARBIEN)
        {
            SqlCommand cmd = new SqlCommand("SP_FILTRAR_BIEN", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID_TIPOBIEN", OBJ_VARBIEN.ID_TIPOBIEN);
            cmd.Parameters.AddWithValue("@BIEN", OBJ_VARBIEN.BIEN);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable BIEN_X_CLASE(E_VENTA OBJ_VARBIEN)
        {
            SqlCommand cmd = new SqlCommand("SP_FILTRAR_BIENES", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CLASE", OBJ_VARBIEN.ID_CLASE);
            cmd.Parameters.AddWithValue("@ID_EMPRESA", OBJ_VARBIEN.ID_EMPRESA);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable FILTRAR_BIEN_XCODIGO_XDESCRIPCION(E_VENTA OBJ_BUSCARBIEN)
        {
            SqlCommand cmd = new SqlCommand("SP_FILTRAR_BIEN_XCODIGO_XDESCRIPCION", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@OPCION_CLASE", OBJ_BUSCARBIEN.OPCION_CLASE_BUSCAR);
            cmd.Parameters.AddWithValue("@ID_BIEN", OBJ_BUSCARBIEN.ID_BIEN_BUSCAR);
            cmd.Parameters.AddWithValue("@DESCRIPCION", OBJ_BUSCARBIEN.DESCRIPCION_BUSCAR);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable MANTENIMIENTO_CLIENTE(E_MANT_CLIENTE OBJ_MANTCLIENTE)
        {
            SqlCommand cmd = new SqlCommand("SP_CLIENTE", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID_CLIENTE", OBJ_MANTCLIENTE.ID_CLIENTE);
            cmd.Parameters.AddWithValue("@TIPO_CLIENTE", OBJ_MANTCLIENTE.TIPO_CLIENTE);
            cmd.Parameters.AddWithValue("@DESCRIPCION", OBJ_MANTCLIENTE.DESCRIPCION);
            cmd.Parameters.AddWithValue("@RUC_DNI", OBJ_MANTCLIENTE.RUC_DNI);
            cmd.Parameters.AddWithValue("@DIRECCION", OBJ_MANTCLIENTE.DIRECCION);
            cmd.Parameters.AddWithValue("@TELEFONO_1", OBJ_MANTCLIENTE.TELEFONO_1);
            cmd.Parameters.AddWithValue("@TELEFONO_2", OBJ_MANTCLIENTE.TELEFONO_2);
            cmd.Parameters.AddWithValue("@MOVIL", OBJ_MANTCLIENTE.MOVIL);
            cmd.Parameters.AddWithValue("@FECHA_NAC", OBJ_MANTCLIENTE.FECHA_NAC);
            cmd.Parameters.AddWithValue("@EMAIL", OBJ_MANTCLIENTE.EMAIL);
            cmd.Parameters.AddWithValue("@WEB_SITE", OBJ_MANTCLIENTE.WEB_SITE);
            cmd.Parameters.AddWithValue("@ESTADO", OBJ_MANTCLIENTE.ESTADO);
            cmd.Parameters.AddWithValue("@UBIDST", OBJ_MANTCLIENTE.UBIDST);
            cmd.Parameters.AddWithValue("@ACCION", OBJ_MANTCLIENTE.ACCION);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable FILTRAR_CLIENTE(E_MANT_CLIENTE OBJFILTRO_CLIENTE)
        {
            SqlCommand cmd = new SqlCommand("SP_FILTRAR_CLIENTE", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@TIPO_CLIENTE", OBJFILTRO_CLIENTE.FILTRO_TIPOCLIENTE);
            cmd.Parameters.AddWithValue("@TIPO_BUSQUEDA", OBJFILTRO_CLIENTE.FILTRO_TIPOBUSQUEDA);
            cmd.Parameters.AddWithValue("@DATO", OBJFILTRO_CLIENTE.FILTRO_DATO);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }


        public DataTable LISTAR_CLIENTES(string TIPOCLIENTE)
        {
            SqlCommand cmd = new SqlCommand("SP_LISTAR_CLIENTE", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@TIPO_CLIENTE", TIPOCLIENTE);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable LISTAR_PROVINCIA(string dep)
        {
            SqlCommand cmd = new SqlCommand("SP_LISTARPROVINCIA", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@dep", dep);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable LISTAR_DISTRITO(string dis)
        {
            SqlCommand cmd = new SqlCommand("SP_LISTARDISTRITO", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@distrito", dis);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable LISTAR_DEPARTAMENTO()
        {
            SqlDataAdapter da = new SqlDataAdapter("SP_LISTARDEPARTAMENTO", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }


        public void MANTENIMIENTO_VENTA(E_VENTA_Y_DETALLE OBJ_VENTA)
        {

            SqlCommand cmd = new SqlCommand("SP_VENTA", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@ID_VENTA", SqlDbType.Char, 10);
            cmd.Parameters["@ID_VENTA"].Direction = ParameterDirection.Output;
            cmd.Parameters.AddWithValue("@SERIE", OBJ_VENTA.SERIE);
            cmd.Parameters.AddWithValue("@TIPO_DOC", OBJ_VENTA.TIPO_DOC);
            cmd.Parameters.AddWithValue("@MONEDA", OBJ_VENTA.MONEDA);
            cmd.Parameters.AddWithValue("@VALOR_VENTA", OBJ_VENTA.VALOR_VENTA);
            cmd.Parameters.AddWithValue("@IGV", OBJ_VENTA.IGV);
            cmd.Parameters.AddWithValue("@TOTAL", OBJ_VENTA.TOTAL);
            cmd.Parameters.AddWithValue("@SALDO", OBJ_VENTA.SALDO);
            cmd.Parameters.AddWithValue("@ID_SEDE", OBJ_VENTA.ID_SEDE);
            cmd.Parameters.AddWithValue("@ID_PEDIDO", DBNull.Value);
            if (OBJ_VENTA.ID_CLIENTE != string.Empty)
            {
                cmd.Parameters.AddWithValue("@ID_CLIENTE", OBJ_VENTA.ID_CLIENTE);
            }
            else
            {
                cmd.Parameters.AddWithValue("@ID_CLIENTE", DBNull.Value);
            }
            cmd.Parameters.AddWithValue("@CLIENTE", OBJ_VENTA.CLIENTE);
            cmd.Parameters.AddWithValue("@ACCION", OBJ_VENTA.ACCION);

            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();

            cmd.ExecuteNonQuery();
            con.Close();

            OBJ_VENTA.ID_VENTA = cmd.Parameters["@ID_VENTA"].Value.ToString();


        }

        public void MANTENIMIENTO_VENTADETALLE(E_VENTA_Y_DETALLE OBJ_VENTADETALLE)
        {
            SqlCommand cmd = new SqlCommand("SP_INSERT_VENTA_DETALLE", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID_VENTA", OBJ_VENTADETALLE.ID_VENTA);
            cmd.Parameters.AddWithValue("@ID_BIEN", OBJ_VENTADETALLE.ID_BIEN);
            cmd.Parameters.AddWithValue("@ITEM", OBJ_VENTADETALLE.ITEM);
            cmd.Parameters.AddWithValue("@CANTIDAD", OBJ_VENTADETALLE.CANTIDAD);
            cmd.Parameters.AddWithValue("@PRECIO", OBJ_VENTADETALLE.PRECIO);
            cmd.Parameters.AddWithValue("@IMPORTE", OBJ_VENTADETALLE.IMPORTE);
            cmd.Parameters.AddWithValue("@SALDO_CANTIDAD", OBJ_VENTADETALLE.SALDO_CANTIDAD);
            cmd.Parameters.AddWithValue("@GRABA_PEDIDO_DETALLE", OBJ_VENTADETALLE.GRABA_PEDIDO_DETALLE);

            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public DataTable CAPTURAR_TABLA_VENTA(string ID_VENTA, string ID_SEDE)
        {
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "SELECT * FROM V_TABLA_VENTAS WHERE V_ID_VENTA = '" + ID_VENTA + "' AND V_ID_SEDE='" + ID_SEDE + "'";
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

        public DataTable CAPTURAR_TABLA_VENTADETALLE(string ID_VENTA)
        {
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "SELECT * FROM V_TABLA_VENTADETALLE WHERE VD_ID_VENTA = '" + ID_VENTA + "'";
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
        public DataTable LISTADO_VENTAS_ACTIVAS_ANULADAS(string SERIE, string SEDE, string VER, string OPCION_BUSQUEDA, string DATO, string IDCAJA)
        {
            SqlCommand cmd = new SqlCommand("SP_VENTAS_ACTIVAS_ANULADAS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@SERIE", SERIE);
            cmd.Parameters.AddWithValue("@ID_SEDE", SEDE);
            cmd.Parameters.AddWithValue("@VER", VER);
            cmd.Parameters.AddWithValue("@OPCION_BUSQUEDA", OPCION_BUSQUEDA);
            cmd.Parameters.AddWithValue("@DATO", DATO);
            cmd.Parameters.AddWithValue("@IDCAJA", IDCAJA);
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();

            cmd.ExecuteNonQuery();
            SqlDataAdapter data = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            data.Fill(dt);
            con.Close();
            return dt;
        }

        public void ELIMINAR_VENTA(string ID_VENTA)
        {
            SqlCommand cmd = new SqlCommand("ELIMINAR_VENTA", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID_VENTA", ID_VENTA);
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public DataTable LISTADO_VENTAS_RANGO_FECHA(string SERIE, string SEDE, string VER, string FECHA_INI, string FECHA_FIN)
        {
            SqlCommand cmd = new SqlCommand("SP_FILTRO_VENTAS_RANGOFECHA", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@SERIE", SERIE);
            cmd.Parameters.AddWithValue("@ID_SEDE", SEDE);
            cmd.Parameters.AddWithValue("@VER", VER);
            cmd.Parameters.AddWithValue("@FECHA_INI", FECHA_INI);
            cmd.Parameters.AddWithValue("@FECHA_FIN", FECHA_FIN);
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            cmd.ExecuteNonQuery();
            SqlDataAdapter data = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            data.Fill(dt);
            con.Close();
            return dt;
        }

        public void SPOOL_ETIQUETERA(string ID_SPOOL, string DATA, string ACCION)
        {
            SqlCommand cmd = new SqlCommand("SP_SPOOL_ETIQUETERA", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID_SPOOL", ID_SPOOL);
            cmd.Parameters.AddWithValue("@DATO", DATA);
            cmd.Parameters.AddWithValue("@ACCION", ACCION);
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void MANTENIMIENTO_BIEN(string ID_BIEN, double PRECIO_BIEN)
        {
            SqlCommand cmd = new SqlCommand("SP_ACTUALIZAR_BIEN", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID_BIEN", ID_BIEN);
            cmd.Parameters.AddWithValue("@PRECIO", PRECIO_BIEN);
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

        }

        public DataTable REPORTE_BIENES_AGRUPADOS(string SERIE, string SEDE, string FECHA_INI, string FECHA_FIN, string NOMBRE_CLASE)
        {
            SqlCommand cmd = new SqlCommand("SP_REPORTE_BIENES", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@SERIE", SERIE);
            cmd.Parameters.AddWithValue("@ID_SEDE", SEDE);
            cmd.Parameters.AddWithValue("@FECHA_INI", FECHA_INI);
            cmd.Parameters.AddWithValue("@FECHA_FIN", FECHA_FIN);
            cmd.Parameters.AddWithValue("@NOMBRE_CLASE", NOMBRE_CLASE);
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            cmd.ExecuteNonQuery();
            SqlDataAdapter data = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            data.Fill(dt);
            con.Close();
            return dt;
        }


        /* PROCEDIMIENTOS PARA LA PANTALLA COCINA */
        public DataTable LISTA_PEDIDOS(string ID_SEDE)
        {
            SqlCommand cmd = new SqlCommand("SP_LISTA_PEDIDO", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID_SEDE", ID_SEDE);
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable LISTA_PEDIDOS_DETALLE(string ID_PEDIDO)
        {
            SqlCommand cmd = new SqlCommand("SP_PEDIDO_DETALLE", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID_PEDIDO", ID_PEDIDO);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public void ACTUALIZAR_FECHA_ATENCION(string ID_PEDIDO)
        {
            SqlCommand cmd = new SqlCommand("SP_ACTUALIZA_FECHA_ATENCION_PEDIDO", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID_PEDIDO", ID_PEDIDO);
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void ACTUALIZA_FECHA_ESTADO_PEDIDO(string ID_PEDIDO, string ID_BIEN, int ITEM, string ESTADO)
        {
            SqlCommand cmd = new SqlCommand("ACTUALIZA_FECHA_ESTADO_PEDIDO", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID_PEDIDO", ID_PEDIDO);
            cmd.Parameters.AddWithValue("@ID_BIEN", ID_BIEN);
            cmd.Parameters.AddWithValue("@ITEM", ITEM);
            cmd.Parameters.AddWithValue("@ESTADO", ESTADO);
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        /* ======================================== */

        public DataTable LISTAR_FILTRAR_EMPLEADOS(string OPCION_FILTRO, string DATO)
        {
            SqlCommand cmd = new SqlCommand("SP_LISTAR_EMPLEADOS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@OPCION_FILTRO", OPCION_FILTRO);
            cmd.Parameters.AddWithValue("@DATO", DATO);
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            cmd.ExecuteNonQuery();
            SqlDataAdapter data = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            data.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable LISTAR_CARGOS()
        {
            SqlDataAdapter da = new SqlDataAdapter("SP_LISTAR_CARGO", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable LISTAR_AREAS()
        {
            SqlDataAdapter da = new SqlDataAdapter("SP_LISTAR_AREA", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable LISTAR_SEDE()
        {
            SqlDataAdapter da = new SqlDataAdapter("SP_LISTAR_SEDE", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public void MANTENIMIENTO_EMPLEADOS(E_MANT_EMPLEADOS E_OBJEMPLEADO)
        {
            SqlCommand cmd = new SqlCommand("SP_EMPLEADOS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID_EMPLEADO", E_OBJEMPLEADO.ID_EMPLEADO);
            cmd.Parameters.AddWithValue("@NOMBRE", E_OBJEMPLEADO.NOMBRE);
            cmd.Parameters.AddWithValue("@APELLIDOS", E_OBJEMPLEADO.APELLIDOS);
            cmd.Parameters.AddWithValue("@DNI_USUARIO", E_OBJEMPLEADO.DNI_USUARIO);
            cmd.Parameters.AddWithValue("@CONTRASEÑA", E_OBJEMPLEADO.CONTRASENA);
            cmd.Parameters.AddWithValue("@DIRECCION", E_OBJEMPLEADO.DIRECCION);
            cmd.Parameters.AddWithValue("@FECHA_NAC", E_OBJEMPLEADO.FECHA_NAC);
            cmd.Parameters.AddWithValue("@TELEFONO", E_OBJEMPLEADO.TELEFONO);
            cmd.Parameters.AddWithValue("@MOVIL", E_OBJEMPLEADO.MOVIL);
            cmd.Parameters.AddWithValue("@EMAIL", E_OBJEMPLEADO.EMAIL);
            cmd.Parameters.AddWithValue("@ESTADO", E_OBJEMPLEADO.ESTADO);
            cmd.Parameters.AddWithValue("@UBIDST", E_OBJEMPLEADO.UBIDST);
            cmd.Parameters.AddWithValue("@ID_CARGO", E_OBJEMPLEADO.ID_CARGO);
            cmd.Parameters.AddWithValue("@ID_SEDE", E_OBJEMPLEADO.ID_SEDE);
            cmd.Parameters.AddWithValue("@ID_AREA", E_OBJEMPLEADO.ID_AREA);
            cmd.Parameters.AddWithValue("@ACCION", E_OBJEMPLEADO.ACCION);
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public DataTable OBTENER_DEPAR_PROV_POR_DIST(string DISTRITO)
        {
            SqlCommand cmd = new SqlCommand("SP_OBTENER_DEPAR_PROV", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@DISTRITO", DISTRITO);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable MANTENIMIENTO_CAJA(E_MANTENIMIENTO_CAJA OBJMANT_CAJA)
        {
            string var;
            SqlCommand cmd = new SqlCommand("SP_CAJA", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@ID_CAJA", SqlDbType.Char, 8);
            cmd.Parameters["@ID_CAJA"].Direction = ParameterDirection.InputOutput;
            cmd.Parameters["@ID_CAJA"].Value = OBJMANT_CAJA.ID_CAJA;
            var = cmd.Parameters["@ID_CAJA"].Value.ToString();
            cmd.Parameters.AddWithValue("@SALDO_INICIAL", OBJMANT_CAJA.SALDO_INICIAL);
            cmd.Parameters.AddWithValue("@ID_EMPLEADO", OBJMANT_CAJA.ID_EMPLEADO);
            cmd.Parameters.AddWithValue("@ID_PUNTOVENTA", OBJMANT_CAJA.ID_PUNTOVENTA);
            cmd.Parameters.AddWithValue("@OBSERVACION", OBJMANT_CAJA.OBSERVACION);
            cmd.Parameters.AddWithValue("@OPCION", OBJMANT_CAJA.OPCION);

            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            OBJMANT_CAJA.ID_CAJA = cmd.Parameters["@ID_CAJA"].Value.ToString();
            
            con.Close();


            return dt;


        }





        public void CAJA_KARDEX_MANTENIMIENTO(E_CAJA_KARDEX OBJMANT_CAJA_KARDEX)
        {
            SqlCommand cmd = new SqlCommand("SP_CAJA_KARDEX", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID_MOVIMIENTO", OBJMANT_CAJA_KARDEX.ID_MOVIMIENTO);
            cmd.Parameters.AddWithValue("@DESCRIPCION", OBJMANT_CAJA_KARDEX.DESCRIPCION);
            if (OBJMANT_CAJA_KARDEX.ID_COMPVENT == string.Empty)
            {
                cmd.Parameters.AddWithValue("@ID_COMPVENT", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@ID_COMPVENT", OBJMANT_CAJA_KARDEX.ID_COMPVENT);
            }
            cmd.Parameters.AddWithValue("@ID_TIPOPAGO", OBJMANT_CAJA_KARDEX.ID_TIPOPAGO);
            cmd.Parameters.AddWithValue("@ID_TIPOMOV", OBJMANT_CAJA_KARDEX.ID_TIPOMOV);
            cmd.Parameters.AddWithValue("@IMPORTE", OBJMANT_CAJA_KARDEX.IMPORTE);
            cmd.Parameters.AddWithValue("@MONEDA", OBJMANT_CAJA_KARDEX.MONEDA);
            cmd.Parameters.AddWithValue("@TIPO_CAMBIO", OBJMANT_CAJA_KARDEX.TIPO_CAMBIO);
            cmd.Parameters.AddWithValue("@AMORTIZADO", OBJMANT_CAJA_KARDEX.AMORTIZADO);
            cmd.Parameters.AddWithValue("@ID_CAJA", OBJMANT_CAJA_KARDEX.ID_CAJA);
            cmd.Parameters.AddWithValue("@IMPORTE_CAJA", OBJMANT_CAJA_KARDEX.IMPORTE_CAJA);
            cmd.Parameters.AddWithValue("@OPCION", OBJMANT_CAJA_KARDEX.OPCION);

            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

        }

        public DataTable CONSULTAR_CAJA(string ID_CAJA)
        {
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "SELECT ID_CAJA,FECHA_INICIAL,SALDO_INICIAL,SALDO_FINAL,FECHA_CIERRE,ID_EMPLEADO,ID_PUNTOVENTA,OBSERVACION FROM CAJA WHERE ID_CAJA = '" + ID_CAJA + "'";
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
        public DataTable CONSULTAR_TIPO_CAMBIO()
        {
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "SELECT TOP 1 FECHA, TIPO_CAMBIO FROM TIPO_CAMBIO ORDER BY FECHA DESC ";
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
        public DataTable LISTAR_TIPO_MOVIMIENTO()
        {
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "SELECT ID_TIPOMOV,DESCRIPCION  FROM TIPO_MOVIMIENTO";
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
        public DataTable LISTAR_TIPO_PAGO()
        {
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "SELECT ID_TIPOPAGO,DESCRIPCION FROM TIPO_PAGO";
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

        public DataTable FILTRAR_CAJA_KARDEX(string ID_MOVIMIENTO, string ID_CAJA, string DESCRIPCION, string TIPO_PAGO, string ID_TIPOMOV, int OPCION, string VER)
        {
            SqlCommand cmd = new SqlCommand("SP_FILTRAR_CAJA_KARDEX", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID_MOVIMIENTO", ID_MOVIMIENTO);
            cmd.Parameters.AddWithValue("@ID_CAJA", ID_CAJA);
            cmd.Parameters.AddWithValue("@DESCRIPCION", DESCRIPCION);
            cmd.Parameters.AddWithValue("@ID_TIPOPAGO", TIPO_PAGO);
            cmd.Parameters.AddWithValue("@ID_TIPOMOV", ID_TIPOMOV);
            cmd.Parameters.AddWithValue("@OPCION", OPCION);
            cmd.Parameters.AddWithValue("@VER", VER);
            //cmd.Parameters.AddWithValue("@OPCION_USUARIO",OPCION_USUARIO);
            //if(FECHA != null)
            //{
            //    cmd.Parameters.AddWithValue("@FECHA",FECHA);
            //}
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable LISTA_REGISTRO_CAJA_KARDEX(string ID_MOVIMIENTO)
        {
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = @"SELECT ID_MOVIMIENTO,DESCRIPCION,ID_COMPVENT,ID_TIPOPAGO,TP_DESCRIPCION,ID_TIPOMOV,TM_DESCRIPCION, 
             IMPORTE,MONEDA,TIPO_CAMBIO,AMORTIZADO,ID_CAJA,FECHA_INICIAL,FECHA_CIERRE,SALDO_INICIAL,SALDO_FINAL,ID_EMPLEADO,EMPLEADO,
				ID_PUNTOVENTA,PV_DESCRIPCION,PV_ID_SEDE,S_DESCRIPCION,IMPORTE_CAJA,FECHA_ANULADO,FECHA FROM V_CAJA_KADEX WHERE ID_MOVIMIENTO = '" + ID_MOVIMIENTO + "'";
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
        public DataTable CONSULTA_IMPRESION_CAJA_KARDEX(string ID_CAJA)
        {
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = @"SELECT ID_MOVIMIENTO,DESCRIPCION,(SELECT SERIE +'-'+ NUMERO FROM VENTA WHERE ID_VENTA = ID_COMPVENT) AS NUMERO,ID_COMPVENT,
	                           ID_TIPOPAGO,TP_DESCRIPCION,ID_TIPOMOV,TM_DESCRIPCION,IMPORTE,MONEDA,TIPO_CAMBIO,AMORTIZADO,ID_CAJA,
	                           FECHA_INICIAL,FECHA_CIERRE,SALDO_INICIAL,SALDO_FINAL,ID_EMPLEADO,EMPLEADO,ID_PUNTOVENTA,PV_DESCRIPCION,
	                           PV_ID_SEDE,S_DESCRIPCION,IMPORTE_CAJA,FECHA_ANULADO,FECHA FROM V_CAJA_KADEX WHERE ID_CAJA = '" + ID_CAJA + "' ORDER BY NUMERO ASC";

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

        public DataTable OBTENER_ID_COMPVENT_CAJAKARDEX(string ID_COMPVENT, string TIPOMOV)
        {
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "SELECT ID_MOVIMIENTO , FECHA_ANULADO FROM CAJA_KARDEX WHERE ID_COMPVENT='" + ID_COMPVENT + "' AND SUBSTRING(ID_TIPOMOV,1,1)='" + TIPOMOV + "'";
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

        public DataTable FUNCION_CONV_NUMEROS_A_LETRAS(double pNUMERO)
        {
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "SELECT dbo.Num2Let(" + pNUMERO.ToString() + ")";
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
        public DataTable FILTROS_LIBRO_CAJA(string pCONDICION, string ID_SEDE)
        {
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = @"SELECT ID_MOVIMIENTO,DESCRIPCION,ID_COMPVENT,ID_TIPOPAGO,TP_DESCRIPCION,ID_TIPOMOV,TM_DESCRIPCION,
	                            IMPORTE,MONEDA,TIPO_CAMBIO,AMORTIZADO,ID_CAJA,FECHA_INICIAL,FECHA_CIERRE ,SALDO_INICIAL,
                                SALDO_FINAL,ID_EMPLEADO ,EMPLEADO,ID_PUNTOVENTA,PV_DESCRIPCION ,PV_ID_SEDE,S_DESCRIPCION,
                                IMPORTE_CAJA,FECHA_ANULADO,FECHA FROM V_CAJA_KADEX WHERE PV_ID_SEDE='" + ID_SEDE + "' AND " + pCONDICION;
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
        public DataTable LISTAR_EMPLEADO(string pSEDE)
        {
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = @"SELECT ' 000000' AS ID_EMPLEADO,' TODOS ' AS EMPLEADO UNION SELECT ID_EMPLEADO,APELLIDOS+' '+NOMBRE AS EMPLEADO FROM EMPLEADO WHERE ID_SEDE = '" + pSEDE + "'";
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
        public DataTable LISTA_PUNTOVENTA(string pSEDE)
        {
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = @"SELECT ' 000' AS ID_PUNTOVENTA,' TODOS ' AS DESCRIPCION UNION SELECT ID_PUNTOVENTA,DESCRIPCION FROM PUNTO_VENTA WHERE ID_SEDE = '" + pSEDE + "'";
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

        public DataTable LISTA_TIPOMOVIMIENTO()
        {
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = @"SELECT ' 000' AS ID_TIPOMOV,' TODOS ' AS DESCRIPCION UNION SELECT ID_TIPOMOV,DESCRIPCION FROM TIPO_MOVIMIENTO";
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
        public DataTable LISTA_TIPOPAGO()
        {
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = @"SELECT ' 0000' AS ID_TIPOPAGO,' TODOS ' AS DESCRIPCION UNION SELECT ID_TIPOPAGO,DESCRIPCION FROM TIPO_PAGO";
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
        public DataTable VALIDAR_USUARIO_ADMIN_SEDE(string pSEDE)
        {
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = @"SELECT DNI_USUARIO, ID_SEDE,MOVIL  FROM EMPLEADO WHERE ID_CARGO = '003' AND ID_SEDE = '" + pSEDE + "'";
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

        public void MANTENIMIENTO_PEDIDO(E_PEDIDO E_OBJPEDIDO)
        {
            SqlCommand cmd = new SqlCommand("SP_PEDIDO", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID_PEDIDO", E_OBJPEDIDO.ID_PEDIDO);
            cmd.Parameters.AddWithValue("@ID_EMPLEADO", E_OBJPEDIDO.ID_EMPLEADO);
            cmd.Parameters.AddWithValue("@CLIENTE", E_OBJPEDIDO.CLIENTE);
            cmd.Parameters.AddWithValue("@VALOR_VENTA", E_OBJPEDIDO.VALOR_VENTA);
            cmd.Parameters.AddWithValue("@IGV", E_OBJPEDIDO.IGV);
            cmd.Parameters.AddWithValue("@TOTAL", E_OBJPEDIDO.TOTAL);
            cmd.Parameters.AddWithValue("@MONEDA", E_OBJPEDIDO.MONEDA);
            cmd.Parameters.AddWithValue("@OBSERVACION", E_OBJPEDIDO.OBSERVACION);
            cmd.Parameters.AddWithValue("@FECHA_ANULADO", E_OBJPEDIDO.FECHA_ANULADO);
            cmd.Parameters.AddWithValue("@FECHA_ATENDIDO", E_OBJPEDIDO.FECHA_ATENDIDO);
            cmd.Parameters.AddWithValue("@ID_SEDE", E_OBJPEDIDO.ID_SEDE);
            cmd.Parameters.AddWithValue("@ACCION", E_OBJPEDIDO.ACCION);

            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public DataTable CONSULTAR_NUMERO_CORRELATIVO_VENTA(string ID_SEDE, string SERIE, string TIPODOC)
        {
            SqlCommand cmd = new SqlCommand("SP_OBTENER_CORRELATIVO_VENTA", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID_SEDE", ID_SEDE);
            cmd.Parameters.AddWithValue("@SERIE", SERIE);
            cmd.Parameters.AddWithValue("@TIPO_DOC", TIPODOC);
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

        public void MANTENIMIENTO_VENTA_DETALLADA(E_VENTA_DETALLADA OBJ_VENTADETALLADA)
        {
            SqlCommand cmd = new SqlCommand("SP_MANT_VENTA_DETALLADA", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@ID_VENTA", SqlDbType.Char, 10);
            cmd.Parameters["@ID_VENTA"].Direction = ParameterDirection.Output;
            cmd.Parameters.AddWithValue("@FECHA", OBJ_VENTADETALLADA.FECHA);
            cmd.Parameters.AddWithValue("@SERIE", OBJ_VENTADETALLADA.SERIE);
            cmd.Parameters.AddWithValue("@TIPO_DOC", OBJ_VENTADETALLADA.TIPO_DOC);
            cmd.Parameters.AddWithValue("@MONEDA", OBJ_VENTADETALLADA.MONEDA);
            cmd.Parameters.AddWithValue("@VALOR_VENTA", OBJ_VENTADETALLADA.VALOR_VENTA);
            cmd.Parameters.AddWithValue("@IGV", OBJ_VENTADETALLADA.IGV);
            cmd.Parameters.AddWithValue("@TOTAL", OBJ_VENTADETALLADA.TOTAL);
            cmd.Parameters.AddWithValue("@SALDO", OBJ_VENTADETALLADA.SALDO);
            cmd.Parameters.AddWithValue("@ID_SEDE", OBJ_VENTADETALLADA.ID_SEDE);
            cmd.Parameters.AddWithValue("@ID_PEDIDO", DBNull.Value);
            if (OBJ_VENTADETALLADA.ID_CLIENTE != string.Empty)
            {
                cmd.Parameters.AddWithValue("@ID_CLIENTE", OBJ_VENTADETALLADA.ID_CLIENTE);
            }
            else
            {
                cmd.Parameters.AddWithValue("@ID_CLIENTE", DBNull.Value);
            }
            cmd.Parameters.AddWithValue("@CLIENTE", OBJ_VENTADETALLADA.CLIENTE);
            cmd.Parameters.AddWithValue("@ACCION", OBJ_VENTADETALLADA.ACCION);

            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();

            cmd.ExecuteNonQuery();
            con.Close();

            OBJ_VENTADETALLADA.ID_VENTA = cmd.Parameters["@ID_VENTA"].Value.ToString();


        }

        public void VENTADETALLE_DETALLADA(E_VENTA_DETALLADA OBJ_VENTADETALLADA)
        {
            SqlCommand cmd = new SqlCommand("SP_MANT_VENTA_DETALLE_DETALLADA", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID_VENTA", OBJ_VENTADETALLADA.ID_VENTA);
            cmd.Parameters.AddWithValue("@ID_BIEN", OBJ_VENTADETALLADA.ID_BIEN);
            cmd.Parameters.AddWithValue("@ITEM", OBJ_VENTADETALLADA.ITEM);
            cmd.Parameters.AddWithValue("@CANTIDAD", OBJ_VENTADETALLADA.CANTIDAD);
            cmd.Parameters.AddWithValue("@PRECIO", OBJ_VENTADETALLADA.PRECIO);
            cmd.Parameters.AddWithValue("@IMPORTE", OBJ_VENTADETALLADA.IMPORTE);
            cmd.Parameters.AddWithValue("@SALDO_CANTIDAD", OBJ_VENTADETALLADA.SALDO_CANTIDAD);

            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        //CON ESTO OBTENGO LOS DATOS DE MI ULTIMO REGISTRO DE VENTA SEGUN SEA UN TIPO DE DOCUMENTO, POR LA SERIE, POR LA SEDE Y POR EL TIPO DE DOCUMENTO
        public DataTable OBTENER_ULTIMO_REGISTRO_VENTA(string ID_SEDE, string SERIE)
        {
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = @"SELECT TOP 1 V_ID_VENTA FROM V_TABLA_VENTAS WHERE V_ID_SEDE = '" + ID_SEDE + "' AND V_SERIE = '" + SERIE + "' AND V_FECHA_ANULADO IS NULL ORDER BY V_FECHA DESC ";
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

        public DataTable LISTA_TIPODOCUMENTO()
        {
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = @"SELECT ' 000' AS ID_TIPOMOV,' TODOS ' AS DESCRIPCION UNION SELECT ID_TIPOMOV,DESCRIPCION FROM TIPO_MOVIMIENTO";
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


        public DataTable FILTROS_VENTAS(string pCONDICION)
        {
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = @"SELECT V_ID_VENTA,V_SERIE,V_NUMERO,V_TIPO_DOC,V_FECHA,V_MONEDA,V_VALOR_VENTA,
                                V_IGV, V_TOTAL,V_SALDO,V_FECHA_ANULADO,V_CLIENTE,V_ID_CLIENTE,C_DESCRIPCION,
                                C_RUC_DNI,C_DIRECCION,C_TELEFONO_1 FROM V_TABLA_VENTAS WHERE " + pCONDICION;
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



        public DataTable CAPTURAR_TABLA_COMPRA(string ID_COMPRA)
        {
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "SELECT * FROM V_TABLA_COMPRAS WHERE C_ID_COMPRA = '" + ID_COMPRA + "'";
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

        public DataTable CAPTURAR_TABLA_COMPRADETALLE(string ID_COMPRA)
        {
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "SELECT * FROM V_TABLA_COMPRADETALLE WHERE CD_ID_COMPRA = '" + ID_COMPRA + "'";
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

        public void MANTENIMIENTO_COMPRA(E_COMPRAS OBJ_COMPRA)
        {

            SqlCommand cmd = new SqlCommand("SP_COMPRA", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@ID_COMPRA", SqlDbType.Char, 10);
            cmd.Parameters["@ID_COMPRA"].Direction = ParameterDirection.Output;
            cmd.Parameters.AddWithValue("@SERIE", OBJ_COMPRA.SERIE);
            cmd.Parameters.AddWithValue("@NUMERO", OBJ_COMPRA.NUMERO);
            cmd.Parameters.AddWithValue("@TIPO_DOC", OBJ_COMPRA.TIPO_DOC);
            cmd.Parameters.AddWithValue("@MONEDA", OBJ_COMPRA.MONEDA);
            cmd.Parameters.AddWithValue("@VALOR_VENTA", OBJ_COMPRA.VALOR_VENTA);
            cmd.Parameters.AddWithValue("@IGV", OBJ_COMPRA.IGV);
            cmd.Parameters.AddWithValue("@TOTAL", OBJ_COMPRA.TOTAL);
            cmd.Parameters.AddWithValue("@SALDO", OBJ_COMPRA.SALDO);
            cmd.Parameters.AddWithValue("@ID_SEDE", OBJ_COMPRA.ID_SEDE);
            cmd.Parameters.AddWithValue("@ID_PROVEEDOR", OBJ_COMPRA.ID_PROVEEDOR);
            cmd.Parameters.AddWithValue("@OBSERVACIONES", OBJ_COMPRA.OBSERVACIONES);
            cmd.Parameters.AddWithValue("@ACCION", OBJ_COMPRA.ACCION);

            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();

            cmd.ExecuteNonQuery();
            con.Close();

            OBJ_COMPRA.ID_COMPRA = cmd.Parameters["@ID_COMPRA"].Value.ToString();


        }

        public void MANTENIMIENTO_COMPRADETALLE(E_COMPRAS OBJ_COMPRADETALLE)
        {
            SqlCommand cmd = new SqlCommand("SP_INSERT_COMPRA_DETALLE", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID_COMPRA", OBJ_COMPRADETALLE.ID_COMPRA);
            cmd.Parameters.AddWithValue("@ID_BIEN", OBJ_COMPRADETALLE.ID_BIEN);
            cmd.Parameters.AddWithValue("@ITEM", OBJ_COMPRADETALLE.ITEM);
            cmd.Parameters.AddWithValue("@CANTIDAD", OBJ_COMPRADETALLE.CANTIDAD);
            cmd.Parameters.AddWithValue("@PRECIO", OBJ_COMPRADETALLE.PRECIO);
            cmd.Parameters.AddWithValue("@IMPORTE", OBJ_COMPRADETALLE.IMPORTE);
            cmd.Parameters.AddWithValue("@SALDO_CANTIDAD", OBJ_COMPRADETALLE.SALDO_CANTIDAD);

            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void ANULAR_COMPRA(string ID_COMPRA)
        {
            SqlCommand cmd = new SqlCommand("ANULAR_COMPRA", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID_COMPRA", ID_COMPRA);
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public DataTable OBTENER_ULTIMO_REGISTRO_COMPRA(string ID_SEDE)
        {
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = @"SELECT TOP 1 C_ID_COMPRA FROM V_TABLA_COMPRAS WHERE C_ID_SEDE = '" + ID_SEDE + "' AND C_FECHA_ANULADO IS NULL ORDER BY C_FECHA DESC ";
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

        public DataTable FILTROS_COMPRAS(string pCONDICION)
        {
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = @"SELECT C_ID_COMPRA,C_SERIE,C_NUMERO,C_TIPO_DOC,C_FECHA,C_MONEDA,C_VALOR_VENTA,
                                C_IGV, C_TOTAL,C_SALDO,C_FECHA_ANULADO,C_OBSERVACIONES,C_ID_PROVEEDOR,P_DESCRIPCION,
                                P_RUC_DNI,P_DIRECCION,P_TELEFONO_1 FROM V_TABLA_COMPRAS WHERE " + pCONDICION;
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


        public DataTable VALIDAR_REGCOMPRA(string SERIE, string NUMERO)
        {
            SqlCommand cmd = new SqlCommand("SP_VALIDAR_REGCOMPRA", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@SERIE", SERIE);
            cmd.Parameters.AddWithValue("@NUMERO", NUMERO);
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

        public DataTable GENERAR_DETALLE_CUENTAS_XCOBRAR(string ID_COMPVENT)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT ID_MOVIMIENTO,FECHA,DESCRIPCION,TP_DESCRIPCION,TM_DESCRIPCION,MONEDA,IMPORTE,TIPO_CAMBIO,AMORTIZADO,IMPORTE_CAJA,ID_CAJA,FECHA_INICIAL,FECHA_CIERRE,SALDO_INICIAL,SALDO_FINAL,EMPLEADO,PV_DESCRIPCION,S_DESCRIPCION,FECHA_ANULADO,ID_COMPVENT FROM V_CAJA_KADEX WHERE TM_DESCRIPCION='INGRESO POR VENTA' AND ID_COMPVENT = '" + ID_COMPVENT + "'";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable GENERAR_DETALLE_CUENTAS_XPAGAR(string ID_COMPVENT)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT ID_MOVIMIENTO,FECHA,DESCRIPCION,TP_DESCRIPCION,TM_DESCRIPCION,MONEDA,IMPORTE,TIPO_CAMBIO,AMORTIZADO,IMPORTE_CAJA,ID_CAJA,FECHA_INICIAL,FECHA_CIERRE,SALDO_INICIAL,SALDO_FINAL,EMPLEADO,PV_DESCRIPCION,S_DESCRIPCION,FECHA_ANULADO,ID_COMPVENT FROM V_CAJA_KADEX WHERE TM_DESCRIPCION='EGRESO POR COMPRA' AND ID_COMPVENT = '" + ID_COMPVENT + "'";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable CONSULTA_ULTIMO_CLIENTE(string ID_CLIENTE)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT * FROM V_CLIENTE WHERE ID_CLIENTE = '" + ID_CLIENTE + "' AND ESTADO = 1";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable CONSULTA_LISTA_CLIENTES(string CONDICION)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT  ID_CLIENTE,TIPO_CLIENTE,DESCRIPCION,RUC_DNI,DIRECCION,EMAIL,ESTADO,UBIDST FROM V_CLIENTE WHERE " + CONDICION + " ORDER BY ID_CLIENTE DESC";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
            
        }

        public DataSet REPORTE_GENERAR_FACTURA_BOLETA(string IDVENTA)
        {
            SqlCommand cmd = new SqlCommand("SP_REPORTE_GENERAR_FACTURA_BOLETA", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID_VENTCOMP", IDVENTA);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        public DataSet REPORTE_GENERAR_RECIBO_EGRESO_INGRESO(string IDMOV, string IDEMP)
        {
            SqlCommand cmd = new SqlCommand("SP_REPORTE_GENERAR_RECIBO_EGRESO_INGRESO", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@IDMOVIMIENTO", IDMOV);
            cmd.Parameters.AddWithValue("@IDEMPRESA", IDEMP);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        public DataSet REPORTE_RESUMEN_CAJA_LIBROCAJA(string ID_EMPRESA, string ID_CAJA) //, string FECHA_INI,string FECHA_FIN)
        {
            SqlCommand cmd = new SqlCommand("SP_REPORTE_RESUMEN_CAJA_LIBROCAJA", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@IDEMPRESA", ID_EMPRESA);
            cmd.Parameters.AddWithValue("@ID_CAJA", ID_CAJA);
            //cmd.Parameters.AddWithValue("@FECHA_INI", FECHA_INI);
            //cmd.Parameters.AddWithValue("@FECHA_FIN",FECHA_FIN);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        public DataTable ANULAR_CLIENTE(string ID_CLIENTE)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "UPDATE  CLIENTE SET ESTADO = 0 WHERE ID_CLIENTE =  '" + ID_CLIENTE + "'";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable MOVIMIENTOS_XDIA_CAJAS(string EMPLEADO, string ID_CAJA, double TIPO_CAMBIO, string OPCION, double SALDOFINAL, string ID_SEDE)
        {
            SqlCommand cmd = new SqlCommand("SP_PASAR_DATOS_CAJA_ADMINISTRACION", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@EMPLEADO", EMPLEADO);
            cmd.Parameters.AddWithValue("@ID_CAJA", ID_CAJA);
            cmd.Parameters.AddWithValue("@TIPO_CAMBIO", TIPO_CAMBIO);
            cmd.Parameters.AddWithValue("@OPCION", OPCION);
            cmd.Parameters.AddWithValue("@SALDOFINAL", SALDOFINAL);
            cmd.Parameters.AddWithValue("@ID_SEDE", ID_SEDE);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable OBTENER_SALDO_CAJA(string ID_PUNTOVENTA)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT TOP 1 SALDO_FINAL FROM CAJA WHERE ID_PUNTOVENTA = '" + ID_PUNTOVENTA + "' ORDER BY FECHA_CIERRE  DESC";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable MANTENIMIENTO_PROVEEDOR(E_MANT_PROVEEDOR OBJ_MANTPROVEEDOR)
        {
            SqlCommand cmd = new SqlCommand("SP_PROVEEDOR", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID_PROVEEDOR", OBJ_MANTPROVEEDOR.ID_PROVEEDOR);
            cmd.Parameters.AddWithValue("@TIPO_PROVEEDOR", OBJ_MANTPROVEEDOR.TIPO_PROVEEDOR);
            cmd.Parameters.AddWithValue("@ORIGEN_PROVEEDOR", OBJ_MANTPROVEEDOR.ORIGEN_PROVEEDOR);
            cmd.Parameters.AddWithValue("@DESCRIPCION", OBJ_MANTPROVEEDOR.DESCRIPCION);
            cmd.Parameters.AddWithValue("@RUC_DNI", OBJ_MANTPROVEEDOR.RUC_DNI);
            cmd.Parameters.AddWithValue("@DIRECCION", OBJ_MANTPROVEEDOR.DIRECCION);
            cmd.Parameters.AddWithValue("@TELEFONO_1", OBJ_MANTPROVEEDOR.TELEFONO_1);
            cmd.Parameters.AddWithValue("@TELEFONO_2", OBJ_MANTPROVEEDOR.TELEFONO_2);
            cmd.Parameters.AddWithValue("@MOVIL", OBJ_MANTPROVEEDOR.MOVIL);
            cmd.Parameters.AddWithValue("@FECHA_NAC", OBJ_MANTPROVEEDOR.FECHA_NAC);
            cmd.Parameters.AddWithValue("@EMAIL", OBJ_MANTPROVEEDOR.EMAIL);
            cmd.Parameters.AddWithValue("@WEB_SITE", OBJ_MANTPROVEEDOR.WEB_SITE);
            cmd.Parameters.AddWithValue("@ESTADO", OBJ_MANTPROVEEDOR.ESTADO);
            cmd.Parameters.AddWithValue("@UBIDST", OBJ_MANTPROVEEDOR.UBIDST);
            cmd.Parameters.AddWithValue("@ACCION", OBJ_MANTPROVEEDOR.ACCION);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable CONSULTA_LISTA_PROVEEDORES(string CONDICION)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT  * FROM V_PROVEEDOR WHERE " + CONDICION + " ORDER BY ID_PROVEEDOR DESC";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable CONSULTA_ULTIMO_PROVEEDOR(string ID_PROVEEDOR)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT * FROM V_PROVEEDOR WHERE ID_PROVEEDOR = '" + ID_PROVEEDOR + "' AND ESTADO = 1";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable ANULAR_PROVEEDOR(string ID_PROVEEDOR)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "UPDATE  PROVEEDOR SET ESTADO = 0 WHERE ID_PROVEEDOR =  '" + ID_PROVEEDOR + "'";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable VALIDAR_RESTRICCIONES_ABRIR_CAJA(string PUNTOVENTA)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT * FROM CAJA WHERE ID_PUNTOVENTA = '" + PUNTOVENTA + "' AND FECHA_CIERRE IS NULL";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable VALIDAR_EXISTENCIA_CAJAADMINISTRACION(string ID_ADMIN)   //aqui validamos la existencia de una caja administracion para guardar lo saldos de caja caja al cerrar dicha caja
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT * FROM CAJA WHERE ID_PUNTOVENTA = '" + ID_ADMIN + "' AND FECHA_CIERRE IS NULL";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataSet REPORTE_LIQUIDACION_CAJA(string ID_EMPRESA, string ID_CAJA)
        {
            SqlCommand cmd = new SqlCommand("SP_REPORTE_LIQUIDACION_X_CAJA", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@IDEMPRESA", ID_EMPRESA);
            cmd.Parameters.AddWithValue("@ID_CAJA", ID_CAJA);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        public DataSet REPORTE_LIQUIDACIONES_GALERIA(string ID_EMPRESA, string ID_CAJA) //ESTA FUNCION ES PARA GENERAR LA LIQUIDACION DE GALERIA - CON ESTO LLAMAMOS A TODOS LOS DATOS
        {
            SqlCommand cmd = new SqlCommand("SP_LIQUIDACIONES", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID_EMPRESA", ID_EMPRESA);
            cmd.Parameters.AddWithValue("@ID_CAJA", ID_CAJA);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        public DataSet REPORTE_DOCVTA_RECIBOS(string ID_COMPVTA, string ID_EMPRESA)
        {
            SqlCommand cmd = new SqlCommand("SP_REPORTE_DOCVTA_GALERIA", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID_COMPVTA", ID_COMPVTA);
            cmd.Parameters.AddWithValue("@ID_EMPRESA", ID_EMPRESA);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;

        }

        // =============================================================================  GALERIA ======================================================================================================================
        #region MODULO GALERIA

        public DataTable LISTA_PROPIETARIOS(String GALERIA)
        {
            SqlCommand cmd = new SqlCommand("LISTA_PROPIETARIOS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@GALERIA", GALERIA);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }

        public DataTable LISTA_TIENDASxPROPIETARIO(String GALERIA_OPC, String PROPIETARIO)
        {
            SqlCommand cmd = new SqlCommand("LISTA_TIENDASxPROPIETARIO", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@GALERIA_OPC", GALERIA_OPC);
            cmd.Parameters.AddWithValue("@PROPIETARIO", PROPIETARIO);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }

        public DataTable DATOS_GALERIA(String GALERIA, String PROPIETARIO, String TIENDA, String ESTADO)
        {
            SqlCommand cmd = new SqlCommand("SP_CONTROL_GALERIADATOS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@GALERIA", GALERIA);
            cmd.Parameters.AddWithValue("@TIENDA", TIENDA);
            cmd.Parameters.AddWithValue("@PROPIETARIO", PROPIETARIO);
            cmd.Parameters.AddWithValue("@ESTADO", ESTADO);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }
        public DataTable ESTADOS_GALERIA(String GALERIA, String PROPIETARIO, String TIENDA)
        {
            SqlCommand cmd = new SqlCommand("SP_CONTROL_GALERIAESTADOS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@GALERIA", GALERIA);
            cmd.Parameters.AddWithValue("@TIENDA", TIENDA);
            cmd.Parameters.AddWithValue("@PROPIETARIO", PROPIETARIO);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }

        public void ACTUALIZAR_ESTADOGALERIA(string ESTADO, int CODIGO)   //aqui validamos la existencia de una caja administracion para guardar lo saldos de caja caja al cerrar dicha caja
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "UPDATE CONTROL_TIENDASGALERIA SET CGESTADO = '" + ESTADO + "' WHERE CGCODIGO = " + CODIGO;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void ACTUALIZAR_MODIFICACIONES_CONTROL_GALERIA(string ID_VENTA, string OPCION)
        {
            SqlCommand cmd = new SqlCommand("SP_ACTUALIZAR_MODIFICACIONES_CONTROL_GALERIA", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID_VENTA", ID_VENTA);
            cmd.Parameters.AddWithValue("@OPCION", OPCION);
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }


    }
}
#endregion