using System;
using System.Collections;
using System.Collections.Generic;

using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TimeController : ControllerBase
    {
        Business.TimeBusiness timeBsn = new Business.TimeBusiness();
        Business.TimeIntegranteBusiness timeIntegranteBsn = new Business.TimeIntegranteBusiness();
        Business.UsuarioBusiness usuarioBsn = new Business.UsuarioBusiness();
        Business.QuadroBusiness quadroBsn = new Business.QuadroBusiness();

        Utils.TimeConversor timeCnv = new Utils.TimeConversor();
        Utils.TimeIntegranteConversor timeIntegranteCnv = new Utils.TimeIntegranteConversor();
        Utils.QuadroConversor quadroCnv = new Utils.QuadroConversor();

        [HttpPost("cadastrar")]
        public async Task<ActionResult<Models.Response.CadastrarAlterarTimeResponse>> CadastrarTimeAsync(Models.Request.CadastrarAlterarTimeRequest req)
        {
            try
            {
                Models.TbUsuario tbUsuario = await usuarioBsn.ConsultarUsuarioPorIdLoginAsync(req.IdLogin);

                Models.TbQuadro tbQuadro = quadroCnv.ToTbQuadro(req, tbUsuario);

                tbQuadro = await quadroBsn.CadastrarQuadroAsync(tbQuadro);

                Models.TbTime tbTime = timeCnv.ToTbTime(req, tbQuadro);
                
                tbTime = await timeBsn.CadastrarTimeAsync(tbTime);

                tbTime = await timeBsn.SalvarLinkAsync(tbTime, tbTime);

                Models.TbTimeIntegrante timeIntegrante = timeIntegranteCnv.ToTbIntegrante(tbUsuario.IdUsuario, tbTime.IdTime);

                timeIntegrante = await timeIntegranteBsn.CadastrarTimeIntegranteAsync(timeIntegrante);

                Models.Response.CadastrarAlterarTimeResponse resp = timeCnv.ToTimeResponse(tbTime);

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

        [HttpGet("consultar/{idLogin}")]
        public async Task<ActionResult<Models.Response.ConsultarTimesResponse>> ConsultarTimesAsync(int idLogin)
        {
            try
            {
                Models.TbUsuario tbUsuario = await usuarioBsn.ConsultarUsuarioPorIdLoginAsync(idLogin);

                List<Models.TbTime> times = await timeBsn.ConsultarTimesPorIdUsuarioAsync(tbUsuario.IdUsuario);

                Models.Response.ConsultarTimesResponse resp = timeCnv.ToTimesReponse(times);

                return resp;
            }
            catch (Exception e)
            {
                return BadRequest(
                    new Models.Response.ErroResponse(
                        404, e.Message
                    )
                );
            }
        }

        [HttpPatch("alterar/{idTime}")]
        public async Task<ActionResult<Models.Response.CadastrarAlterarTimeResponse>> AlterarTimeAsync(int idTime, Models.Request.CadastrarAlterarTimeRequest req)
        {
            try
            {
                Models.TbTime tbTimeAntigo = await timeBsn.ConsultarTimePorIdTime(idTime);

                Models.TbQuadro tbQuadro = await quadroBsn.ConsultarQuadroPorIdQuadroAsync(tbTimeAntigo.IdQuadro);

                Models.TbTime tbTimeAtual = timeCnv.ToTbTime(req, tbQuadro);

                tbTimeAntigo = await timeBsn.AlterarTimeAsync(tbTimeAntigo, tbTimeAtual);

                Models.Response.CadastrarAlterarTimeResponse resp = timeCnv.ToTimeResponse(tbTimeAntigo);

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

        [HttpDelete("deletar/{idTime}")]
        public async Task<ActionResult<Models.Response.CadastrarAlterarTimeResponse>> DeletarTimeAsync(int idTime)
        {
            try
            {
                Models.TbTime tbTime = await timeBsn.ConsultarTimePorIdTime(idTime);

                Models.TbQuadro tbQuadro = await quadroBsn.ConsultarQuadroPorIdQuadroAsync(tbTime.IdQuadro);

                tbQuadro = await quadroBsn.DeletarQuadroAsync(tbQuadro);

                Models.Response.CadastrarAlterarTimeResponse resp = timeCnv.ToTimeResponse(tbTime);

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