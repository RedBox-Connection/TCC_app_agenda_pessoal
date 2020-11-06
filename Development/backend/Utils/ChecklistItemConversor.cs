using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace backend.Utils
{
    public class ChecklistItemConversor
    {
        public Models.TbChecklistItem ToTbChecklistItem(Models.Request.ChecklistItemRequest req)
        {
            Models.TbChecklistItem tb = new Models.TbChecklistItem();

            tb.NmItem = req.NomeItem;
            tb.IdChecklist = req.IdChecklist;

            return tb;
        }

        public Models.Response.ChecklistItemResponse ToChecklistItemResponse(Models.TbChecklistItem tb)
        {
            Models.Response.ChecklistItemResponse resp = new Models.Response.ChecklistItemResponse();

            resp.IdChecklistItem = tb.IdItem;
            resp.NomeItem = tb.NmItem;

            return resp;
        }

        public Models.Response.ChecklistItensResponse ToChecklistItensResponse(List<Models.TbChecklistItem> tbs)
        {
            Models.Response.ChecklistItensResponse resps = new Models.Response.ChecklistItensResponse();

            List<Models.Response.ChecklistItemResponse> checklistItens = new List<Models.Response.ChecklistItemResponse>();

            foreach(Models.TbChecklistItem tb in tbs)
            {
                Models.Response.ChecklistItemResponse itens = new Models.Response.ChecklistItemResponse();

                itens.IdChecklistItem  = tb.IdItem;
                itens.NomeItem = tb.NmItem;

                checklistItens.Add(itens);
            } 

            resps.Itens = checklistItens;

            return resps;
        }
    }
}