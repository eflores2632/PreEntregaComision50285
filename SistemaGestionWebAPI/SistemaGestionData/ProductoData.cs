using Microsoft.Data.SqlClient;
using SistemaGestionEntities;

namespace SistemaGestionData
{
    public class ProductoData
    {
        private static string stringConnection = "Data Source=DESKTOP-TRA01FH;Database=coderhouse;Trusted_Connection=True;";
        public static Producto ObtenerProducto(int id)
        {
            using (SqlConnection connection = new SqlConnection(stringConnection))
            {
                string query = "SELECT * FROM Producto where id = @id";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("id", id);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    int idObtenido = Convert.ToInt32(reader["id"]);
                    string descripciones = reader.GetString(1);
                    decimal costo = reader.GetDecimal(2);
                    decimal precioventa = reader.GetDecimal(3);
                    int stock = Convert.ToInt32(4);
                    int idusuario = Convert.ToInt32(5);
                    Producto productonuevo = new(idObtenido, descripciones, costo, precioventa, stock, idusuario);
                    return productonuevo;
                }
                else
                {
                    throw new Exception("Id no encontrado");
                }
            }
        }
        public static List<Producto> ListarPrductos()
        {
            using (SqlConnection connection = new SqlConnection(stringConnection))
            {
                string query = "SELECT * FROM Producto";
                SqlCommand cmd = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                List<Producto> listaProductos = new List<Producto>();
                while (reader.Read())
                {
                    int idObtenido = Convert.ToInt32(reader["id"]);
                    string descripciones = reader.GetString(1);
                    decimal costo = reader.GetDecimal(2);
                    decimal precioventa = reader.GetDecimal(3);
                    int stock = Convert.ToInt32(4);
                    int idusuario = Convert.ToInt32(5);
                    Producto productonuevo = new(idObtenido, descripciones, costo, precioventa, stock, idusuario);
                    listaProductos.Add(productonuevo);
                }
                return listaProductos;
            }
        }
        public static bool CrearProducto(Producto producto)
        {
            using (SqlConnection connection = new SqlConnection("Data Source=DESKTOP-TRA01FH;Database=coderhouse;Trusted_Connection=True;"))
            {
                string query = "INSERT INTO Producto (Descripciones,Costo,PrecioVenta,Stock,IdUsuario) values (@descripciones,@costo,@precioVenta,@stock,@idUsuario)";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("descripciones", producto.Descripcion);
                cmd.Parameters.AddWithValue("costo", producto.Costo);
                cmd.Parameters.AddWithValue("precioVenta", producto.PrecioVenta);
                cmd.Parameters.AddWithValue("stock", producto.Stock);
                cmd.Parameters.AddWithValue("idUsuario", producto.IdUsuario);
                connection.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
        public static bool ModificarProducto(int id, Producto producto)
        {
            using (SqlConnection connection = new SqlConnection(stringConnection))
            {
                string query = "UPDATE Producto SET Descripciones = @descripciones,Costo = @costo,PrecioVenta = @precioVenta,Stock = @stock,IdUsuario = @idUsuario WHERE id = @id";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("id", id);
                cmd.Parameters.AddWithValue("descripciones", producto.Descripcion);
                cmd.Parameters.AddWithValue("costo", producto.Costo);
                cmd.Parameters.AddWithValue("precioVenta", producto.PrecioVenta);
                cmd.Parameters.AddWithValue("stock", producto.Stock);
                cmd.Parameters.AddWithValue("idUsuario", producto.IdUsuario);
                connection.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
        public static bool EliminarProducto(int id)
        {
            using (SqlConnection connection = new SqlConnection(stringConnection))
            {
                string query = "DELETE FROM Producto WHERE id = @id";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("id", id);
                connection.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}
