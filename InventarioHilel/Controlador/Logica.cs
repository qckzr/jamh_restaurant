using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAOBaseDatos = InventarioHilel.Modelo.DAOBaseDatos;
using System.Data;

namespace InventarioHilel.Controlador
{
    class Logica
    {
        private DAOBaseDatos db;

        private static Logica instancia;

        private Configuracion config;

        private Usuario usuario;

        private Logica()
        {
            config = new Configuracion();
            db = new DAOBaseDatos(config.BD);
        }

        public Usuario Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }

        public static Logica getInstance()
        {
            if (instancia == null)
                instancia = new Logica();
            return instancia;
        }

        public DAOBaseDatos getDb()
        {
            return db;
        }

        public Boolean validarLogin(String nick, String contrasena)
        {
            DataTable a = db.consultar("select * from usuario where nickname ='" + nick + "' and contrasena = '" + contrasena + "'");
            if (a.Rows.Count > 0)
            {
                DataRow user = a.Rows[0];
                usuario = new Usuario(nick, (string)user["es_administrador"]);
                usuario.registrarAccion(db, "Inicio Sesion", null);
                return true;
            }
            else
                return false;
        }


        public Boolean deducirDelInventario(int idProducto, String fechaVencimiento, int cantidad)
        {
            int cantidadActual = Convert.ToInt32(Logica.getInstance().getDb().consultar("select cantidad_actual from fecha_productos where strftime('%d-%m-%Y',fecha_vencimiento)='" + fechaVencimiento + "' and id_producto=" + idProducto).Rows[0][0].ToString());
            if (cantidadActual < cantidad)
                return false;
            else
            {
                int nuevaCantidadActual = cantidadActual - cantidad;
                getDb().hacerQuery("update fecha_productos set cantidad_actual=" + nuevaCantidadActual+ " where strftime('%d-%m-%Y',fecha_vencimiento)='" + fechaVencimiento + "' and id_producto=" + idProducto + "");
                return true;
            }

        }

        public Boolean agregarAlInventario(int idProducto, String fechaVencimiento, int cantidad,String ubicacion)
        {
            getDb().hacerQuery("insert into fecha_productos(fecha_adquisicion,hora_adquisicion,id_producto,cantidad_inicial,cantidad_actual,fecha_vencimiento,ubicacion) values(date('now','localtime'),time('now','localtime')," + idProducto + "," + cantidad + "," + cantidad + ",'"+fechaVencimiento+"'," + ubicacion + ")");
            return true;
        }

        public DataTable consultarProducto(int idProducto)
        {
            return db.consultar("select * from producto where idproducto=" + idProducto);
        }

        public Boolean crearProducto(String nombre, String tipo, int cantidadMinima)
        {
            db.hacerQuery("insert into productos (nombre,tipo,cantidadminima) values ('"+nombre+"','"+tipo+"',"+cantidadMinima+"");
            return true;

        }

        public Boolean modificarProducto(int idProducto,String nombre, String tipo, int cantidadMinima)
        {
            if (nombre!=null)
                db.hacerQuery("update productos set nombre='"+nombre+"' where idproducto="+idProducto);
            if (tipo!=null)
                db.hacerQuery("update productos set tipo='" + tipo + "' where idproducto=" + idProducto);
            if (cantidadMinima>0) //validar esto en la interfaz jeje
                db.hacerQuery("update productos set cantidadminima=" + cantidadMinima + " where idproducto=" + idProducto);
            return true;

        }

        public Boolean eliminarProducto(int idProducto)
        {
            db.hacerQuery("delete from fecha_productos where id_producto=" + idProducto);
            db.hacerQuery("delete from productos where idproducto=" + idProducto);
            return true;
 
        }

        public Boolean crearUsuario(String nombre,String apellido,String email,String contrasena, String esAdmin, String nick)
        {
            db.hacerQuery("insert into usuario (nombre,apellido,email,contrasena,es_administrador,nick) values ('"+nombre+"','"+apellido+"','"+email+"','"+contrasena+"','"+esAdmin+"','"+nick+"'");
            return true;

        }

        public Boolean modificarUsuario(int idUsuario, String nombre, String apellido, String email, String contrasena, String esAdmin, String nick)
        {

            if (nombre!=null)
                db.hacerQuery("update usuario set nombre='"+nombre+"' where id="+idUsuario);
            if (apellido!=null)
                db.hacerQuery("update usuario set apellido='"+apellido+"' where id="+idUsuario);
            if (email!=null)
                db.hacerQuery("update usuario set email='"+email+"' where id="+idUsuario);
            if (contrasena!=null)
                db.hacerQuery("update usuario set contrasena='"+contrasena+"' where id="+idUsuario);
            if (esAdmin!=null)
                db.hacerQuery("update usuario set es_administrador='"+esAdmin+"' where id="+idUsuario);
            if (nick!=null)
                db.hacerQuery("update usuario set nick='" + nick + "' where id=" + idUsuario);
            return true;

        }

        public Boolean eliminarUsuario(int idUsuario)
        {
            db.hacerQuery("delete from log_historico where id_usuario="+idUsuario);
            db.hacerQuery("delete from usuario where id="+idUsuario);
            return true;
        }

        public DataTable consultarUsuario(int idUsuario)
        {
            return db.consultar("select * from usuario where id=" + idUsuario);
        }

    }
}
