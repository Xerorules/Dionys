using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using System.Data;
using System.Data.Sql;
using CAPA_ENTIDAD;
using CAPA_DATOS;

namespace CAPA_NEGOCIO
{
    public class N_VENTA
    {
        D_VENTA OBJTIPO_BIEN = new D_VENTA();

        public DataTable TIPO_BIEN()
        {
            return OBJTIPO_BIEN.TIPO_BIEN();
        }
        public DataTable FILTRAR_BIEN(E_VENTA OBJ_VARBIEN)
        {
            return OBJTIPO_BIEN.FILTRAR_BIEN(OBJ_VARBIEN);
        }
        public DataTable BIEN_X_CLASE(E_VENTA OBJ_VARBIEN)
        {
            return OBJTIPO_BIEN.BIEN_X_CLASE(OBJ_VARBIEN);
        }
        public DataTable FILTRAR_BIEN_XCODIGO_XDESCRIPCION(E_VENTA OBJ_BUSCARBIEN)
        {
            return OBJTIPO_BIEN.FILTRAR_BIEN_XCODIGO_XDESCRIPCION(OBJ_BUSCARBIEN);
        }
        public DataTable MANTENIMIENTO_CLIENTE(E_MANT_CLIENTE OBJ_MANTCLIENTE)
        {
            return OBJTIPO_BIEN.MANTENIMIENTO_CLIENTE(OBJ_MANTCLIENTE);
        }
        public DataTable LISTAR_CLIENTES(string TIPOCLIENTE)
        {
            return OBJTIPO_BIEN.LISTAR_CLIENTES(TIPOCLIENTE);
        }
        public DataTable FILTRAR_CLIENTE(E_MANT_CLIENTE OBJFILTRO_CLIENTE)
        {
            return OBJTIPO_BIEN.FILTRAR_CLIENTE(OBJFILTRO_CLIENTE);
        }
        public DataTable LISTAR_PROVINCIA(string dep)
        {
            return OBJTIPO_BIEN.LISTAR_PROVINCIA(dep);
        }
        public DataTable LISTAR_DISTRITO(string dis)
        {
            return OBJTIPO_BIEN.LISTAR_DISTRITO(dis);
        }
        public DataTable LISTAR_DEPARTAMENTO()
        {
            return OBJTIPO_BIEN.LISTAR_DEPARTAMENTO();
        }
        public void MANTENIMIENTO_VENTA(E_VENTA_Y_DETALLE OBJ_VENTA)
        {
            OBJTIPO_BIEN.MANTENIMIENTO_VENTA(OBJ_VENTA);
        }
        public void MANTENIMIENTO_VENTADETALLE(E_VENTA_Y_DETALLE OBJ_VENTADETALLE)
        {
            OBJTIPO_BIEN.MANTENIMIENTO_VENTADETALLE(OBJ_VENTADETALLE);
        }
        /* CONSULTA A TRAVEZ DE UNA VISTA */
        public DataTable CAPTURAR_TABLA_VENTA(string ID_VENTA, string ID_SEDE)
        {
            return OBJTIPO_BIEN.CAPTURAR_TABLA_VENTA(ID_VENTA, ID_SEDE);
        }
        public DataTable CAPTURAR_TABLA_VENTADETALLE(string ID_VENTA)
        {
            return OBJTIPO_BIEN.CAPTURAR_TABLA_VENTADETALLE(ID_VENTA);
        }
        /* FIN*/

        /* PROCEDIMIENTO PARA LA REIMPRESION Y ANULACION DE VENTAS */
        public DataTable LISTADO_VENTAS_ACTIVAS_ANULADAS(string SERIE, string SEDE, string VER, string OPCION_BUSQUEDA, string DATO, string IDCAJA)
        {
            return OBJTIPO_BIEN.LISTADO_VENTAS_ACTIVAS_ANULADAS(SERIE, SEDE, VER, OPCION_BUSQUEDA, DATO, IDCAJA);

        }
        public void ELIMINAR_VENTA(string ID_VENTA)
        {
            OBJTIPO_BIEN.ELIMINAR_VENTA(ID_VENTA);
        }
        public DataTable LISTADO_VENTAS_RANGO_FECHA(string SERIE, string SEDE, string VER, string FECHA_INI, string FECHA_FIN)
        {
            return OBJTIPO_BIEN.LISTADO_VENTAS_RANGO_FECHA(SERIE, SEDE, VER, FECHA_INI, FECHA_FIN);
        }
        public void SPOOL_ETIQUETERA(string ID_SPOOL, string DATA, string ACCION)
        {
            OBJTIPO_BIEN.SPOOL_ETIQUETERA(ID_SPOOL, DATA, ACCION);
        }

