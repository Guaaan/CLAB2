using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLAB2
{
    class Conexion
    {
        public static MySqlConnection conexion() 
        {
            string servidor = "localhost";
            string bd = "farmacia";
            string usuario = "root";
            string password = "Juan1309";

            string cadenaConexion = "Database=" + bd + "; Data Source=" + servidor + "; User Id= " + usuario + "; Password=" + password+"";

            try 
            {
                MySqlConnection conexionBD = new MySqlConnection(cadenaConexion);

                return conexionBD;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return null;
            }
        }
    }
}
