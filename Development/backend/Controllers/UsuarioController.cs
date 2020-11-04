using System;

using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        Business.UsuarioBusiness usuarioBsn = new Business.UsuarioBusiness();
        Utils.UsuarioConversor usuarioCnv = new Utils.UsuarioConversor();
        Business.QuadroBusiness quadroBsn = new Business.QuadroBusiness();
        Business.GerenciadorFoto gerenciadorFoto = new Business.GerenciadorFoto();
        Business.EsqueciSenhaBusiness esqueciSenhaBsn = new Business.EsqueciSenhaBusiness();

        [HttpPost("cadastrar")]
        public async Task<ActionResult<Models.Response.LoginResponse>> CadastrarUsuarioAsync(Models.Request.CadastrarUsuarioRequest req)
        {
            try
            {
                esqueciSenhaBsn.ValidarSenhasIdenticas(req.Senha, req.ConfirmarSenha);

                Models.TbLogin tbLogin = usuarioCnv.ToCadastrarTbLogin(req.Email, req.Senha);

                Models.TbUsuario tbUsuario = usuarioCnv.ToCadastrarTbUsuario(req.NomeUsuario, req.NomeCompleto);

                bool ignoreValidation = await usuarioBsn.ValidarCadastroUsuarioLogin(tbUsuario, tbLogin);

                tbLogin = await usuarioBsn.CadastrarLoginAsync(tbLogin);

                tbUsuario = await usuarioBsn.CadastrarUsuarioAsync(tbUsuario);

                tbUsuario = await usuarioBsn.CadastrarUsuarioLoginAsync(tbUsuario, tbLogin.IdLogin);

                Models.TbQuadro tbQuadro = usuarioCnv.ToTbQuadro(tbUsuario.IdUsuario);

                tbQuadro = await quadroBsn.CadastrarQuadroAsync(tbQuadro);

                Models.Response.LoginResponse resp = usuarioCnv.ToLoginResponse(tbLogin, tbUsuario.NmUsuario);

                return resp;
            }
            catch (Exception e)
            {
                return BadRequest(
                    new Models.Response.ErroResponse(400, e.Message)
                );
            }
        }

        [HttpPost("login")]
        public async Task<ActionResult<Models.Response.LoginResponse>> LoginAsync(Models.Request.LoginRequest req)
        {
            try
            {
                Models.TbLogin tbLogin = usuarioCnv.ToCadastrarTbLogin(req.Email, req.Senha);

                tbLogin = await usuarioBsn.LoginAsync(tbLogin);

                Models.Response.LoginResponse resp = usuarioCnv.ToLoginResponse(tbLogin);

                return resp;
            }
            catch(Exception ex)
            {
                return BadRequest(
                    new Models.Response.ErroResponse(400, ex.Message)
                );
            }
        }

        [HttpPost("adicionar-foto")]
        public async Task<ActionResult<Models.Response.SalvarFotoPerfilResponse>> AdicionarFotoPerfil(Models.Request.SalvarFotoPerfilRequest req)
        {
            try
            {
                Models.TbUsuario tb = new Models.TbUsuario();
                tb.DsFoto = gerenciadorFoto.GerarNovoNome(req.Foto.FileName);

                await usuarioBsn.CadastrarUsuarioAsync(tb);

                gerenciadorFoto.SalvarFoto(tb.DsFoto, req.Foto);

                Models.Response.SalvarFotoPerfilResponse resp = usuarioCnv.ToFotoResponse(tb);

                return resp;
            }
            catch (Exception ex)
            {
                return BadRequest(
                    new Models.Response.ErroResponse(400, ex.Message)
                );
            }
        }

        [HttpGet("foto/{nome}")]
        public async Task<ActionResult> BuscarFoto(string nome)
        {
            try 
            {
                byte[] foto = await gerenciadorFoto.LerFoto(nome);
                string contentType = gerenciadorFoto.GerarContentType(nome);
                return File(foto, contentType);
            }
            catch (System.Exception ex)
            {
                return BadRequest(
                    new Models.Response.ErroResponse(404, ex.Message)
                );
            }
        }

        [HttpPut("alterar")]
        public async Task<ActionResult<Models.Response.AlterarUsuarioResponse>> AlterarUsuarioAsync([FromForm] Models.Request.AlterarUsuarioRequest req)
        {
            try
            {
                Models.TbLogin tbLoginAtual = await usuarioBsn.ConsultarLoginPorEmailAsync(req.Email);
                Models.TbLogin tbLoginNovo = usuarioCnv.ToTbLogin(req);

                Models.TbUsuario tbUsuarioNovo = usuarioCnv.ToTbUsuario(req);
                tbUsuarioNovo.DsFoto = gerenciadorFoto.GerarNovoNome(req.FotoPerfil.FileName);
                Models.TbUsuario tbUsuarioAtual = await usuarioBsn.ConsultarUsuarioPorIdLoginAsync(tbLoginAtual.IdLogin);

                tbLoginAtual = await usuarioBsn.AlterarLoginAsync(tbLoginAtual, tbLoginNovo);
                tbUsuarioAtual = await usuarioBsn.AlterarUsuarioAsync(tbUsuarioAtual, tbUsuarioNovo);

                gerenciadorFoto.SalvarFoto(tbUsuarioAtual.DsFoto, req.FotoPerfil);

                Models.Response.AlterarUsuarioResponse resp = usuarioCnv.ToAlterarUsuarioResponse(tbLoginAtual, tbUsuarioAtual);
                
                return resp;
            }
            catch (Exception e)
            {
                return BadRequest(
                    new Models.Response.ErroResponse(400, e.Message)
                );
            }
        }
    }
}