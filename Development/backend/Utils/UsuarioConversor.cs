using System;
using System.Linq;

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

        public Models.TbUsuario ToCadastrarTbUsuario(string nomeUsuario, string nomeCompleto, int idLogin)
        {
            Models.TbUsuario resp = new Models.TbUsuario();

            resp.BtReceberEmail = true;
            resp.DsFoto = "user.png";
            resp.IdLogin = idLogin;
            resp.NmUsuario = nomeUsuario;
            resp.NmPerfil = nomeCompleto;

            return resp;
        }

        public Models.TbLogin ToTbLogin(Models.Request.LoginRequest req)
        {
            Models.TbLogin tb = new Models.TbLogin();
            tb.DsEmail = req.Email;
            tb.DsSenha = req.Senha;
            tb.DtUltLogin = DateTime.Now;

            return tb;
        }

        public Models.TbQuadro ToTbQuadro(int idUsuario)
        {
            Models.TbQuadro resp = new Models.TbQuadro();

            resp.IdUsuario = idUsuario;
            resp.NmQuadro = "Meu 1º quadro";

            return resp;
        }

        public Models.Response.LoginResponse ToLoginResponse(Models.TbLogin tb, string nomeUsuario)
        {
            Models.Response.LoginResponse resp = new Models.Response.LoginResponse();

            resp.IdLogin = tb.IdLogin;
            resp.NomeUsuario = nomeUsuario;

            return resp;
        }

         public Models.Response.LoginResponse ToLoginResponse(Models.TbLogin tb)
        {
            Models.Response.LoginResponse resp = new Models.Response.LoginResponse();

            resp.IdLogin = tb.IdLogin;
            resp.NomeUsuario = tb.TbUsuario.FirstOrDefault().NmUsuario;            

            return resp;
        }

    }
}