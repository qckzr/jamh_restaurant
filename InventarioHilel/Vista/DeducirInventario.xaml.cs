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

namespace InventarioHilel.Vista
{
    /// <summary>
    /// Interaction logic for DeducirInventario.xaml
    /// </summary>
    public partial class DeducirInventario : Window
    {
        public DeducirInventario()
        {
            InitializeComponent();
            WindowState = WindowState.Maximized;
            WindowStyle = WindowStyle.None;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void b_cerrarAdmin_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

        }

       
    }
}
