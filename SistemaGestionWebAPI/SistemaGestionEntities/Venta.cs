namespace SistemaGestionEntities
{

    public class Venta
    {
        private int id;
        private string comentarios;
        private int idUsuario;

        public Venta(string comentarios, int idUsuario)
        {
            this.comentarios = comentarios;
            this.idUsuario = idUsuario;
        }
        public Venta(int id, string comentarios, int idUsuario)
        {
            this.id = id;
        }
        public int Id { get => id; set => id = value; }
        public string Comentarios { get => comentarios; set => comentarios = value; }
        public int IdUsuario { get => idUsuario; set => idUsuario = value; }
    }
}