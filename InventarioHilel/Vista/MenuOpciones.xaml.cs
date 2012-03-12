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
    /// Interaction logic for MenuOpciones.xaml
    /// </summary>
    public partial class MenuOpciones : Page
    {
        public MenuOpciones()
        {
            InitializeComponent();
            iniciarValores();
        }

        private void button1_Click_1(object sender, RoutedEventArgs e)
        {

            Application.Current.Shutdown();

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            //Window asd = new MenuUsuario();
            //asd.Visibility = Visibility.Visible;
            //this.Visibility = Visibility.Collapsed;
        }

        private void b_ActualizarInventario_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new actualizarInventario());
        }

        private void b_consultarInventario_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new ConsultarInventario());
        }

        private void b_AdministrarUsurios_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AdministrarUsuarios());
        }

        private void b_AdministrarProductos_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AdministrarProductos());
        }

        private void b_alertas_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Alertas());
        }


        private void iniciarValores()
        {
            if (Logica.getInstance().Usuario.Admin == true)
            {
                labelTipoUsuario.Content = Logica.getInstance().Usuario.Nick;
            }
        }
        
     
    }
}
