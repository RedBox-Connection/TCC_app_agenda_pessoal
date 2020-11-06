using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

using System.Threading.Tasks;

namespace backend.Business
{
    public class TimeIntegranteBusiness
    {
        Database.TimeIntegranteDatabase integranteDb = new Database.TimeIntegranteDatabase();

        private void ValidarTimeIntegranteRequest(Models.TbTimeIntegrante req)
        {
            if(req.DsPermissao == string.Empty)
                throw new Exception("Permissão do Usuário não reconhecida.");

            if(req.IdUsuario <= 0)
                throw new Exception("Usuário não encontrado.");

            if(req.IdTime <= 0)
                throw new Exception("Time não encontrado.");
        }

        public async Task<Models.TbTimeIntegrante> CadastrarTimeIntegranteAsync(Models.TbTimeIntegrante req)
        {
            this.ValidarTimeIntegranteRequest(req);

            req = await integranteDb.CadastrarTimeIntegranteAsync(req);

            if(req.IdIntegrante <= 0)
                throw new Exception("Integrante não cadastrado.");

            return req;
        }

        public async Task<List<Models.TbTimeIntegrante>> ConsultarTimeIntegrantesPorIdTimeAsync(int idTime)
        {
            if(idTime <= 0)
                throw new Exception("Time não encontrado.");

            List<Models.TbTimeIntegrante> resp = await integranteDb.ConsultarTimeIntegrantesPorIdTimeAsync(idTime);

            if(resp == null || resp.Count == 0)
                throw new Exception("Não há integrantes nesse time.");

            return resp;
        }

        public async Task<Models.TbTimeIntegrante> ConsultarIntegrantePorIdIntegrante(int idIntegrante)
        {
            if(idIntegrante <= 0)
                throw new Exception("Id do usuário inválido.");

            Models.TbTimeIntegrante resp = await integranteDb.ConsultarIntegrantePorIdIntegrante(idIntegrante);

            if(resp == null)
                throw new Exception("Integrante não encontrado.");

            return resp;
        }

        public async Task<Models.TbTimeIntegrante> AlterarTimeIntegrantesAsync(Models.TbTimeIntegrante integranteAntigo, Models.TbTimeIntegrante integranteAtual)
        {
            this.ValidarTimeIntegranteRequest(integranteAtual);

            if(integranteAtual.IdIntegrante <= 0)
                throw new Exception("Integrante não encontrado.");

            integranteAntigo = await integranteDb.AlterarTimeIntegrantesAsync(integranteAntigo, integranteAtual);

            return integranteAntigo;
        }

        public async Task<Models.TbTimeIntegrante> DeletarTimeIntegranteAsync(Models.TbTimeIntegrante req)
        {
            return await integranteDb.DeletarTimeIntegranteAsync(req);
        }
    }
}