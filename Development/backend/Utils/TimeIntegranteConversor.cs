using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace backend.Utils
{
    public class TimeIntegranteConversor
    {
        public Models.TbTimeIntegrante ToTbIntegrante(Models.Request.TimeIntegranteRequest req)
        {
            Models.TbTimeIntegrante integrante = new Models.TbTimeIntegrante();

            integrante.IdUsuario = req.IdUsuario;
            integrante.IdTime = req.IdTime;
            integrante.DsPermissao = req.Permissao;

            return integrante;
        }

        public Models.TbTimeIntegrante ToTbIntegrante(int idUsuario, int idTime)
        {
            Models.TbTimeIntegrante integrante = new Models.TbTimeIntegrante();

            integrante.IdUsuario = idUsuario;
            integrante.IdTime = idTime;
            integrante.DsPermissao = "Admin";

            return integrante;
        }

        public Models.Response.TimeIntegranteResponse ToIntegranteResponse(Models.TbTimeIntegrante req)
        {
            Models.Response.TimeIntegranteResponse resp = new Models.Response.TimeIntegranteResponse();

            resp.IdIntegrante = req.IdIntegrante;
            resp.Permissao = req.DsPermissao;

            return resp;
        }

        public Models.Response.TimeIntegrantesResponse ToIntegranteResponse(List<Models.TbTimeIntegrante> reqs)
        {
            Models.Response.TimeIntegrantesResponse resp = new Models.Response.TimeIntegrantesResponse();

            List<Models.Response.TimeIntegranteResponse> integrantes = new List<Models.Response.TimeIntegranteResponse>();

            foreach(Models.TbTimeIntegrante integrante in reqs)
            {
                Models.Response.TimeIntegranteResponse x = new Models.Response.TimeIntegranteResponse();

                x.IdIntegrante = integrante.IdIntegrante;
                x.Permissao = integrante.DsPermissao;

                integrantes.Add(x);
            }

            resp.Integrantes = integrantes;

            return resp;
        }
    }
}