        public void MANTENIMIENTO_BIEN(string ID_BIEN, double PRECIO_BIEN)
        {
            OBJTIPO_BIEN.MANTENIMIENTO_BIEN(ID_BIEN, PRECIO_BIEN);
        }

        public DataTable REPORTE_BIENES_AGRUPADOS(string SERIE, string SEDE, string FECHA_INI, string FECHA_FIN, string NOMBRE_CLASE)
        {
            return OBJTIPO_BIEN.REPORTE_BIENES_AGRUPADOS(SERIE, SEDE, FECHA_INI, FECHA_FIN, NOMBRE_CLASE);
        }

        /* PROCEDIMIENTOS PARA LAS PANTALLAS COCINA */
        public DataTable LISTA_PEDIDOS(string ID_SEDE)
        {
            return OBJTIPO_BIEN.LISTA_PEDIDOS(ID_SEDE);
        }
        public DataTable LISTA_PEDIDOS_DETALLE(string ID_PEDIDO)
        {
            return OBJTIPO_BIEN.LISTA_PEDIDOS_DETALLE(ID_PEDIDO);
        }
        public void ACTUALIZAR_FECHA_ATENCION(string ID_PEDIDO)
        {
            OBJTIPO_BIEN.ACTUALIZAR_FECHA_ATENCION(ID_PEDIDO);
        }
        /* ======================================== */
        public void ACTUALIZA_FECHA_ESTADO_PEDIDO(string ID_PEDIDO, string ID_BIEN, int ITEM, string ESTADO)
        {
            OBJTIPO_BIEN.ACTUALIZA_FECHA_ESTADO_PEDIDO(ID_PEDIDO, ID_BIEN, ITEM, ESTADO);
        }


        public DataTable LISTAR_FILTRAR_EMPLEADOS(string OPCION_FILTRO, string DATO)
        {
            return OBJTIPO_BIEN.LISTAR_FILTRAR_EMPLEADOS(OPCION_FILTRO, DATO);
        }

        public DataTable LISTAR_CARGOS()
        {
            return OBJTIPO_BIEN.LISTAR_CARGOS();
        }

        public DataTable LISTAR_AREAS()
        {
            return OBJTIPO_BIEN.LISTAR_AREAS();
        }

        public DataTable LISTAR_SEDE()
        {
            return OBJTIPO_BIEN.LISTAR_SEDE();
        }
        public void MANTENIMIENTO_EMPLEADOS(E_MANT_EMPLEADOS E_OBJVENTA)
        {
            OBJTIPO_BIEN.MANTENIMIENTO_EMPLEADOS(E_OBJVENTA);
        }
        public DataTable OBTENER_DEPAR_PROV_POR_DIST(string DISTRITO)
        {
            return OBJTIPO_BIEN.OBTENER_DEPAR_PROV_POR_DIST(DISTRITO);
        }

        public DataTable MANTENIMIENTO_CAJA(E_MANTENIMIENTO_CAJA OBJMANT_CAJA)
        {
            return OBJTIPO_BIEN.MANTENIMIENTO_CAJA(OBJMANT_CAJA);
        }

