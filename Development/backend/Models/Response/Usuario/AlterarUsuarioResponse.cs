namespace backend.Models.Response
{
    public class AlterarUsuarioResponse
    {
        public int IdLogin { get; set; }
        public string Foto { get; set; }
        public string NomePerfil { get; set; }
        public string NomeUsuario { get; set; }
        public string Senha { get; set; }
        public bool ReceberEmail { get; set; }
    }
}