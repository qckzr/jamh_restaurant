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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Logica = InventarioHilel.Controlador.Logica;
using System.Data.SQLite;
using System.Data;

namespace InventarioHilel.Vista
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
            WindowState = WindowState.Maximized;
            WindowStyle = WindowStyle.None;
        }

        private void buttonIngresar_Click(object sender, RoutedEventArgs e)
        {
            if (Logica.getInstance().validarLogin(textBoxUsuario.Text, textBoxContrasena.Password) == true)
            {
                Window asd = new MenuOpciones();
                asd.Visibility = Visibility.Visible;
                this.Visibility = Visibility.Collapsed;
            }
            else 
                MessageBox.Show("Error en el nick o en la contrasena");
     
            
        }

        private void b_cerrar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

        }

        private void b_cerrar_MouseUp(object sender, MouseButtonEventArgs e)
        {
            
        }
/*
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            InventarioHilel.Modelo.DAOBaseDatos a = new InventarioHilel.Modelo.DAOBaseDatos();
            a.extraerInformacion();
        }
  */      
    }
}
