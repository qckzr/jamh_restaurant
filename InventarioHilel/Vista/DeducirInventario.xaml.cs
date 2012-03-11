﻿using System;
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
    /// Interaction logic for DeducirInventario.xaml
    /// </summary>
    public partial class DeducirInventario : Page
    {
        public DeducirInventario()
        {
            InitializeComponent();
        }
        
        private void b_cerrarAdmin_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void b_volver_Click(object sender, RoutedEventArgs e)
        {
            if (Logica.getInstance().Usuario.Admin)
                this.NavigationService.Navigate(new MenuOpciones());
            else
                this.NavigationService.Navigate(new MenuUsuario());
        }

       
    }
}
