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
    /// Interaction logic for CrearProducto.xaml
    /// </summary>
    public partial class CrearProducto : Page
    {
        public CrearProducto()
        {
            InitializeComponent();
           
        }

        private void b_cerrarAdmin_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
