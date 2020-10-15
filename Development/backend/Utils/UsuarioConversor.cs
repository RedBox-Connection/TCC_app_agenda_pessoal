using System;

namespace backend.Utils
{
    public class UsuarioConversor
    {
        public Models.TbLogin ToCadastrarTbLogin(string email, string senha)
        {
            Models.TbLogin resp = new Models.TbLogin();

            resp.DsEmail = email;
            resp.DsSenha = senha;
            resp.DtUltLogin = DateTime.Now;
            
            return resp;
        }

        public Models.TbUsuario ToCadastrarTbUsuario(string nomeCompleto, int idLogin)
        {
            Models.TbUsuario resp = new Models.TbUsuario();

            resp.BtReceberEmail = true;
            resp.DsFoto = "user.png";
            resp.IdLogin = idLogin;
            resp.NmUsuario = nomeCompleto;

            return resp;
        }

        public Models.TbLogin ToTbLogin(Models.Request.LoginRequest req)
        {
            Models.TbLogin tb = new Models.TbLogin();
            tb.DsEmail = req.Email;
            tb.DsSenha = req.Senha;

            return tb;
        }

        public Models.Response.LoginResponse ToLoginResponse(Models.TbLogin tb, string nomeCompleto)
        {
            Models.Response.LoginResponse resp = new Models.Response.LoginResponse();

            resp.IdLogin = tb.IdLogin;

            int espaco = nomeCompleto.IndexOf(' ');
            resp.Nome = nomeCompleto.Substring(0, espaco);

            return resp;
        }
    }
}