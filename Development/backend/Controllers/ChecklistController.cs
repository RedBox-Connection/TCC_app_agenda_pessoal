using System;
using System.Collections;
using System.Collections.Generic;

using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChecklistController : ControllerBase
    {
        Business.ChecklistBusiness checklistBsn = new Business.ChecklistBusiness();
        Business.UsuarioBusiness usuarioBsn = new Business.UsuarioBusiness();
        Business.CartaoTarefaBusiness cartaoBsn = new Business.CartaoTarefaBusiness();

        Utils.ChecklistConversor checklistCnv = new Utils.ChecklistConversor();
        Utils.CartaoUsuarioConversor cartaoCnv = new Utils.CartaoUsuarioConversor();

        [HttpPost("adicionar-checklist")]
        public async Task<ActionResult<Models.Response.ChecklistResponse>> AdicionarChecklistAsync(Models.Request.ChecklistRequest req)
        {
            try
            {
                Models.TbUsuario tbUsuario = await usuarioBsn.ConsultarUsuarioPorIdLoginAsync(req.IdLogin);

                Models.TbCartao tbCartao = cartaoCnv.ToTbCartaoCheck(req, tbUsuario);

                tbCartao = await cartaoBsn.CadastrarCartaoTarefaAsync(tbCartao);

                Models.TbChecklist tbChecklist = checklistCnv.ToTbChecklist(req, tbCartao);

                tbChecklist = await checklistBsn.AdicionarChecklistAsync(tbChecklist);

                Models.Response.ChecklistResponse resp = checklistCnv.ToChecklistResponse(tbChecklist);

                return resp;
            }
            catch (Exception e)
            {
                return BadRequest(
                    new Models.Response.ErroResponse(400, e.Message)
                );
            }
        }

        [HttpGet("consultar-checklist/{idLogin}")]
        public async Task<ActionResult<Models.Response.ChecklistsResponse>> ConsultarChecklistsAsync(int idLogin)
        {
            try
            {
                Models.TbUsuario tbUsuario = await usuarioBsn.ConsultarUsuarioPorIdLoginAsync(idLogin);

                List<Models.TbChecklist> checklists = await checklistBsn.ConsultarChecklistsPorIdUsuarioAsync(tbUsuario.IdUsuario);

                Models.Response.ChecklistsResponse resps = checklistCnv.ToChecklistsResponse(checklists);

                return resps;
            }
            catch(Exception e)
            {
                return BadRequest(
                    new Models.Response.ErroResponse(404, e.Message)
                );
            }
        }

        [HttpPut("alterar-checklist/{idChecklist}")]
        public async Task<ActionResult<Models.Response.ChecklistResponse>> AlterarChecklistAsync(int idChecklist, Models.Request.ChecklistRequest req)
        {
            try
            {
                Models.TbChecklist tbChecklistAtual = await checklistBsn.ConsultarChecklistPorIdAsync(idChecklist);

                Models.TbCartao tbCartao = await cartaoBsn.ConsultarCartaoTarefaPorIdAsync(tbChecklistAtual.IdCartao);

                Models.TbChecklist tbChecklistNovo = checklistCnv.ToTbChecklist(req, tbCartao);

                tbChecklistAtual = await checklistBsn.AlterarChecklistAsync(tbChecklistAtual, tbChecklistNovo);

                Models.Response.ChecklistResponse resp = checklistCnv.ToChecklistResponse(tbChecklistAtual);

                return resp;
            }
            catch (Exception e)
            {
                return BadRequest(
                    new Models.Response.ErroResponse(400, e.Message)
                );
            }
        }

        [HttpDelete("deletar-checklits/{idChecklist}")]
        public async Task<ActionResult<Models.Response.ChecklistResponse>> DeletarChecklistAsync(int idChecklist)
        {
            try
            {
                Models.TbChecklist tbChecklist = await checklistBsn.ConsultarChecklistPorIdAsync(idChecklist);

                tbChecklist = await checklistBsn.DeletarChecklistAsync(tbChecklist);

                Models.Response.ChecklistResponse resp = checklistCnv.ToChecklistResponse(tbChecklist);

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