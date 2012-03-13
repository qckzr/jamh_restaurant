using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data;
using Logica = InventarioHilel.Controlador.Logica;

namespace InventarioHilel.Vista
{
    /// <summary>
    /// Interaction logic for EliminarProducto.xaml
    /// </summary>
    public partial class EliminarProducto : Page
    {
        public EliminarProducto()
        {
            InitializeComponent();
            llenarListBoxProductos();
            iniciarValores();


        }

        private void b_cerrarAdmin_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void llenarListBoxProductos()
        {
            DataTable dt = Logica.getInstance().getDb().consultar("select nombre from productos order by nombre");
            foreach (DataRow dr in dt.Rows)
            {
                lb_Producto.Items.Add(dr[0].ToString());

            }
        }

        private void lb_Producto_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataRow dr = Logica.getInstance().consultarProducto(lb_Producto.SelectedItem.ToString()).Rows[0];
                l_nombreProducto.Content=dr[1].ToString();
                l_tipo.Content=dr[2].ToString();
                l_cantidad.Content=dr[3].ToString();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Logica.getInstance().eliminarProducto(lb_Producto.SelectedItem.ToString());
            MessageBox.Show("Se ha eliminado el producto "+lb_Producto.SelectedItem.ToString());
            this.NavigationService.Navigate(new EliminarProducto());
        }

        private void iniciarValores()
        {
            labelTipoUsuario.Content = Logica.getInstance().Usuario.Nick;
            if (Logica.getInstance().Usuario.Admin == true)

                image1.Source = new BitmapImage(new Uri("/InventarioHilel;component/Images/lock-icon.png", UriKind.RelativeOrAbsolute));
            else
                image1.Source = new BitmapImage(new Uri("/InventarioHilel;component/Images/User-yellow-icon.png", UriKind.RelativeOrAbsolute));

        }
    }
}
