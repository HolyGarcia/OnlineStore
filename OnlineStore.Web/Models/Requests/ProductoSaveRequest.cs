namespace OnlineStore.Web.Models.Requests
{
    public class ProductoSaveRequest
    {
        public int productoId { get; set; }
        public int idUsuario { get; set; }
        public DateTime fecha { get; set; }
        public string? marca { get; set; }
        public string? descripcion { get; set; }

        public int stock { get; set; }
        public string? urlImagen { get; set; }
        public string? nombreImagen { get; set; }
        public decimal precio { get; set; }
    }
}
