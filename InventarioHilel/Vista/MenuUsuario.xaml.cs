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
    public partial class MenuUsuario : Page
    {
        public MenuUsuario()
        {
            InitializeComponent();
        }
        
        private void b_cerrarUsuario_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void b_ActualizarInventarioU_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new actualizarInventario());
        }

        private void b_alertasU_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Alertas());
        }

        private void b_consultarInventarioU_Click(object sender, RoutedEventArgs e)
        {
           this.NavigationService.Navigate(new ConsultarInventario());
        }
    }
}
