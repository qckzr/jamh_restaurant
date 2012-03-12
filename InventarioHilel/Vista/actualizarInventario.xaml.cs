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
    /// Interaction logic for actualizarInventario.xaml
    /// </summary>
    public partial class actualizarInventario : Page
    {
        public actualizarInventario()
        {
            InitializeComponent();
            iniciarValores();
        }

        private void b_cerrarActualizacion_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void b_deducirInventario_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new DeducirInventario());
        }

        private void b_AgregarInventario_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AgregarInventario());
        }

        private void b_volver_Click(object sender, RoutedEventArgs e)
        {
            if (Logica.getInstance().Usuario.Admin)
                this.NavigationService.Navigate(new MenuOpciones());
            else
                this.NavigationService.Navigate(new MenuUsuario());
        }

        private void iniciarValores()
        {
            labelTipoUsuario.Content = Logica.getInstance().Usuario.Nick;
            if (Logica.getInstance().Usuario.Admin == true)
                
                image1.Source = new BitmapImage(new Uri("/InventarioHilel;component/Images/lock-icon.png",UriKind.RelativeOrAbsolute));
            else
                image1.Source = new BitmapImage(new Uri("/InventarioHilel;component/Images/User-yellow-icon.png",UriKind.RelativeOrAbsolute));

        }
    }
}
