using SistemaGestionData;
using SistemaGestionEntities;

namespace SistemaGestionBussiness
{
    public static class ProductoBussiness
    {
        public static Producto ObtenerProducto(int id)
        {
            return ProductoData.ObtenerProducto(id);
        }
        public static List<Producto> ListarPrductos()
        {
            return ProductoData.ListarPrductos();
        }
        public static bool CrearProducto(Producto producto)
        {
            return ProductoData.CrearProducto(producto);
        }
        public static bool ModificarProducto(int id, Producto producto)
        {
            return ProductoData.ModificarProducto(id, producto);
        }
        public static bool EliminarProducto(int id)
        {
            return ProductoData.EliminarProducto(id);
        }
    }
}
