using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace backend.Business
{
    public class GerenciadorFoto
    {
        public string GerarNovoNome(string nome)
        {
            string novoNome = Guid.NewGuid().ToString();
            novoNome = novoNome + Path.GetExtension(nome);
            return novoNome;
        }

        public async void SalvarFoto(string nome, IFormFile foto)
        {
            string caminhoFoto = Path.Combine(AppContext.BaseDirectory, "Storage", "Fotos", nome);

            using (FileStream fs = new FileStream(caminhoFoto, FileMode.Create))
            {
                await foto.CopyToAsync(fs);
            }
        }

        public async Task<byte[]> LerFoto(string nome)
        {
            string caminhoFoto = Path.Combine(AppContext.BaseDirectory, "Storage", "Fotos", nome);
            byte[] foto = await File.ReadAllBytesAsync(caminhoFoto);

            return foto;
        }

        public string GerarContentType(string nome)
        {
            string extensao = Path.GetExtension(nome).Replace(".", "");
            string contentType = "application/" + extensao;
            return contentType;
        }
    }
}