using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace backend.Utils
{
    public class CartaoComentarioConversor
    {
        public Models.TbCartaoComentario ToTbCartaoComentario(Models.Request.CartaoComentarioRequest req)
        {
            Models.TbCartaoComentario tb = new Models.TbCartaoComentario();

            tb.DsComentario = req.Comentario;
            tb.IdCartao = req.IdCartao;
            tb.IdUsuario = req.IdUsuario;

            return tb;
        }

        public Models.Response.CartaoComentarioResponse ToCartaoComentarioResponse(Models.TbCartaoComentario req)
        {
            Models.Response.CartaoComentarioResponse resp = new Models.Response.CartaoComentarioResponse();

            resp.IdCartao = req.IdCartao;
            resp.IdUsuario = req.IdUsuario;

            return resp;
        }

        public Models.Response.CartaoesComentarioResponse ToCartaoComentarioListResponse(List<Models.TbCartaoComentario> reqs)
        {
            List<Models.Response.CartaoComentarioResponse> resps = new List<Models.Response.CartaoComentarioResponse>();

            foreach(Models.TbCartaoComentario tb in reqs)
            {
                Models.Response.CartaoComentarioResponse x = new Models.Response.CartaoComentarioResponse();

                x.IdCartao = tb.IdCartao;
                x.IdUsuario = tb.IdUsuario;

                resps.Add(x);
            }

            return new Models.Response.CartaoesComentarioResponse(resps);
        }
    }
}