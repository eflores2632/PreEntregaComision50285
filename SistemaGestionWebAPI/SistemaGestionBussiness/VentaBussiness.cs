using SistemaGestionData;
using SistemaGestionEntities;

namespace SistemaGestionBussiness
{
    public static class VentaBussiness
    {
        public static Venta ObtenerVenta(int id)
        {
            return VentaData.ObtenerVenta(id);
        }
        public static List<Venta> ListarVentas()
        {
            return VentaData.ListarVentas();
        }
        public static bool CrearVenta(Venta venta)
        {
            return VentaData.CrearVenta(venta);
        }
        public static bool ModificarVenta(int id, Venta venta)
        {
            return VentaData.ModificarVenta(id, venta);
        }
        public static bool EliminarVenta(int id)
        {
            return VentaData.EliminarVenta(id);
        }
    }
}
