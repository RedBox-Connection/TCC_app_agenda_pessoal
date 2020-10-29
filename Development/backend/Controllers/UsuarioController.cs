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

        [HttpPost("cadastrar")]
        public async Task<ActionResult<Models.Response.LoginResponse>> CadastrarUsuarioAsync(Models.Request.CadastrarUsuarioRequest req)
        {
            try
            {
                Models.TbLogin tbLogin = usuarioCnv.ToCadastrarTbLogin(req.Email, req.Senha);

                tbLogin = await usuarioBsn.CadastrarLoginAsync(tbLogin);

                Models.TbUsuario tbUsuario = usuarioCnv.ToCadastrarTbUsuario(req.NomeUsuario, req.NomeCompleto, tbLogin.IdLogin);

                tbUsuario = await usuarioBsn.CadastrarUsuarioAsync(tbUsuario);

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
    }
}