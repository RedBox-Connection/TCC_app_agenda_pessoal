using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace backend.Utils
{
    public class CartaoUsuarioConversor
    {

        public Models.TbCartao ToTbCartao(Models.Request.CadastrarCartaoTarefaRequest req)
        {
            Models.TbCartao resp = new Models.TbCartao();

            resp.DsCartao = req.Descricao;
            resp.DsCor = req.Cor;
            resp.DtInclusao = DateTime.Now;
            int hora = Convert.ToInt32(req.Hora.Substring(0, 2));
            int minuto = Convert.ToInt32(req.Hora.Substring(3, 2));
            resp.DtTermino = req.Data.AddHours(hora).AddMinutes(minuto);
            resp.DsStatus = "Aguardando";
            resp.IdQuadro = req.IdQuadro;
            resp.NmCartao = req.NomeCartao;

            return resp;
        }

        public Models.TbCartao ToTbCartao(Models.Request.AlterarCartaoTarefaRequest req)
        {
            Models.TbCartao resp = new Models.TbCartao();

            resp.DsCartao = req.Descricao;
            resp.DsCor = req.Cor;
            resp.DtInclusao = DateTime.Now;
            int hora = Convert.ToInt32(req.Hora.Substring(0, 2));
            int minuto = Convert.ToInt32(req.Hora.Substring(3, 2));
            resp.DtTermino = req.Data.AddHours(hora).AddMinutes(minuto);
            resp.DsStatus = req.Status;
            resp.IdQuadro = req.IdQuadro;
            resp.NmCartao = req.NomeCartao;

            return resp;
        }

        public Models.TbCartao ToTbCartaoCheck(Models.Request.ChecklistRequest checklistReq, Models.TbUsuario tbUsuario)
        {
            Models.TbCartao tb = new Models.TbCartao();

            tb.IdQuadroNavigation.IdUsuario = tbUsuario.IdUsuario;
            tb.NmCartao = checklistReq.NomeChecklist;

            return tb;
        }

        private string VerificarStatusDoDia(DateTime dataTermino)
        {
            string statusDia = "";
            if(dataTermino >= DateTime.Now.AddDays(3))
                statusDia = "futuramente";
            else if(dataTermino >= DateTime.Now.AddDays(2))
                statusDia = "depois de amanha";
            else if(dataTermino >= DateTime.Now.AddDays(1))
                statusDia = "amanha";
            else if(dataTermino >= DateTime.Now)
                statusDia = "hoje";

            return statusDia;
        }

        public Models.Response.CartaoTarefaResponse ToCartaoTarefaResponse(Models.TbCartao req)
        {
            Models.Response.CartaoTarefaResponse resp = new Models.Response.CartaoTarefaResponse();

            resp.IdCartao = req.IdCartao;
            resp.IdQuadro = req.IdQuadro;
            resp.Status = req.DsStatus;
            resp.NomeCartao = req.NmCartao;
            resp.DataCartao = req.DtTermino;

            resp.StatusDia = this.VerificarStatusDoDia(req.DtTermino);

            return resp;
        }

        public Models.Response.CartoesTarefasResponse ToCartaoTarefaListResponse(List<Models.TbCartao> reqs)
        {
            List<Models.Response.CartaoTarefaResponse> resps = new List<Models.Response.CartaoTarefaResponse>();

            foreach(Models.TbCartao tb in reqs)
            {
                Models.Response.CartaoTarefaResponse x = new Models.Response.CartaoTarefaResponse();

                x.IdCartao = tb.IdCartao;
                x.IdQuadro = tb.IdQuadro;
                x.Status = tb.DsStatus;

                resps.Add(x);
            }

            return new Models.Response.CartoesTarefasResponse(resps);
        }
    }
}