        public DataTable CONSULTAR_CAJA(string ID_CAJA)
        {
            return OBJTIPO_BIEN.CONSULTAR_CAJA(ID_CAJA);
        }
        public void CAJA_KARDEX_MANTENIMIENTO(E_CAJA_KARDEX OBJMANT_CAJA_KARDEX)
        {
            OBJTIPO_BIEN.CAJA_KARDEX_MANTENIMIENTO(OBJMANT_CAJA_KARDEX);
        }
        public DataTable CONSULTAR_TIPO_CAMBIO()
        {
            return OBJTIPO_BIEN.CONSULTAR_TIPO_CAMBIO();
        }
        public DataTable LISTAR_TIPO_MOVIMIENTO()
        {
            return OBJTIPO_BIEN.LISTAR_TIPO_MOVIMIENTO();
        }
        public DataTable LISTAR_TIPO_PAGO()
        {
            return OBJTIPO_BIEN.LISTAR_TIPO_PAGO();
        }
        public DataTable FILTRAR_CAJA_KARDEX(string ID_MOVIMIENTO, string ID_CAJA, string DESCRIPCION, string TIPO_PAGO, string ID_TIPOMOV, int OPCION, string VER)
        {
            return OBJTIPO_BIEN.FILTRAR_CAJA_KARDEX(ID_MOVIMIENTO, ID_CAJA, DESCRIPCION, TIPO_PAGO, ID_TIPOMOV, OPCION, VER);
        }
        public DataTable LISTA_REGISTRO_CAJA_KARDEX(string ID_MOVIMIENTO)
        {
            return OBJTIPO_BIEN.LISTA_REGISTRO_CAJA_KARDEX(ID_MOVIMIENTO);
        }
        public DataTable CONSULTA_IMPRESION_CAJA_KARDEX(string ID_CAJA)
        {
            return OBJTIPO_BIEN.CONSULTA_IMPRESION_CAJA_KARDEX(ID_CAJA);
        }
        public DataTable OBTENER_ID_COMPVENT_CAJAKARDEX(string ID_COMPVENT, string TIPOMOV)
        {
            return OBJTIPO_BIEN.OBTENER_ID_COMPVENT_CAJAKARDEX(ID_COMPVENT, TIPOMOV);
        }
        public DataTable FUNCION_CONV_NUMEROS_A_LETRAS(double pNUMERO)
        {
            return OBJTIPO_BIEN.FUNCION_CONV_NUMEROS_A_LETRAS(pNUMERO);
        }
        public DataTable FILTROS_LIBRO_CAJA(string pCONDICION, string ID_SEDE)
        {
            return OBJTIPO_BIEN.FILTROS_LIBRO_CAJA(pCONDICION, ID_SEDE);
        }
        public DataTable LISTAR_EMPLEADO(string pSEDE)
        {
            return OBJTIPO_BIEN.LISTAR_EMPLEADO(pSEDE);
        }
        public DataTable LISTA_PUNTOVENTA(string pSEDE)
        {
            return OBJTIPO_BIEN.LISTA_PUNTOVENTA(pSEDE);
        }
        public DataTable LISTA_TIPOMOVIMIENTO()
        {
            return OBJTIPO_BIEN.LISTA_TIPOMOVIMIENTO();
        }
        public DataTable LISTA_TIPOPAGO()
        {
            return OBJTIPO_BIEN.LISTA_TIPOPAGO();
        }
        public DataTable VALIDAR_USUARIO_ADMIN_SEDE(string pSEDE)
        {
            return OBJTIPO_BIEN.VALIDAR_USUARIO_ADMIN_SEDE(pSEDE);
        }
        public void MANTENIMIENTO_PEDIDO(E_PEDIDO E_OBJPEDIDO)
        {
            OBJTIPO_BIEN.MANTENIMIENTO_PEDIDO(E_OBJPEDIDO);
        }
        public DataTable CONSULTAR_NUMERO_CORRELATIVO_VENTA(string ID_SEDE, string SERIE, string TIPODOC)
        {
            return OBJTIPO_BIEN.CONSULTAR_NUMERO_CORRELATIVO_VENTA(ID_SEDE, SERIE, TIPODOC);
        }
        public void MANTENIMIENTO_VENTA_DETALLADA(E_VENTA_DETALLADA OBJ_VENTADETALLADA)
        {
            OBJTIPO_BIEN.MANTENIMIENTO_VENTA_DETALLADA(OBJ_VENTADETALLADA);
        }
        public void VENTADETALLE_DETALLADA(E_VENTA_DETALLADA OBJ_VENTADETALLADA)
        {
            OBJTIPO_BIEN.VENTADETALLE_DETALLADA(OBJ_VENTADETALLADA);
        }
        public DataTable OBTENER_ULTIMO_REGISTRO_VENTA(string ID_SEDE, string SERIE)
        {
            return OBJTIPO_BIEN.OBTENER_ULTIMO_REGISTRO_VENTA(ID_SEDE, SERIE);
        }
        public DataTable FILTROS_VENTAS(string pCONDICION)
        {
            return OBJTIPO_BIEN.FILTROS_VENTAS(pCONDICION);
        }
        public DataTable CAPTURAR_TABLA_COMPRA(string ID_COMPRA)
        {
            return OBJTIPO_BIEN.CAPTURAR_TABLA_COMPRA(ID_COMPRA);
        }
        public DataTable CAPTURAR_TABLA_COMPRADETALLE(string ID_COMPRA)
        {
            return OBJTIPO_BIEN.CAPTURAR_TABLA_COMPRADETALLE(ID_COMPRA);
        }
        public void MANTENIMIENTO_COMPRA(E_COMPRAS OBJ_COMPRA)
        {
            OBJTIPO_BIEN.MANTENIMIENTO_COMPRA(OBJ_COMPRA);
        }
        public void MANTENIMIENTO_COMPRADETALLE(E_COMPRAS OBJ_COMPRADETALLE)
        {
            OBJTIPO_BIEN.MANTENIMIENTO_COMPRADETALLE(OBJ_COMPRADETALLE);
        }
        public void ANULAR_COMPRA(string ID_COMPRA)
        {
            OBJTIPO_BIEN.ANULAR_COMPRA(ID_COMPRA);
        }
        public DataTable OBTENER_ULTIMO_REGISTRO_COMPRA(string ID_SEDE)
        {
            return OBJTIPO_BIEN.OBTENER_ULTIMO_REGISTRO_COMPRA(ID_SEDE);
        }
        public DataTable FILTROS_COMPRAS(string pCONDICION)
        {
            return OBJTIPO_BIEN.FILTROS_COMPRAS(pCONDICION);
        }
        public DataTable VALIDAR_REGCOMPRA(string SERIE, string NUMERO)
        {
            return OBJTIPO_BIEN.VALIDAR_REGCOMPRA(SERIE, NUMERO);
        }

