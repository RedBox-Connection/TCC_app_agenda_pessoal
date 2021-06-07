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
        Business.GerenciadorEmail gerenciadorEmail = new Business.GerenciadorEmail();
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

                gerenciadorEmail.EnviarEmailCadastroDeUsuario(tbLogin.DsEmail);

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
                Models.TbLogin tbLoginAtual = usuarioCnv.ToCadastrarTbLogin(req.Email, req.Senha);
                Models.TbLogin tbLoginAntigo = await usuarioBsn.ConsultarLoginPorEmailAsync(req.Email);

                tbLoginAntigo = await usuarioBsn.LoginAsync(tbLoginAtual);

                tbLoginAtual = await usuarioBsn.AtualizarLoginAsync(tbLoginAntigo, tbLoginAtual);

                Models.Response.LoginResponse resp = usuarioCnv.ToLoginResponse(tbLoginAtual);

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

        [HttpGet("foto/imagem/{idLogin}")]
        public async Task<ActionResult> BuscarFoto(int idLogin)
        {
            try 
            {
                Models.TbUsuario tbUsuario = await usuarioBsn.ConsultarUsuarioPorIdLoginAsync(idLogin);

                byte[] foto = await gerenciadorFoto.LerFoto(tbUsuario.DsFoto);
                string contentType = gerenciadorFoto.GerarContentType(tbUsuario.DsFoto);
                return File(foto, contentType);
            }
            catch (Exception ex)
            {
                return BadRequest(
                    new Models.Response.ErroResponse(404, ex.Message)
                );
            }
        }

        [HttpPatch("alterar/foto")]
        public async Task<ActionResult<Models.Response.AlterarFotoPerfilResponse>> AlterarFotoUsuarioAsync([FromForm] Models.Request.AlterarFotoPerfilRequest req)
        {
            try
            {
                Models.TbUsuario tbUsuarioAtual = await usuarioBsn.ConsultarUsuarioPorIdLoginAsync(req.IdLogin);
                Models.TbUsuario tbUsuarioNovo = await usuarioBsn.ConsultarUsuarioPorIdLoginAsync(req.IdLogin);
                tbUsuarioNovo.DsFoto = gerenciadorFoto.GerarNovoNome(req.FotoPerfil.FileName);

                tbUsuarioAtual = await usuarioBsn.AlterarFotoUsuarioAsync(tbUsuarioAtual, tbUsuarioNovo);

                gerenciadorFoto.SalvarFoto(tbUsuarioAtual.DsFoto, req.FotoPerfil);

                Models.Response.AlterarFotoPerfilResponse resp = usuarioCnv.ToAlterarFotoPerfilResponse(tbUsuarioAtual);

                return resp;
            }
            catch (Exception e)
            {
                return BadRequest(
                    new Models.Response.ErroResponse(400, e.Message)
                );
            }
        }

        [HttpPatch("alterar/info")]
        public async Task<ActionResult<Models.Response.AlterarUsuarioResponse>> AlterarUsuarioAsync(Models.Request.AlterarUsuarioRequest req)
        {
            try
            {
                esqueciSenhaBsn.ValidarSenhasIdenticas(req.Senha, req.ConfirmarSenha);

                Models.TbLogin tbLoginAtual = await usuarioBsn.ConsultarLoginPorEmailAsync(req.Email);
                Models.TbLogin tbLoginNovo = usuarioCnv.ToTbLogin(req);

                Models.TbUsuario tbUsuarioNovo = usuarioCnv.ToTbUsuario(req);
                Models.TbUsuario tbUsuarioAtual = await usuarioBsn.ConsultarUsuarioPorIdLoginAsync(tbLoginAtual.IdLogin);

                tbLoginAtual = await usuarioBsn.AlterarLoginAsync(tbLoginAtual, tbLoginNovo);
                tbUsuarioAtual = await usuarioBsn.AlterarUsuarioAsync(tbUsuarioAtual, tbUsuarioNovo);

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

        [HttpGet("consultar/{idLogin}")]
        public async Task<ActionResult<Models.Response.UsuarioResponse>> ConsultarUsuarioPorLoginAsync(int idLogin)
        {
            try
            {
                Models.TbUsuario tbUsuario = await usuarioBsn.ConsultarUsuarioPorIdLoginAsync(idLogin);

                Models.Response.UsuarioResponse resp = usuarioCnv.ToUsuarioResponse(tbUsuario);

                return resp;
            }
            catch (Exception ex)
            {
                return BadRequest(
                    new Models.Response.ErroResponse(400, ex.Message)
                );
            }
        }

        [HttpDelete("deletar/{idLogin}")]
        public async Task<ActionResult<Models.Response.DeletarLoginResponse>> DeletarLoginAsync(int idLogin)
        {
            try
            {
                Models.TbLogin tbLogin = await usuarioBsn.ConsultarLoginPorIdLogin(idLogin);

                tbLogin = await usuarioBsn.DeletarLoginAsync(tbLogin);

                Models.Response.DeletarLoginResponse resp = usuarioCnv.ToDeletarLoginResponse(tbLogin);

                return resp;
            }
            catch (Exception e)
            {
                return BadRequest(
                    new Models.Response.ErroResponse(
                        400, e.Message
                    )
                );
            }
        }
    }
}