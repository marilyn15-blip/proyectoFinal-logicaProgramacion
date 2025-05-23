using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoFinalLogica.Entidad;

namespace ProyectoFinalLogica.BaseDatos
{
    public class RutaDB
    {
        private DataBaseConexion dbConexion;

        public RutaDB()
        {
            dbConexion = new DataBaseConexion();
        }

        public bool Create(RutaEntidad ruta)
        {
            try
            {
                using (var connection = dbConexion.GetConnection())
                {
                    connection.Open();
                    string query = "INSERT INTO Ruta (LugarSalida, LugarLLegada) VALUES (@LugarSalida, @LugarLLegada)";
                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@LugarSalida", ruta.LugarSalida);
                        command.Parameters.AddWithValue("@LugarLLegada", ruta.LugarLLegada);
                        command.ExecuteNonQuery();
                    }
                    connection.Close();
                    Console.WriteLine("ruta creada");
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al crear la ruta: " + ex.Message);
                return false;
            }
        }

        public bool Update(RutaEntidad ruta)
        {
            try
            {
                using (var connection = dbConexion.GetConnection())
                {
                    connection.Open();
                    string query = "UPDATE Ruta SET LugarSalida = @LugarSalida, LugarLLegada = @LugarLLegada WHERE RutaID = @RutaID";
                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@RutaID", ruta.RutaID);
                        command.Parameters.AddWithValue("@LugarSalida", ruta.LugarSalida);
                        command.Parameters.AddWithValue("@LugarLLegada", ruta.LugarLLegada);
                        command.ExecuteNonQuery();
                    }
                    connection.Close();
                    Console.WriteLine("ruta actualizada");
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al actualizar la ruta: " + ex.Message);
                return false;
            }
        }

        public bool Delete(int rutaID)
        {
            try
            {
                using (var connection = dbConexion.GetConnection())
                {
                    connection.Open();
                    string query = "DELETE FROM Ruta WHERE RutaID = @RutaID";
                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@RutaID", rutaID);
                        command.ExecuteNonQuery();
                    }
                    connection.Close();
                    Console.WriteLine("ruta eliminada");
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al eliminar la ruta: " + ex.Message);
                return false;
            }
        }

        public List<RutaEntidad> GetAll()
        {
            List<RutaEntidad> rutas = new List<RutaEntidad>();
            try
            {
                using (var connection = dbConexion.GetConnection())
                {
                    connection.Open();
                    string query = "SELECT * FROM Ruta";
                    using (var command = new SqlCommand(query, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                RutaEntidad ruta = new RutaEntidad
                                {
                                    RutaID = reader.GetInt32(0),
                                    LugarSalida = reader.GetString(1),
                                    LugarLLegada = reader.GetString(2)
                                };
                                rutas.Add(ruta);
                            }
                        }
                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener las rutas: " + ex.Message);
            }
            return rutas;
        }

        public RutaEntidad GetById(int rutaID)
        {
            RutaEntidad ruta = null;
            try
            {
                using (var connection = dbConexion.GetConnection())
                {
                    connection.Open();
                    string query = "SELECT * FROM Ruta WHERE RutaID = @RutaID";
                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@RutaID", rutaID);
                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                ruta = new RutaEntidad
                                {
                                    RutaID = reader.GetInt32(0),
                                    LugarSalida = reader.GetString(1),
                                    LugarLLegada = reader.GetString(2)
                                };
                            }
                        }
                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener la ruta por ID: " + ex.Message);
            }
            return ruta;
        }
    }
}
