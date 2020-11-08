using System;
using System.Collections;
using System.Collections.Generic;

namespace backend.Utils
{
    public class QuadroConversor
    {
        public Models.TbQuadro ToTbQuadro(Models.Request.CadastrarAlterarQuadroRequest req, Models.TbUsuario tbUsuario)
        {
            Models.TbQuadro resp = new Models.TbQuadro();

            resp.IdUsuario = tbUsuario.IdUsuario;
            resp.NmQuadro = req.NomeQuadro;

            return resp;
        }

        public Models.TbQuadro ToTbQuadro(Models.Request.CadastrarAlterarTimeRequest req, Models.TbUsuario tbUsuario)
        {
            Models.TbQuadro resp = new Models.TbQuadro();

            resp.IdUsuario = tbUsuario.IdUsuario;
            resp.NmQuadro = req.NomeTime;

            return resp;
        }

        public Models.Response.QuadroResponse ToQuadroResponse(Models.TbQuadro req)
        {
            Models.Response.QuadroResponse resp = new Models.Response.QuadroResponse();

            resp.IdQuadro = req.IdQuadro;
            resp.NomeQuadro = req.NmQuadro;
            resp.Descricao = "Quadro";

            return resp;
        }

        public Models.Response.ConsultarQuadrosResponse ToQuadrosResponse(List<Models.TbQuadro> reqs)
        {
            Models.Response.ConsultarQuadrosResponse response = new Models.Response.ConsultarQuadrosResponse();

            List<Models.Response.QuadroResponse> responses = new List<Models.Response.QuadroResponse>();

            foreach(Models.TbQuadro tb in reqs)
            {
                Models.Response.QuadroResponse resp = this.ToQuadroResponse(tb);

                responses.Add(resp);
            }

            response.Quadros = responses;

            return response;
        }
    }
}