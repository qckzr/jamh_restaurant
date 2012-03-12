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

        public string obtenerIDBasedeDatos(DAOBaseDatos db, int tipo, string opcion)
        {
            string query = "";
            if (tipo == 0)
                query = "select id from usuario where nickname='" + opcion + "'";
            else
                query = "select id from productos where nombre = '"+ opcion +"'";
            DataTable usuario = db.consultar(query);
            return usuario.Rows[0]["id"].ToString();
        }

        public Boolean registrarAccion(DAOBaseDatos db, string mensaje, string producto)
        {
            DateTime tiempoActual = DateTime.Now;
            string mes = tiempoActual.Month.ToString(); string dia = tiempoActual.Day.ToString();
            if (tiempoActual.Month < 10)
                mes = "0" + tiempoActual.Month;
            if (tiempoActual.Day < 10)
                dia = "0" + tiempoActual.Day;
            string fecha = tiempoActual.Year + "-" + mes + "-" + dia;
            string hora = tiempoActual.Hour + ":" + tiempoActual.Minute + ":" + tiempoActual.Second;
            string id = obtenerIDBasedeDatos(db,0,nick);
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

        public string nombreProductoBD(DAOBaseDatos db, string producto)
        {
            string query = "select nombre from productos where id=" + producto;
            DataTable dato = db.consultar(query);
            return dato.Rows[0]["nombre"].ToString();
        }

        public List<string> leerLogs(DAOBaseDatos db, string nickname)
        {
            List<string> listaLogs = new List<string>();
            string id_usuario = obtenerIDBasedeDatos(db, 0, nickname);
            string query = "select strftime('%Y-%m-%d',fecha) as fechaLog, "
                            + "strftime('%H:%M:%S', hora) as horaLog from log_historico where id_usuario=" + id_usuario;
            string query0 = "select id_producto, mensaje_accion from log_historico where id_usuario=" + id_usuario;
            DataTable fechas = db.consultar(query);
            DataTable campos = db.consultar(query0);
            int cont = 0; string log = "";
            foreach (DataRow logs in fechas.Rows)
            {
                DataRow info = campos.Rows[cont];
                if (info["id_producto"].ToString().Count() == 0)
                    log = nickname + " ("+logs["fechaLog"].ToString()+","+logs["horaLog"].ToString()+"): " + info["mensaje_accion"];
                else
                    log = nickname + " (" + logs["fechaLog"].ToString() + "," + logs["horaLog"].ToString() + "): "
                        + info["mensaje_accion"] + " " + nombreProductoBD(db,info["id_producto"].ToString());
                listaLogs.Add(log);
                cont++;
            }
            return listaLogs;
        }
    }
}
