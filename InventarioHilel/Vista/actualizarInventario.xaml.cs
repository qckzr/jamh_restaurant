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
    /// Interaction logic for actualizarInventario.xaml
    /// </summary>
    public partial class actualizarInventario : Window
    {
        public actualizarInventario()
        {
            InitializeComponent();
            WindowState = WindowState.Maximized;
            WindowStyle = WindowStyle.None;

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {


        }

        private void b_cerrarActualizacion_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void b_deducirInventario_Click(object sender, RoutedEventArgs e)
        {
            Window asd = new DeducirInventario();
            asd.Visibility = Visibility.Visible;
            this.Visibility = Visibility.Collapsed;
        }

        private void b_AgregarInventario_Click(object sender, RoutedEventArgs e)
        {
            Window asd = new AgregarInventario();
            asd.Visibility = Visibility.Visible;
            this.Visibility = Visibility.Collapsed;

        }
    }
}
