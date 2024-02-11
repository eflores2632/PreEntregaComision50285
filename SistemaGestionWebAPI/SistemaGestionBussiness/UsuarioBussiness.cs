using SistemaGestionData;
using SistemaGestionEntities;
namespace SistemaGestionBussiness
{
    public static class UsuarioBussiness
    {
        public static Usuario ObtenerUsuario(int id)
        {
            return UsuarioData.ObtenerUsuario(id);
        }
        public static List<Usuario> ListarUsuarios()
        {
            return UsuarioData.ListarUsuarios();
        }
        public static bool CrearUsuario(Usuario user)
        {
            return UsuarioData.CrearUsuario(user);
        }
        public static bool ModificarUsuario(int id, Usuario user)
        {
            return UsuarioData.ModificarUsuario(id, user);
        }
        public static bool EliminarUsuario(int id)
        {
            return UsuarioData.EliminarUsuario(id);
        }
    }
}
