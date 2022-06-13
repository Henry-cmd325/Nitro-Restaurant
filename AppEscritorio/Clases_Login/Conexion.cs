using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace AppEscritorio
{
    internal class Conexion
    {
        public static MySqlConnection GetConnection()
        {
            string server = "localhost";
            string user = "root";
            string pwd = "pene?";
            string database = "empleados";
            string cadenaConexion = "server=" + server + ";user=" + user + ";pwd=" + pwd + ";database=" + database;


            MySqlConnection conexion = new MySqlConnection(cadenaConexion);


            return conexion;

        }
    }
}