        public DataTable GENERAR_DETALLE_CUENTAS_XCOBRAR(string ID_COMPVENT)
        {
            return OBJTIPO_BIEN.GENERAR_DETALLE_CUENTAS_XCOBRAR(ID_COMPVENT);
        }
        public DataTable GENERAR_DETALLE_CUENTAS_XPAGAR(string ID_COMPVENT)
        {
            return OBJTIPO_BIEN.GENERAR_DETALLE_CUENTAS_XPAGAR(ID_COMPVENT);
        }
        public DataTable CONSULTA_ULTIMO_CLIENTE(string ID_CLIENTE)
        {
            return OBJTIPO_BIEN.CONSULTA_ULTIMO_CLIENTE(ID_CLIENTE);
        }
        public DataTable CONSULTA_LISTA_CLIENTES(string CONDICION)
        {
            return OBJTIPO_BIEN.CONSULTA_LISTA_CLIENTES(CONDICION);
        }
        public DataSet REPORTE_GENERAR_FACTURA_BOLETA(string IDVENTA)
        {
            return OBJTIPO_BIEN.REPORTE_GENERAR_FACTURA_BOLETA(IDVENTA);
        }
        public DataSet REPORTE_GENERAR_RECIBO_EGRESO_INGRESO(string IDMOV, string IDEMP)
        {
            return OBJTIPO_BIEN.REPORTE_GENERAR_RECIBO_EGRESO_INGRESO(IDMOV, IDEMP);
        }
        public DataSet REPORTE_RESUMEN_CAJA_LIBROCAJA(string ID_EMPRESA, string ID_CAJA)//, string FECHA_INI, string FECHA_FIN)
        {
            return OBJTIPO_BIEN.REPORTE_RESUMEN_CAJA_LIBROCAJA(ID_EMPRESA, ID_CAJA);//, FECHA_INI, FECHA_FIN);
        }
        public DataTable ANULAR_CLIENTE(string ID_CLIENTE)
        {
            return OBJTIPO_BIEN.ANULAR_CLIENTE(ID_CLIENTE); ;
        }
        public DataTable MOVIMIENTOS_XDIA_CAJAS(string EMPLEADO, string ID_CAJA, double TIPO_CAMBIO, string OPCION, double SALDOFINAL, string ID_SEDE)
        {
            return OBJTIPO_BIEN.MOVIMIENTOS_XDIA_CAJAS(EMPLEADO, ID_CAJA, TIPO_CAMBIO, OPCION, SALDOFINAL, ID_SEDE);
        }
        public DataTable OBTENER_SALDO_CAJA(string ID_PUNTOVENTA)
        {
            return OBJTIPO_BIEN.OBTENER_SALDO_CAJA(ID_PUNTOVENTA);
        }
        public DataTable MANTENIMIENTO_PROVEEDOR(E_MANT_PROVEEDOR OBJ_MANTPROVEEDOR)
        {
            return OBJTIPO_BIEN.MANTENIMIENTO_PROVEEDOR(OBJ_MANTPROVEEDOR);
        }
        public DataTable CONSULTA_LISTA_PROVEEDORES(string CONDICION)
        {
            return OBJTIPO_BIEN.CONSULTA_LISTA_PROVEEDORES(CONDICION);
        }
        public DataTable CONSULTA_ULTIMO_PROVEEDOR(string ID_PROVEEDOR)
        {
            return OBJTIPO_BIEN.CONSULTA_ULTIMO_PROVEEDOR(ID_PROVEEDOR);
        }
        public DataTable ANULAR_PROVEEDOR(string ID_PROVEEDOR)
        {
            return OBJTIPO_BIEN.ANULAR_PROVEEDOR(ID_PROVEEDOR);
        }
        public DataTable VALIDAR_RESTRICCIONES_ABRIR_CAJA(string PUNTOVENTA)
        {
            return OBJTIPO_BIEN.VALIDAR_RESTRICCIONES_ABRIR_CAJA(PUNTOVENTA);
        }
        public DataTable VALIDAR_EXISTENCIA_CAJAADMINISTRACION(string ID_ADMIN)
        {
            return OBJTIPO_BIEN.VALIDAR_EXISTENCIA_CAJAADMINISTRACION(ID_ADMIN);
        }
        public DataSet REPORTE_LIQUIDACION_CAJA(string ID_EMPRESA, string ID_CAJA)
        {
            return OBJTIPO_BIEN.REPORTE_LIQUIDACION_CAJA(ID_EMPRESA, ID_CAJA);
        }
        public DataSet REPORTE_DOCVTA_RECIBOS(string ID_COMPVTA, string ID_EMPRESA)
        {
            return OBJTIPO_BIEN.REPORTE_DOCVTA_RECIBOS(ID_COMPVTA, ID_EMPRESA);
        }

