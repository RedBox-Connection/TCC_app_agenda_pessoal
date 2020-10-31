using Microsoft.AspNetCore.Http;

namespace backend.Models.Request
{
    public class AlterarUsuarioRequest
    {
        public IFormFile FotoPerfil { get; set; }
        public string NomePerfil { get; set; }
        public string NomeUsuario { get; set; }
        public string Senha { get; set; }
        public string Email { get; set; }
        public bool ReceberEmail { get; set; }
    }
}