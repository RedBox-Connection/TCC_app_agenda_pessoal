using System;
using System.Collections;
using System.Collections.Generic;

using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CartaoComentarioController : ControllerBase
    {
        Utils.CartaoComentarioConversor cartaoCnv = new Utils.CartaoComentarioConversor();
        Business.CartaoComentarioBusiness cartaoBsn = new Business.CartaoComentarioBusiness();

        [HttpPost("cadastrar-comentario")]
        public async Task<ActionResult<Models.Response.CartaoComentarioResponse>> CadastrarComentarioAsync(Models.Request.CartaoComentarioRequest req)
        {
            try
            {
                Models.TbCartaoComentario tbComentario = cartaoCnv.ToTbCartaoComentario(req);

                tbComentario = await cartaoBsn.AdicionarComentarioCartaoAsync(tbComentario);

                Models.Response.CartaoComentarioResponse resp = cartaoCnv.ToCartaoComentarioResponse(tbComentario);

                return resp;
            }
            catch (Exception e)
            {
                return BadRequest(
                    new Models.Response.ErroResponse(400, e.Message)
                );
            }
        }

        [HttpGet("consultar-comentario")]
        public async Task<ActionResult<Models.Response.CartaoesComentarioResponse>> ConsultarComentariosAsync(int idCartao)
        {
            try
            {
                List<Models.TbCartaoComentario> tbComentarios = await cartaoBsn.ConsutarComentarioPorIdCartaoAsync(idCartao);

                if(tbComentarios == null)
                    return NotFound();

                Models.Response.CartaoesComentarioResponse resps = cartaoCnv.ToCartaoComentarioListResponse(tbComentarios);

                return resps;
            }
            catch (Exception e)
            {
                return BadRequest(
                    new Models.Response.ErroResponse(404, e.Message)
                );
            }
        }

        [HttpPut("alterar-comentario")]
        public async Task<ActionResult<Models.Response.CartaoComentarioResponse>> AlterarComentarioAsync(int idLogin, Models.Request.CartaoComentarioRequest req)
        {
            Models.TbCartaoComentario tbComentarioAtual = await cartaoBsn.ConsutarComentarioPorIdLoginAsync(idLogin);

            if(tbComentarioAtual == null)
                return NotFound();

            Models.TbCartaoComentario tbComentarioNovo = cartaoCnv.ToTbCartaoComentario(req);

            tbComentarioAtual = await cartaoBsn.AlterarComentarioPorIdLoginAsync(idLogin, tbComentarioAtual, tbComentarioNovo);

            Models.Response.CartaoComentarioResponse resp = cartaoCnv.ToCartaoComentarioResponse(tbComentarioAtual);

            return resp;
        }

        [HttpDelete("deletar-comentario")]
        public async Task<ActionResult<Models.Response.CartaoComentarioResponse>> DeletarComentarioAsync(int idLogin, Models.Request.CartaoComentarioRequest req)
        {
            try
            {
                Models.TbCartaoComentario tbComentario = cartaoCnv.ToTbCartaoComentario(req);

                if(tbComentario == null)
                    return NotFound();

                tbComentario = await cartaoBsn.DeletarComentarioPorIdLoginAsync(idLogin, tbComentario);

                Models.Response.CartaoComentarioResponse resp = cartaoCnv.ToCartaoComentarioResponse(tbComentario);

                return resp;
            }
            catch (Exception e)
            {
                return BadRequest(
                    new Models.Response.ErroResponse(404, e.Message)
                );
            }
        }
    }
}