using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.Data;

namespace InventarioHilel.Modelo
{
    class DAOBaseDatos
    {
        //Asi se referencia una carpeta interna =.=, FUCKING visual studio

        public void extraerInformacion()
        {
            SQLiteConnection conexion = new SQLiteConnection("Data Source=../../archivos/bd.sqlite3;Version=3");
            conexion.Open();

            //Se conecta a la BD y trae los datos para, luego, llenar el DataSet
            string strSQL = "select * from prueba";
            SQLiteDataAdapter db = new SQLiteDataAdapter(strSQL, conexion);
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();


            ds.Reset();
            db.Fill(ds);

            dt = ds.Tables[0];

            //imprimimos los rows... habra que crear una clase para todas estas operaciones
            foreach (DataRow a in dt.Rows)
            {
                Console.Write("Columna :" + a["id"] + "\n");
            }
            conexion.Close();

            Console.ReadLine();
        }
    }
}
