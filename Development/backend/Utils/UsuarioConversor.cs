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

        public Models.TbUsuario ToCadastrarTbUsuario(string nomeUsuario, string nomeCompleto)
        {
            Models.TbUsuario resp = new Models.TbUsuario();

            resp.BtReceberEmail = true;
            resp.DsFoto = "user.png";
            resp.IdLogin = 1;
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

        public Models.Response.SalvarFotoPerfilResponse ToFotoResponse(Models.TbUsuario tb)
        {
            Models.Response.SalvarFotoPerfilResponse resp = new Models.Response.SalvarFotoPerfilResponse();

            resp.Foto = tb.DsFoto;
            resp.Nome = tb.NmUsuario;

            return resp;
        }

        public Models.TbLogin ToTbLogin(Models.Request.AlterarUsuarioRequest req)
        {
            Models.TbLogin resp = new Models.TbLogin();

            resp.DsEmail = req.Email;
            resp.DsSenha = req.Senha;
            resp.DtUltLogin = DateTime.Now;

            return resp;
        }

        public Models.Response.AlterarUsuarioResponse ToAlterarUsuarioResponse(Models.TbLogin tbLogin, Models.TbUsuario tbUsuario)
        {
            Models.Response.AlterarUsuarioResponse resp = new Models.Response.AlterarUsuarioResponse();

            resp.Senha = tbLogin.DsSenha;
            resp.ReceberEmail = tbUsuario.BtReceberEmail;
            resp.NomeUsuario = tbUsuario.NmUsuario;
            resp.NomePerfil = tbUsuario.NmPerfil;
            resp.IdLogin = tbLogin.IdLogin;
            resp.Foto = tbUsuario.DsFoto;

            return resp;
        }

        public Models.TbUsuario ToTbUsuario(Models.Request.AlterarUsuarioRequest req)
        {
            Models.TbUsuario resp = new Models.TbUsuario();
            
            resp.DsFoto = "user.png";
            resp.NmUsuario = req.NomeUsuario;
            resp.NmPerfil = req.NomePerfil;
            resp.BtReceberEmail = req.ReceberEmail;

            return resp;
        }

        public Models.Response.UsuarioResponse ToUsuarioResponse(Models.TbUsuario req)
        {
            Models.Response.UsuarioResponse resp = new Models.Response.UsuarioResponse();

            resp.Email = req.IdLoginNavigation.DsEmail;
            resp.NomePerfil = req.NmPerfil;
            resp.NomeUsuario = req.NmUsuario;
            resp.ReceberEmail = req.BtReceberEmail;
            resp.Senha = req.IdLoginNavigation.DsSenha;
            resp.FotoPerfil = req.DsFoto;

            return resp;
        }
    }
}