        public DataSet REPORTE_LIQUIDACIONES_GALERIA(string ID_EMPRESA, string ID_CAJA) //ESTA FUNCION ES PARA GENERAR LA LIQUIDACION DE GALERIA - CON ESTO LLAMAMOS A TODOS LOS DATOS
        {
            return OBJTIPO_BIEN.REPORTE_LIQUIDACIONES_GALERIA(ID_EMPRESA, ID_CAJA);
        }

        public DataTable LISTA_PROPIETARIOS(String GALERIA)
        {
            return OBJTIPO_BIEN.LISTA_PROPIETARIOS(GALERIA);
        }

        public DataTable LISTA_TIENDASxPROPIETARIO(String GALERIA_OPC, String PROPIETARIO)
        {
            return OBJTIPO_BIEN.LISTA_TIENDASxPROPIETARIO(GALERIA_OPC, PROPIETARIO);
        }

        public DataTable DATOS_GALERIA(String GALERIA, String PROPIETARIO, String TIENDA, String ESTADO)
        {
            return OBJTIPO_BIEN.DATOS_GALERIA(GALERIA, PROPIETARIO, TIENDA, ESTADO);
        }
        public DataTable ESTADOS_GALERIA(String GALERIA, String PROPIETARIO, String TIENDA)
        {
            return OBJTIPO_BIEN.ESTADOS_GALERIA(GALERIA, PROPIETARIO, TIENDA);
        }
        public void ACTUALIZAR_ESTADOGALERIA(string ESTADO, int CODIGO)   //aqui validamos la existencia de una caja administracion para guardar lo saldos de caja caja al cerrar dicha caja
        {
            OBJTIPO_BIEN.ACTUALIZAR_ESTADOGALERIA(ESTADO, CODIGO);
        }
        public void ACTUALIZAR_MODIFICACIONES_CONTROL_GALERIA(string ID_VENTA, string OPCION)
        {
            OBJTIPO_BIEN.ACTUALIZAR_MODIFICACIONES_CONTROL_GALERIA(ID_VENTA, OPCION);
        }
    }
}
