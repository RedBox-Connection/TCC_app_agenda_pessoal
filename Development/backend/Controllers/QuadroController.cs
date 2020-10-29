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
    public class QuadroController : ControllerBase
    {
        Utils.QuadroConversor quadroCnv = new Utils.QuadroConversor();
        Business.QuadroBusiness quadroBsn = new Business.QuadroBusiness();
        
        [HttpPost("cadastrar")]
        public async Task<ActionResult<Models.Response.QuadroResponse>> CadastrarQuadroAsync(Models.Request.CadastrarAlterarQuadroRequest req)
        {
            try
            {
                Models.TbQuadro tbQuadro =  quadroCnv.ToTbQuadro(req);

                tbQuadro = await quadroBsn.CadastrarQuadroAsync(tbQuadro);

                Models.Response.QuadroResponse resp = quadroCnv.ToQuadroResponse(tbQuadro);

                return resp;
            }
            catch (Exception e)
            {
                return BadRequest(
                    new Models.Response.ErroResponse(400, e.Message)
                );
            }
        }

        [HttpGet("consultar/{idUsuario}")]
        public async Task<ActionResult<Models.Response.ConsultarQuadrosResponse>> ConsultarQuadrosResponse(int idUsuario)
        {
            try
            {
                List<Models.TbQuadro> tbQuadros = await quadroBsn.ConsultarQuadrosPorIdUsuarioAsync(idUsuario);

                if(tbQuadros == null)
                    return NotFound();

                Models.Response.ConsultarQuadrosResponse resp = quadroCnv.ToQuadrosResponse(tbQuadros);

                return resp;
            }
            catch (Exception e)
            {
                return BadRequest(
                    new Models.Response.ErroResponse(400, e.Message)
                );
            }
        }

        [HttpPut("alterar/{idQuadro}")]
        public async Task<ActionResult<Models.Response.QuadroResponse>> AlterarQuadroAsync(int idQuadro, Models.Request.CadastrarAlterarQuadroRequest req)
        {
            try
            {
                Models.TbQuadro tbQuadroAtual = await quadroBsn.ConsultarQuadroPorIdQuadroAsync(idQuadro);

                Models.TbQuadro tbQuadroNovo = quadroCnv.ToTbQuadro(req);

                tbQuadroAtual = await quadroBsn.AlterarQuadroAsync(tbQuadroAtual, tbQuadroNovo);

                Models.Response.QuadroResponse resp = quadroCnv.ToQuadroResponse(tbQuadroAtual);

                return resp;
            }
            catch (Exception e)
            {
                return BadRequest(
                    new Models.Response.ErroResponse(400, e.Message)
                );
            }
        }

        [HttpDelete("deletar/{idQuadro}")]
        public async Task<ActionResult<Models.Response.QuadroResponse>> DeletarQuadroAsync(int idQuadro)
        {
            try
            {
                Models.TbQuadro tbQuadro = await quadroBsn.ConsultarQuadroPorIdQuadroAsync(idQuadro);

                tbQuadro = await quadroBsn.DeletarQuadroAsync(tbQuadro);

                Models.Response.QuadroResponse resp = quadroCnv.ToQuadroResponse(tbQuadro);

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