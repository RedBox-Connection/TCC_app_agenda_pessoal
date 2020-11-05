using Microsoft.AspNetCore.Http;

namespace backend.Models.Request
{
    public class AlterarFotoPerfilRequest
    {
        public int IdLogin { get; set; }
        public IFormFile FotoPerfil { get; set; }
    }
}