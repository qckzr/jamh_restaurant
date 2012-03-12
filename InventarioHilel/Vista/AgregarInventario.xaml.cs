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
using System.Data;
using System.Data.SQLite;

namespace InventarioHilel.Vista
{
    /// <summary>
    /// Interaction logic for AgregarInventario.xaml
    /// </summary>
    public partial class AgregarInventario : Page
    {
        int idProducto;

        public AgregarInventario()
        {
            InitializeComponent();
            llenarListBoxProductos();


        }

        private void b_cerrarAdmin_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (Logica.getInstance().Usuario.Admin)
                this.NavigationService.Navigate(new MenuOpciones());
            else
                this.NavigationService.Navigate(new MenuUsuario());
        }

        private void listBoxProductos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            idProducto = Convert.ToInt32(Logica.getInstance().getDb().consultar("select id from productos where nombre='" + listBoxProductos.SelectedItem.ToString() + "'").Rows[0][0].ToString());
         
        }

        private void llenarListBoxProductos()
        {
            DataTable dt = Logica.getInstance().getDb().consultar("select  id, nombre from productos order by nombre");
            foreach (DataRow dr in dt.Rows)
            {
                listBoxProductos.Items.Add(dr[1].ToString());

            }
        }

        private void b_agregarInventario_Click(object sender, RoutedEventArgs e)
        {

            if(validar()==true)
            {
                    String dia, mes, anio,ubicacion;
                    if (Convert.ToInt32(calendar1.SelectedDate.Value.Day.ToString()) < 10)
                        dia = "0" + calendar1.SelectedDate.Value.Day.ToString();
                    else dia = calendar1.SelectedDate.Value.Day.ToString();

                    if (Convert.ToInt32(calendar1.SelectedDate.Value.Month.ToString()) < 10)
                        mes = "0" + calendar1.SelectedDate.Value.Month.ToString();
                    else mes = calendar1.SelectedDate.Value.Month.ToString();

                    anio = calendar1.SelectedDate.Value.Year.ToString();

                    int cantidad = Convert.ToInt32(textBoxCantidad.Text);

                    if (textBoxUbicacion.Text == null)
                        ubicacion = "null";
                    else ubicacion = "'"+textBoxUbicacion.Text+"'";

                    Logica.getInstance().agregarAlInventario(idProducto, anio + "-" + mes + "-" + dia, cantidad,ubicacion);
                    MessageBox.Show("Se ha agregado en inventario el producto " + listBoxProductos.SelectedItem + " con una cantidad de " + cantidad);
                    this.NavigationService.Navigate(new AgregarInventario());
            }
                

         }

        private void calendar1_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
        
        }

        private Boolean validar()
        {
            if (textBoxCantidad.Text.Length==0)
            {
                MessageBox.Show("La cantidad no puede estar vacia");
                return false;
            }
            else if (Convert.ToInt32(textBoxCantidad.Text) < 0)
            {
                MessageBox.Show("La cantidad no puede ser negativa");
                return false;
            }

            if (listBoxProductos.SelectedItem == null)
            {
                MessageBox.Show("Tiene que seleccionar un producto");
                return false;

            }

            if (calendar1.SelectedDate < DateTime.Now)
            {
                MessageBox.Show("La fecha tiene que ser mayor al dia de hoy");
                return false;
            }
            return true;
        }

    }
}

