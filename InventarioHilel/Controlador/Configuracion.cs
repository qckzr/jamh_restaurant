using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace InventarioHilel.Controlador
{
    class Configuracion
    {
        private string BDpath;

        public string BD
        {
            get { return BDpath; }
            set { BDpath = value; }
        }

        public Configuracion()
        {
            BDpath = ConfigurationManager.AppSettings["BaseDeDatos"];
        }
    }
}
