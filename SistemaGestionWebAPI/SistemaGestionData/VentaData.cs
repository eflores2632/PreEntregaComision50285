using Microsoft.Data.SqlClient;
using SistemaGestionEntities;
namespace SistemaGestionData
{
    public class VentaData
    {
        private static string stringConnection = "Data Source=DESKTOP-TRA01FH;Database=coderhouse;Trusted_Connection=True;";
        public static Venta ObtenerVenta(int id)
        {
            using (SqlConnection connection = new SqlConnection(stringConnection))
            {
                string query = "SELECT * FROM Venta where id = @id";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("id", id);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    int idObtenido = Convert.ToInt32(reader["id"]);
                    string comentarios = reader.GetString(1);
                    int idusuario = Convert.ToInt32(2);
                    Venta ventanuevo = new Venta(idObtenido, comentarios, idusuario);
                    return ventanuevo;
                }
                else
                {
                    throw new Exception("Id no encontrado");
                }
            }
        }
        public static List<Venta> ListarVentas()
        {
            using (SqlConnection connection = new SqlConnection(stringConnection))
            {
                string query = "SELECT * FROM Venta";
                SqlCommand cmd = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                List<Venta> listaVenta = new List<Venta>();
                while (reader.Read())
                {
                    int idObtenido = Convert.ToInt32(reader["id"]);
                    string comentarios = reader.GetString(1);
                    int idusuario = Convert.ToInt32(2);
                    Venta ventanuevo = new Venta(idObtenido, comentarios, idusuario);
                    listaVenta.Add(ventanuevo);
                }
                return listaVenta;
            }
        }
        public static bool CrearVenta(Venta venta)
        {
            using (SqlConnection connection = new SqlConnection(stringConnection))
            {
                string query = "INSERT INTO Usuario (Comentarios,IdUsuarios) values (@comentarios,@idusuario)";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("comentarios", venta.Comentarios);
                cmd.Parameters.AddWithValue("idusuario", venta.IdUsuario);
                connection.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
        public static bool ModificarVenta(int id, Venta venta)
        {
            using (SqlConnection connection = new SqlConnection(stringConnection))
            {
                string query = "UPDATE Venta SET Comentarios = @comentarios,IdUsuarios = @idusuario WHERE id = @id";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("comentarios", venta.Comentarios);
                cmd.Parameters.AddWithValue("idusuario", venta.IdUsuario);
                cmd.Parameters.AddWithValue("id", id);
                connection.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
        public static bool EliminarVenta(int id)
        {
            using (SqlConnection connection = new SqlConnection(stringConnection))
            {
                string query = "DELETE FROM Venta WHERE id = @id";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("id", id);
                connection.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}
