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
    public class CartaoTarefaController : ControllerBase
    {
        Utils.CartaoUsuarioConversor cartaoCnv = new Utils.CartaoUsuarioConversor();
        Business.CartaoTarefaBusiness cartaoBsn = new Business.CartaoTarefaBusiness();

        [HttpPost("cadastrar-cartao-tarefa")]
        public async Task<ActionResult<Models.Response.CartaoTarefaResponse>> CadastrarCartaoTarefaAsync(Models.Request.CadastrarCartaoTarefaRequest req)
        {
            try
            {
                Models.TbCartao tbCartao = cartaoCnv.ToTbCartao(req);

                tbCartao = await cartaoBsn.CadastrarCartaoTarefaAsync(tbCartao);

                Models.Response.CartaoTarefaResponse resp = cartaoCnv.ToCartaoTarefaResponse(tbCartao);

                return resp;
            }
            catch (Exception e)
            {
                return BadRequest(
                    new Models.Response.ErroResponse(400, e.Message)
                );
            }
        }

        [HttpGet("consultar-cartoes-tarefa")]
        public async Task<ActionResult<Models.Response.CartoesTarefasResponse>> ConsultarCartoesTarefasAsync(int idQuadro)
        {
            try
            {
                List<Models.TbCartao> tbCartoes = await cartaoBsn.ConsultarCartoesTarefaAsync(idQuadro);

                if(tbCartoes == null)
                    return NotFound();

                Models.Response.CartoesTarefasResponse resp = cartaoCnv.ToCartaoTarefaListResponse(tbCartoes);

                return resp;
            }
            catch (Exception e)
            {
                return BadRequest(
                    new Models.Response.ErroResponse(400, e.Message)
                );
            }
        }

        [HttpPut("alterar-cartao-tarefa")]
        public async Task<ActionResult<Models.Response.CartaoTarefaResponse>> AlterarCartaoTarefaAsync(Models.Request.AlterarCartaoTarefaRequest req)
        {
            try
            {
                Models.TbCartao tbCartaoAtual = await cartaoBsn.ConsultarCartaoTarefaPorIdAsync(req.IdCartao);

                if(tbCartaoAtual == null)
                    return NotFound();

                Models.TbCartao tbCartaoNovo = cartaoCnv.ToTbCartao(req);

                tbCartaoAtual = await cartaoBsn.AlterarCartaoTarefaAsync(tbCartaoAtual, tbCartaoNovo);

                Models.Response.CartaoTarefaResponse resp = cartaoCnv.ToCartaoTarefaResponse(tbCartaoAtual);

                return resp;
            }
            catch (Exception e)
            {
                return BadRequest(
                    new Models.Response.ErroResponse(400, e.Message)
                );
            }
        }

        [HttpDelete("deletar-cartao-tarefa")]
        public async Task<ActionResult<Models.Response.CartaoTarefaResponse>> DeletarCartaoTarefaAsync(Models.Request.DeletarCartaoTarefaRequest req)
        {
            try
            {
                Models.TbCartao tbCartao = await cartaoBsn.ConsultarCartaoTarefaPorIdAsync(req.IdCartao);

                if(tbCartao == null)
                    return NotFound();

                tbCartao = await cartaoBsn.DeletarCartaoTarefaAsync(tbCartao);

                Models.Response.CartaoTarefaResponse resp = cartaoCnv.ToCartaoTarefaResponse(tbCartao);

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