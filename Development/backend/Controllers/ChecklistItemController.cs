using System;
using System.Collections;
using System.Collections.Generic;

using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChecklistItemController : ControllerBase
    {
        Business.ChecklistItemBusiness checklistItemBsn = new Business.ChecklistItemBusiness();
        Business.UsuarioBusiness usuarioBsn = new Business.UsuarioBusiness();

        Utils.ChecklistItemConversor checklistItemCnv = new Utils.ChecklistItemConversor();

        [HttpPost("adicionar-checklist-item")]
        public async Task<ActionResult<Models.Response.ChecklistItemResponse>> AdicionarChecklistItemAsync(Models.Request.ChecklistItemRequest req)
        {
            try
            {
                Models.TbUsuario tbUsuario = await usuarioBsn.ConsultarUsuarioPorIdLoginAsync(req.IdLogin);

                Models.TbChecklistItem tbChecklistItem = checklistItemCnv.ToTbChecklistItem(req);

                tbChecklistItem = await checklistItemBsn.AdicionarChecklistItemAsync(tbChecklistItem);

                Models.Response.ChecklistItemResponse resp = checklistItemCnv.ToChecklistItemResponse(tbChecklistItem);

                return resp;
            }
            catch (Exception e)
            {
                return BadRequest(
                    new Models.Response.ErroResponse(400, e.Message)
                );
            }
        }

        [HttpGet("consultar-checklist-item/{idLogin}")]
        public async Task<ActionResult<Models.Response.ChecklistItensResponse>> ConsultarChecklistItensAsync(int idLogin)
        {
            try
            {
                Models.TbUsuario tbUsuario = await usuarioBsn.ConsultarUsuarioPorIdLoginAsync(idLogin);

                List<Models.TbChecklistItem> checklistsItens = await checklistItemBsn.ConsultarChecklistsItemPorIdUsuarioAsync(tbUsuario.IdUsuario);

                Models.Response.ChecklistItensResponse resps = checklistItemCnv.ToChecklistItensResponse(checklistsItens);

                return resps;
            }
            catch(Exception e)
            {
                return BadRequest(
                    new Models.Response.ErroResponse(404, e.Message)
                );
            }
        }

        [HttpPut("alterar-checklist-item/{idChecklistItem}")]
        public async Task<ActionResult<Models.Response.ChecklistItemResponse>> AlterarChecklistItemAsync(int idChecklistItem, Models.Request.ChecklistItemRequest req)
        {
            try
            {
                Models.TbChecklistItem tbChecklistItemAtual = await checklistItemBsn.ConsultarChecklistPorIdAsync(idChecklistItem);

                Models.TbChecklistItem tbChecklistItemNovo = checklistItemCnv.ToTbChecklistItem(req);

                tbChecklistItemAtual = await checklistItemBsn.AlterarChecklistItemAsync(tbChecklistItemAtual, tbChecklistItemNovo);

                Models.Response.ChecklistItemResponse resp = checklistItemCnv.ToChecklistItemResponse(tbChecklistItemAtual);

                return resp;
            }
            catch (Exception e)
            {
                return BadRequest(
                    new Models.Response.ErroResponse(400, e.Message)
                );
            }
        }

        [HttpDelete("deletar-checklist-item/{idChecklistItem}")]
        public async Task<ActionResult<Models.Response.ChecklistItemResponse>> DeletarChecklistAsync(int idChecklistItem)
        {
            try
            {
                Models.TbChecklistItem tbChecklistItem = await checklistItemBsn.ConsultarChecklistPorIdAsync(idChecklistItem);

                tbChecklistItem = await checklistItemBsn.DeletarChecklistItemAsync(tbChecklistItem);

                Models.Response.ChecklistItemResponse resp = checklistItemCnv.ToChecklistItemResponse(tbChecklistItem);

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