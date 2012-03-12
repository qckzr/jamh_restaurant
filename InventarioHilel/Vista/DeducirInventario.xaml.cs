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
using System.Data.SQLite;
using System.Data;

namespace InventarioHilel.Vista
{
    /// <summary>
    /// Interaction logic for DeducirInventario.xaml
    /// </summary>
    public partial class DeducirInventario : Page
    {
        int idProducto;

        public DeducirInventario()
        {
            InitializeComponent();
            llenarListBoxProductos();
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

        private void listBoxProductos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataTable dt = Logica.getInstance().getDb().consultar("select strftime('%d-%m-%Y',fecha_vencimiento), id_producto from fecha_productos where id_producto=(select id from productos where nombre='"+listBoxProductos.SelectedItem.ToString()+"')");
            foreach (DataRow dr in dt.Rows)
            {
                cb_fechaVencimiento.Items.Add(dr[0].ToString());
                idProducto = Convert.ToInt32(dr[1].ToString());
                Console.WriteLine("id producto = " + idProducto);
                
            }
        }

        private void llenarListBoxProductos()
        {
            DataTable dt = Logica.getInstance().getDb().consultar("select  id, nombre from productos order by nombre");
            foreach (DataRow dr in dt.Rows)
            {
                listBoxProductos.Items.Add(dr[1].ToString());
                
            }
        }

        private void b_deducirInventario_Click(object sender, RoutedEventArgs e)
        {
            if (validar() == true)
            {

                if (Logica.getInstance().deducirDelInventario(idProducto, cb_fechaVencimiento.SelectedItem.ToString(), Convert.ToInt32(textBoxCantidad.Text)) == true)
                {

                    MessageBox.Show("Se ha deducido " + textBoxCantidad.Text + " unidades del producto del producto " + listBoxProductos.SelectedItem.ToString());
                    this.NavigationService.Navigate(new DeducirInventario());
                }
                else MessageBox.Show("La cantidad tiene que ser menor ");
                //SE PODRIA COLOCAR EN LA INTEFAZ CUANTOS HAY DISPONIBLES :)
                //FALTA VALIDAR SI COLOCA UNA LETRA EN DONDE VA CANTIDAD =.=
            }

        }

        private void cb_fechaVencimiento_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void textBoxCantidad_TextChanged(object sender, TextChangedEventArgs e)
        {
           
                
        }


        private Boolean validar()
        {
            if (textBoxCantidad.Text.Length==0)
            {
                MessageBox.Show("La cantidad no puede estar vacia");
                return false;
            }
            if (Convert.ToInt32(textBoxCantidad.Text) < 0)
            {
                MessageBox.Show("La cantidad no puede ser negativa");
                return false;
            }

            return true;

        }
       
    }
}
