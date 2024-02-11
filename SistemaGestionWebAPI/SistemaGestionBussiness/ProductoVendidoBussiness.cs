using SistemaGestionData;
using SistemaGestionEntities;

namespace SistemaGestionBussiness
{
    public static class ProductoVendidoBussiness
    {
        public static ProductoVendido ObtenerProductoVendido(int id)
        {
            return ProductoVendidoData.ObtenerProductoVendido(id);
        }
        public static List<ProductoVendido> ListarPrductosVendidos()
        {
            return ProductoVendidoData.ListarPrductosVendidos();
        }
        public static bool CrearProductoVendido(ProductoVendido productovendido)
        {
            return ProductoVendidoData.CrearProductoVendido(productovendido);
        }
        public static bool ModificarProducto(int id, ProductoVendido productovendido)
        {
            return ProductoVendidoData.ModificarProducto(id, productovendido);
        }
        public static bool EliminarProducto(int id)
        {
            return ProductoVendidoData.EliminarProducto(id); s
        }
    }
}
