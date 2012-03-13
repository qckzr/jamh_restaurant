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
    /// Interaction logic for ModificarProducto.xaml
    /// </summary>
    public partial class ModificarProducto : Page
    {

        int idProducto;
        
        public ModificarProducto()
        {
            InitializeComponent();
            llenarListBoxProductos();
            iniciarValores();

        }

        private void b_cerrarAdmin_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }


        private void lb_Producto_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            DataRow dr = Logica.getInstance().consultarProducto(lb_Producto.SelectedItem.ToString()).Rows[0];
            idProducto = Convert.ToInt32(dr[0].ToString());
            l_tipo.Content = dr[2].ToString();
            l_cantidad.Content = dr[3].ToString();
        }

        private void llenarListBoxProductos()
        {
            DataTable dt = Logica.getInstance().getDb().consultar("select nombre from productos order by nombre");
            foreach (DataRow dr in dt.Rows)
            {
                lb_Producto.Items.Add(dr[0].ToString());

            }
        }

        private void button1_Click_1(object sender, RoutedEventArgs e)
        {
            String tipo;
            if (comboBox1.SelectedIndex == 0)
                tipo = "";
            else if (comboBox1.SelectedIndex == 1)
                tipo = "ALIMENTICIO";
            else tipo = "PAPELERA";
            Logica.getInstance().modificarProducto(idProducto, tb_producto.Text, tipo,tb_cantidad.Text);
            MessageBox.Show("El producto " + lb_Producto.SelectedItem.ToString() + " ha sido modificado");
            this.NavigationService.Navigate(new AdministrarProductos());
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
