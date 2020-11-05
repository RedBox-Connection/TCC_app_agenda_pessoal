namespace backend.Models.Request
{
    public class AlterarUsuarioRequest
    {
        public string NomePerfil { get; set; }
        public string NomeUsuario { get; set; }
        public string Senha { get; set; }
        public string ConfirmarSenha { get; set; }
        public string Email { get; set; }
        public bool ReceberEmail { get; set; }
    }
}