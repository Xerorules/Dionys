using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using CAPA_ENTIDAD;
using CAPA_NEGOCIO;

namespace WpfApplication1
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        #region OBJETOS
        N_LOGUEO OBJLOGUEO = new N_LOGUEO();
        E_LOGUEO OBJLOGUEOE = new E_LOGUEO();
        
        #endregion

        private void LISTAR_EMPRESA()
        {
            cboEmpresa.ItemsSource = OBJLOGUEO.LISTAR_EMPRESA().ToString();
            cboEmpresa.value = "ID_EMPRESA";
            cboEmpresa.DataTextField = "DESCRIPCION";
            cboEmpresa.DataBind();
        }
        private void LISTAR_SEDE(string ID_EMPRESA)
        {
            cboSEDE.DataSource = OBJLOGUEO.LISTAR_SEDE(ID_EMPRESA);
            cboSEDE.DataValueField = "ID_SEDE";
            cboSEDE.DataTextField = "DESCRIPCION";
            cboSEDE.DataBind();
        }
        private void LISTA_PUNTOVENTA(string ID_SEDE)
        {
            cboPUNTOVENTA.DataSource = OBJLOGUEO.PUNTO_VENTA(ID_SEDE);
            cboPUNTOVENTA.DataValueField = "PK_PUNTO_VENTA";
            cboPUNTOVENTA.DataTextField = "DESCRIPCION";
            cboPUNTOVENTA.DataBind();
        }

        private void comboBox2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void cboSede_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void cboPtoVenta_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
