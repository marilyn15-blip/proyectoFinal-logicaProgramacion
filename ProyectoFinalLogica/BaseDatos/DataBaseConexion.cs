using System.Data.SqlClient;

namespace ProyectoFinalLogica.BaseDatos
{
    public class DataBaseConexion
    {
        private string connectionString;
        public DataBaseConexion()
        {
            // Conexion July
            connectionString = "Data Source=LAPTOP-GVH12R86\\SQLEXPRESS;Initial Catalog=ProyectoBusesDB;Trusted_Connection=True;Integrated Security=True";

            // Conexion Jose
            //connectionString = "Data Source=LAPTOP-2525;Initial Catalog=ProyectoBusesDB;Trusted_Connection=True;Integrated Security=True";
        }
        public SqlConnection GetConnection()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            return connection;
        }
    }
}
