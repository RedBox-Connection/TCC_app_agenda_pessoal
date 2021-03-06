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
        Business.UsuarioBusiness usuarioBsn = new Business.UsuarioBusiness();
        
        [HttpPost("cadastrar")]
        public async Task<ActionResult<Models.Response.QuadroResponse>> CadastrarQuadroAsync(Models.Request.CadastrarAlterarQuadroRequest req)
        {
            try
            {
                Models.TbUsuario tbUsuario = await usuarioBsn.ConsultarUsuarioPorIdLoginAsync(req.IdLogin);

                Models.TbQuadro tbQuadro =  quadroCnv.ToTbQuadro(req, tbUsuario);

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

        [HttpGet("consultar/{idLogin}")]
        public async Task<ActionResult<Models.Response.ConsultarQuadrosResponse>> ConsultarQuadrosAsync(int idLogin)
        {
            try
            {
                Models.TbUsuario tbUsuario = await usuarioBsn.ConsultarUsuarioPorIdLoginAsync(idLogin);

                List<Models.TbQuadro> tbQuadros = await quadroBsn.ConsultarQuadrosPorIdUsuarioAsync(tbUsuario.IdUsuario);

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

        [HttpGet("consultarQuadro/{idQuadro}")]
        public async Task<ActionResult<Models.Response.QuadroResponse>> ConsultarQuadroAsync(int idQuadro)
        {
            try
            {
                Models.TbQuadro tbQuadro = await quadroBsn.ConsultarQuadroPorIdQuadroAsync(idQuadro);

                if(tbQuadro == null)
                    return NotFound();

                Models.Response.QuadroResponse resp = quadroCnv.ToQuadroResponse(tbQuadro);

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

        [HttpPut("alterar/{idQuadro}")]
        public async Task<ActionResult<Models.Response.QuadroResponse>> AlterarQuadroAsync(int idQuadro, Models.Request.CadastrarAlterarQuadroRequest req)
        {
            try
            {
                Models.TbQuadro tbQuadroAtual = await quadroBsn.ConsultarQuadroPorIdQuadroAsync(idQuadro);

                Models.TbUsuario tbUsuario = await usuarioBsn.ConsultarUsuarioPorIdLoginAsync(req.IdLogin);

                Models.TbQuadro tbQuadroNovo = quadroCnv.ToTbQuadro(req, tbUsuario);

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