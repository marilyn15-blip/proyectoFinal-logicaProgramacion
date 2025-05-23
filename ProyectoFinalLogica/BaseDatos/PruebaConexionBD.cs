using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalLogica.BaseDatos
{
    public class PruebaConexionBD
    {
        private DataBaseConexion dbConexion;

        public PruebaConexionBD()
        {
            dbConexion = new DataBaseConexion();
        }

        public void TestConnection()
        {
            try
            {
                using (var connection = dbConexion.GetConnection())
                {
                    connection.Open();
                    Console.WriteLine("Conexión exitosa a la base de datos.");
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al conectar a la base de datos: " + ex.Message);
            }
        }

    }
}