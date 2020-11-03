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
        Business.GerenciadorEmail gerenciadorEmailBsn = new Business.GerenciadorEmail();
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

                gerenciadorEmailBsn.EnviarEmail(tb.DsEmail, tb.TmExpiracao, tb.NrCodigo);

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
        public async Task<ActionResult<Models.Response.ValidarCodigoRecuperacaoResponse>> ValidarCodigoAsync(Models.Request.ValidarCodigoRecuperacaoRequest req)
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

        [HttpDelete("recuperar-senha-deletar-tempo")]
        public async Task<ActionResult<Models.Response.DeletarCodigoRecuperacaoResponse>> DeletarRecuperacaoDeSenhaCodigoPorTempoAsync(Models.Request.DeletarCodigoRecuperacaoRequest req)
        {
            try
            {
                long codigo = esqueciSenhaCnv.ToCodigo(req);

                Models.TbEsqueciSenha tb = await esqueciSenhaBsn.ConsultarRecuperacaoDeSenhaPorCodigoAsync(codigo);

                tb = await esqueciSenhaBsn.DeletarRecuperacaoDeSenhaPorTempoAsync(tb);

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

        [HttpPut("recuperar-senha-deletar/{id}")]
        public async Task<ActionResult<Models.Response.CodigoRecuperacaoResponse>> AlterarSenhaDeletarCodigoAsync(int? id, Models.Request.NovaSenhaRequest req)
        {
            try{
                Models.TbLogin tbNovo = esqueciSenhaCnv.ToSenha(req);
                Models.TbLogin tbAtual = await esqueciSenhaBsn.ConsultarLoginPorIdAsync(id);
                Models.TbEsqueciSenha tbEsqueciSenha = await esqueciSenhaBsn.ConsultarTbEsqueciSenhaPorIdLoginAsync(tbAtual);

                tbAtual = await esqueciSenhaBsn.DeletarRecuperacaoDeSenhaAsync(tbNovo, tbAtual, tbEsqueciSenha);

                Models.Response.CodigoRecuperacaoResponse resp = esqueciSenhaCnv.ToEsqueciSenhaResponse(tbEsqueciSenha, tbAtual);

                return resp;
            }
            catch(Exception e)
            {
                return BadRequest(
                    new Models.Response.ErroResponse(400, e.Message)
                ); 
            }
        }
        
    }
}