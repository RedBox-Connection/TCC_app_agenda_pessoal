using System;
using System.Collections;
using System.Collections.Generic;

using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TimeIntegranteController : ControllerBase
    {
        Utils.TimeIntegranteConversor integranteCnv = new Utils.TimeIntegranteConversor();
        
        Business.TimeIntegranteBusiness integranteBsn = new Business.TimeIntegranteBusiness();

        [HttpPost("cadastrar")]
        public async Task<ActionResult<Models.Response.TimeIntegranteResponse>> CadastrarIntegranteAsync(Models.Request.TimeIntegranteRequest req)
        {
            try
            {
                Models.TbTimeIntegrante integrante = integranteCnv.ToTbIntegrante(req);

                integrante = await integranteBsn.CadastrarTimeIntegranteAsync(integrante);

                Models.Response.TimeIntegranteResponse resp = integranteCnv.ToIntegranteResponse(integrante);

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

        [HttpGet("consultar/{idTime}")]
        public async Task<ActionResult<Models.Response.TimeIntegrantesResponse>> ConsultarIntegrantesPorIdTimeAsync(int idTime)
        {
            try
            {
                List<Models.TbTimeIntegrante> integrantes = await integranteBsn.ConsultarTimeIntegrantesPorIdTimeAsync(idTime);

                if(integrantes == null)
                    return NotFound();

                Models.Response.TimeIntegrantesResponse resp = integranteCnv.ToIntegranteResponse(integrantes);

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

        [HttpPut("alterar/{idIntegrante}")]
        public async Task<ActionResult<Models.Response.TimeIntegranteResponse>> AlterarIntegranteAsync(int idIntegrante, Models.Request.TimeIntegranteRequest req)
        {
            try
            {
                Models.TbTimeIntegrante integranteAntigo = await integranteBsn.ConsultarIntegrantePorIdIntegrante(idIntegrante);

                Models.TbTimeIntegrante integranteAtual = integranteCnv.ToTbIntegrante(req);

                integranteAntigo = await integranteBsn.AlterarTimeIntegrantesAsync(integranteAntigo, integranteAtual);

                Models.Response.TimeIntegranteResponse resp = integranteCnv.ToIntegranteResponse(integranteAntigo);

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

        [HttpDelete("deletar/{idIntegrante}")]
        public async Task<ActionResult<Models.Response.TimeIntegranteResponse>> DeletarIntegranteAsync(int idIntegrante)
        {
            try
            {
                Models.TbTimeIntegrante integrante = await integranteBsn.ConsultarIntegrantePorIdIntegrante(idIntegrante);

                integrante = await integranteBsn.DeletarTimeIntegranteAsync(integrante);

                Models.Response.TimeIntegranteResponse resp = integranteCnv.ToIntegranteResponse(integrante);

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