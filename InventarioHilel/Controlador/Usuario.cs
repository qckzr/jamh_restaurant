using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
    }
}
