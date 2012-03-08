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

namespace InventarioHilel.Vista
{
    /// <summary>
    /// Interaction logic for MenuUsuario.xaml
    /// </summary>
    public partial class MenuUsuario : Window
    {
        public MenuUsuario()
        {
            InitializeComponent();
              WindowState = WindowState.Maximized;
              WindowStyle = WindowStyle.None;

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }


        private void b_cerrarUsuario_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void b_ActualizarInventarioU_Click(object sender, RoutedEventArgs e)
        {
            Window asd = new actualizarInventario();
            asd.Visibility = Visibility.Visible;
            this.Visibility = Visibility.Collapsed;
        }

        private void b_alertasU_Click(object sender, RoutedEventArgs e)
        {
            Window asd = new Alertas();
            asd.Visibility = Visibility.Visible;
            this.Visibility = Visibility.Collapsed;
        }

        private void b_consultarInventarioU_Click(object sender, RoutedEventArgs e)
        {
            Window asd = new ConsultarInventario();
            asd.Visibility = Visibility.Visible;
            this.Visibility = Visibility.Collapsed;

        }
    }
}
