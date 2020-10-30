using System;
using Microsoft.AspNetCore.Http;

namespace backend.Models.Request
{
    public class SalvarFotoPerfilRequest
    {
        public IFormFile Foto { get; set; }
    }
}