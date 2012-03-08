using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAOBaseDatos = InventarioHilel.Modelo.DAOBaseDatos;
using System.Data.SQLite;
using System.Data;

namespace InventarioHilel.Controlador
{
    class Usuario
    {
        private string nick;

        private Boolean admin;

        public Usuario(string nick, string admin)
        {
            this.nick = nick;
            if (admin == "SI")
                this.admin = true;
            else
                this.admin = false;
        }

        public string Nick
        {
            get { return nick; }
            set { nick = value; }
        }

        public Boolean Admin
        {
            get { return admin; }
            set { admin = value; }
        }

        public string obtenerIDBasedeDatos(DAOBaseDatos db, int tipo, string producto)
        {
            string query = "";
            if (tipo == 0)
                query = "select id from usuario where nickname='" + nick + "'";
            else
                query = "select id from producto where nombre = '"+ producto +"'";
            DataTable usuario = db.consultar(query);
            return usuario.Rows[0]["id"].ToString();
        }

        public Boolean registrarAccion(DAOBaseDatos db, string mensaje, string producto)
        {
            DateTime tiempoActual = DateTime.Now;
            string fecha = tiempoActual.Year + "-" + tiempoActual.Month + "-" + tiempoActual.Day;
            string hora = tiempoActual.Hour + ":" + tiempoActual.Minute + ":" + tiempoActual.Second;
            string id = obtenerIDBasedeDatos(db,0,producto);
            string query = "";
            if (producto != null)
            {
                string idProducto = obtenerIDBasedeDatos(db, 1, producto);
                query = "insert into log_historico(fecha, hora, id_usuario, id_producto,mensaje_accion) "
                    + "values ('" + fecha + "','" + hora + "'," + id + "," + idProducto + ",'" + mensaje + "')";
            }
            else
                query = "insert into log_historico(fecha, hora, id_usuario, id_producto,mensaje_accion) "
                    + "values ('" + fecha + "','" + hora + "'," + id + ",NULL,'" + mensaje + "')";
            db.hacerQuery(query);
            return true;
        }
    }
}
