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

        private Logica()
        {
            db = new DAOBaseDatos("Data Source=../../archivos/bd.sqlite3;Version=3");
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
            if (a.Rows.Count> 0)
                return true;
            else
                return false;
        }
    }
}
