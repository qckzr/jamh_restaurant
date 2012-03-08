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

        
     
    }
}
