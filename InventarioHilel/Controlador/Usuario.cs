using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAOBaseDatos = InventarioHilel.Modelo.DAOBaseDatos;

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

        public Boolean registrarAccion(DAOBaseDatos db, string mensaje, string producto)
        {
            DateTime tiempoActual = DateTime.Now;
            return true;
        }
    }
}
