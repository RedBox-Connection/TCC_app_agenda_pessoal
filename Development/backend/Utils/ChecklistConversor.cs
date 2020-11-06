using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;


namespace backend.Utils
{
    public class ChecklistConversor
    {
        public Models.TbChecklist ToTbChecklist(Models.Request.ChecklistRequest req, Models.TbCartao tbCartao)
        {
            Models.TbChecklist tb = new Models.TbChecklist();

            tb.NmChecklist = req.NomeChecklist;
            tb.IdCartao = tbCartao.IdCartao;

            return tb;
        }

        public Models.Response.ChecklistResponse ToChecklistResponse(Models.TbChecklist tb)
        {
            Models.Response.ChecklistResponse resp = new Models.Response.ChecklistResponse();

            resp.IdChecklist = tb.IdChecklist;
            resp.NomeChecklist = tb.NmChecklist;

            return resp;
        }

        public Models.Response.ChecklistsResponse ToChecklistsResponse(List<Models.TbChecklist> tbs)
        {
            Models.Response.ChecklistsResponse resps = new Models.Response.ChecklistsResponse();

            List<Models.Response.ChecklistResponse> checklists = new List<Models.Response.ChecklistResponse>();

            foreach(Models.TbChecklist tb in tbs)
            {
                Models.Response.ChecklistResponse check = new Models.Response.ChecklistResponse();

                check.IdChecklist  = tb.IdChecklist;
                check.NomeChecklist = tb.NmChecklist;

                checklists.Add(check);
            } 

            resps.Checklists = checklists;

            return resps;
        }
    }
}