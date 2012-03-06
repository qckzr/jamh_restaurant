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

        private SQLiteConnection conexion;

        public DAOBaseDatos()
        {
 
        }

        public DAOBaseDatos(String path)
        {
            conexion = new SQLiteConnection(path);
        }

        public void conectar()
        {
            conexion.Open();
        }

        public void desconectar()
        {
            conexion.Close();
        }

        public DataTable consultar(String query)
        {
            conectar();
            SQLiteDataAdapter db = new SQLiteDataAdapter(query, conexion);
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();


            ds.Reset();
            db.Fill(ds);

            dt = ds.Tables[0];
            desconectar();
            return dt;
  /*          SQLiteCommand cmd = new SQLiteCommand(query, conexion);
            SQLiteDataReader datos = cmd.ExecuteReader();
            // Leemos los datos de forma repetitiva
            while (datos.Read())
            {
                string codigo = Convert.ToString(datos[0]);

                string nombre = Convert.ToString(datos[1]);
                // Y los mostramos

                Console.WriteLine("Codigo: {0}, Nombre: {1}",
                    codigo, nombre);
            }*/
        }


        public void extraerInformacion()
        {
            SQLiteConnection conexion = new SQLiteConnection("Data Source=../../archivos/bd.sqlite3;Version=3");
            conexion.Open();

            //Se conecta a la BD y trae los datos para, luego, llenar el DataSet
            string strSQL = "select * from usuario";
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
