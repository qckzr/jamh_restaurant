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
    /// Interaction logic for MenuOpciones.xaml
    /// </summary>
    public partial class MenuOpciones : Window
    {
        public MenuOpciones()
        {
            InitializeComponent();
            WindowState = WindowState.Maximized;
            WindowStyle = WindowStyle.None;
        
        }

        private void button1_Click_1(object sender, RoutedEventArgs e)
        {
            
            this.Close();

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Window asd = new MenuUsuario();
            asd.Visibility = Visibility.Visible;
            this.Visibility = Visibility.Collapsed;
        }

        private void b_ActualizarInventario_Click(object sender, RoutedEventArgs e)
        {
            Window asd = new actualizarInventario();
            asd.Visibility = Visibility.Visible;
            this.Visibility = Visibility.Collapsed;
        }

        private void b_consultarInventario_Click(object sender, RoutedEventArgs e)
        {
            Window asd = new ConsultarInventario();
            asd.Visibility = Visibility.Visible;
            this.Visibility = Visibility.Collapsed;
        }

        private void b_AdministrarUsurios_Click(object sender, RoutedEventArgs e)
        {
            Window asd = new AdministrarUsuarios();
            asd.Visibility = Visibility.Visible;
            this.Visibility = Visibility.Collapsed;
        }

        private void b_AdministrarProductos_Click(object sender, RoutedEventArgs e)
        {
            Window asd = new AdministrarProductos();
            asd.Visibility = Visibility.Visible;
            this.Visibility = Visibility.Collapsed;
        }

        private void b_alertas_Click(object sender, RoutedEventArgs e)
        {
            Window asd = new Alertas();
            asd.Visibility = Visibility.Visible;
            this.Visibility = Visibility.Collapsed;
        }

        
     
    }
}
