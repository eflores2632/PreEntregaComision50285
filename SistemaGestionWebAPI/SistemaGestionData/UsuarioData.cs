using Microsoft.Data.SqlClient;
using SistemaGestionEntities;
namespace SistemaGestionData
{
    public class UsuarioData
    {
        private static string stringConnection = "Data Source=DESKTOP-TRA01FH;Database=coderhouse;Trusted_Connection=True;";
        public static Usuario ObtenerUsuario(int id)
        {
            using (SqlConnection connection = new SqlConnection(stringConnection))
            {
                string query = "SELECT * FROM Usuario where id = @id";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("id", id);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    int idObtenido = Convert.ToInt32(reader["id"]);
                    string nombre = reader.GetString(1);
                    string apellido = reader.GetString(2);
                    string nombreUsuario = reader.GetString(3);
                    string password = reader.GetString(4);
                    string mail = reader.GetString(5);
                    Usuario usuarionuevo = new(idObtenido, nombre, apellido, nombreUsuario, password, mail);
                    return usuarionuevo;
                }
                else
                {
                    throw new Exception("Id no encontrado");
                }
            }
        }
        public static List<Usuario> ListarUsuarios()
        {
            using (SqlConnection connection = new SqlConnection(stringConnection))
            {
                string query = "SELECT * FROM Usuario";
                SqlCommand cmd = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                List<Usuario> listaUsuarios = new List<Usuario>();
                while (reader.Read())
                {
                    int idObtenido = Convert.ToInt32(reader["id"]);
                    string nombre = reader.GetString(1);
                    string apellido = reader.GetString(2);
                    string nombreUsuario = reader.GetString(3);
                    string password = reader.GetString(4);
                    string mail = reader.GetString(5);
                    Usuario usuarionuevo = new(idObtenido, nombre, apellido, nombreUsuario, password, mail);
                    listaUsuarios.Add(usuarionuevo);
                }
                return listaUsuarios;
            }
        }
        public static bool CrearUsuario(Usuario user)
        {
            using (SqlConnection connection = new SqlConnection(stringConnection))
            {
                string query = "INSERT INTO Usuario (Nombre,Apellido,NombreUsuario,Contraseña,Mail) values (@nombre,@apellido,@nombreUsuario,@contrasena,@mail)";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("nombre", user.Nombre);
                cmd.Parameters.AddWithValue("apellido", user.Apellido);
                cmd.Parameters.AddWithValue("nombreUsuario", user.NombreUsuario);
                cmd.Parameters.AddWithValue("contrasena", user.Contrasena);
                cmd.Parameters.AddWithValue("mail", user.Mail);
                connection.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
        public static bool ModificarUsuario(int id, Usuario user)
        {
            using (SqlConnection connection = new SqlConnection(stringConnection))
            {
                string query = "UPDATE Usuario SET Nombre = @nombre,Apellido = @apellido,NombreUsuario = @nombreUsuario,Contraseña = @contrasena,Mail = @mail WHERE id = @id";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("nombre", user.Nombre);
                cmd.Parameters.AddWithValue("apellido", user.Apellido);
                cmd.Parameters.AddWithValue("nombreUsuario", user.NombreUsuario);
                cmd.Parameters.AddWithValue("contrasena", user.Contrasena);
                cmd.Parameters.AddWithValue("mail", user.Mail);
                cmd.Parameters.AddWithValue("id", id);
                connection.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
        public static bool EliminarUsuario(int id)
        {
            using (SqlConnection connection = new SqlConnection(stringConnection))
            {
                string query = "DELETE FROM Usuario WHERE id = @id";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("id", id);
                connection.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}
