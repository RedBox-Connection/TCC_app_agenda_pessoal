namespace backend.Models.Request
{
    public class CartaoComentarioRequest
    {
        public string Comentario { get; set; }
        public int IdCartao { get; set; }
        public int IdUsuario { get; set; }
    }
}