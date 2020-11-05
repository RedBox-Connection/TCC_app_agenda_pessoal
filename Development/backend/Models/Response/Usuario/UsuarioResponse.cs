namespace backend.Models.Response
{
    public class UsuarioResponse
    {
        public string NomePerfil { get; set; }
        public string NomeUsuario { get; set; }
        public string Senha { get; set; }
        public string Email { get; set; }
        public bool ReceberEmail { get; set; }
        public string FotoPerfil { get; set; }
    }
}