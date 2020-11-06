using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace backend.Utils
{
    public class TimeConversor
    {
        public Models.TbTime ToTbTime(Models.Request.CadastrarAlterarTimeRequest req, Models.TbQuadro tbQuadro)
        {
            Models.TbTime resp = new Models.TbTime();

            resp.NmTime = req.NomeTime;
            resp.DsTime = req.DescricaoTime;
            resp.IdQuadro = tbQuadro.IdQuadro;

            return resp;
        }

        public Models.Response.CadastrarAlterarTimeResponse ToTimeResponse(Models.TbTime req)
        {
            Models.Response.CadastrarAlterarTimeResponse resp = new Models.Response.CadastrarAlterarTimeResponse();

            resp.IdTime = req.IdTime;
            resp.NomeTime = req.NmTime;

            return resp;
        }

        public Models.Response.ConsultarTimesResponse ToTimesReponse(List<Models.TbTime> req)
        {
            Models.Response.ConsultarTimesResponse resp = new Models.Response.ConsultarTimesResponse();

            List<Models.Response.CadastrarAlterarTimeResponse> times = new List<Models.Response.CadastrarAlterarTimeResponse>();

            foreach(Models.TbTime time in req)
            {
                Models.Response.CadastrarAlterarTimeResponse x = new Models.Response.CadastrarAlterarTimeResponse();

                x.IdTime = time.IdTime;
                x.NomeTime = time.NmTime;

                times.Add(x);
            }

            resp.Times = times;

            return resp;
        }
    }
}