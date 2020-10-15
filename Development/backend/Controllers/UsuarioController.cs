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

        [HttpPost]
        public async Task<ActionResult<Models.Response.LoginResponse>> CadastrarUsuarioAsync(Models.Request.CadastrarUsuarioRequest req)
        {
            try
            {
                Models.TbLogin tbLogin = usuarioCnv.ToCadastrarTbLogin(req.Email, req.Senha);

                tbLogin = await usuarioBsn.CadastrarLoginAsync(tbLogin);

                Models.TbUsuario tbUsuario = usuarioCnv.ToCadastrarTbUsuario(req.NomeCompleto, tbLogin.IdLogin);

                tbUsuario = await usuarioBsn.CadastrarUsuarioAsync(tbUsuario);

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
    }
}