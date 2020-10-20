using System;

using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EsqueciSenhaController : ControllerBase
    {
        Database.GerenciadorEmail gerenciadorEmailDb = new Database.GerenciadorEmail();
        Business.EsqueciSenhaBusiness esqueciSenhaBsn = new Business.EsqueciSenhaBusiness();
        Utils.EsqueciSenhaConversor esqueciSenhaCnv = new Utils.EsqueciSenhaConversor();
        Business.UsuarioBusiness usuarioBsn = new Business.UsuarioBusiness();

        [HttpPost("recuperar-senha-email")]
        public async Task<ActionResult<Models.Response.CodigoRecuperacaoResponse>> GerarCodigoAsync(Models.Request.CodigoRecupecaoRequest req)
        {
            try
            {
                long codigo = esqueciSenhaBsn.GerarCodigoRecuperacao();

                Models.TbLogin usuario = await usuarioBsn.ConsultarLoginPorEmailAsync(req.Email);

                Models.TbEsqueciSenha tb = esqueciSenhaCnv.ToTbEsqueciSenha(codigo, usuario, req.Email);

                tb = await esqueciSenhaBsn.SalvarCodigoRecuperacaoAsync(tb);

                gerenciadorEmailDb.EnviarEmail(tb.DsEmailAlternativo, tb.TmExpiracao, tb.NrCodigo);

                Models.Response.CodigoRecuperacaoResponse resp = esqueciSenhaCnv.ToEsqueciSenhaResponse(tb, usuario);

                return resp;
            }
            catch (Exception e)
            {
                return BadRequest(
                    new Models.Response.ErroResponse(400, e.Message)
                );
            }
        }

        [HttpPut("recuperar-senha-codigo")]
        public async Task<ActionResult<Models.Response.ValidarCodigoRecuperacaoResponse>> GerarCodigoAsync(Models.Request.ValidarCodigoRecuperacaoRequest req)
        {
            try
            {
                long codigo = esqueciSenhaCnv.ToCodigo(req);
                
                Models.TbEsqueciSenha tb = await esqueciSenhaBsn.ConsultarRecuperacaoDeSenhaPorCodigoAsync(codigo);

                Models.Response.ValidarCodigoRecuperacaoResponse resp = esqueciSenhaCnv.ToValidarEsqueciSenhaResponse(tb);

                return resp;
            }
            catch(Exception ex)
            {
                return BadRequest(
                    new Models.Response.ErroResponse(400, ex.Message)
                );
            }
        }

        [HttpDelete("recuperar-senha-deletar")]
        public async Task<ActionResult<Models.Response.DeletarCodigoRecuperacaoResponse>> DeletarRecuperacaoDeSenhaCodigoAsync(Models.Request.DeletarCodigoRecuperacaoRequest req)
        {
            try
            {
                long codigo = esqueciSenhaCnv.ToCodigo(req);

                Models.TbEsqueciSenha tb = await esqueciSenhaBsn.ConsultarRecuperacaoDeSenhaPorCodigoAsync(codigo);

                tb = await esqueciSenhaBsn.DeletarRecuperacaoDeSenhaAsync(tb);

                Models.Response.DeletarCodigoRecuperacaoResponse resp = esqueciSenhaCnv.ToDeletarEsqueciSenhaResponse(tb);

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