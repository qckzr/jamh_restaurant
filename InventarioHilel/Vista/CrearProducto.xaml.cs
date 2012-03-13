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
using Logica = InventarioHilel.Controlador.Logica;

namespace InventarioHilel.Vista
{
    /// <summary>
    /// Interaction logic for CrearProducto.xaml
    /// </summary>
    public partial class CrearProducto : Page
    {
        public CrearProducto()
        {
            InitializeComponent();
            iniciarValores();
           
        }

        private void b_cerrarAdmin_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            //NEGRO ARREGLA ESTO QUE NO SE PORQUE EL COMBOBOX NO LE PUEDO HACER .selecteditem.tostring() o.o
            String tipo = "";
            if (comboBox1.SelectedIndex == 0)
                tipo = "ALIMENTICIO";
            else tipo = "PAPELERA";
            Logica.getInstance().crearProducto(tb_producto.Text, tipo, Convert.ToInt32(textBox1.Text));
            MessageBox.Show("Se ha agregado un nuevo producto en el sistema");
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
