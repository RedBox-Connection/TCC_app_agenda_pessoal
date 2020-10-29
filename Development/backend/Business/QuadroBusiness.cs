using System;
using System.Collections;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace backend.Business
{
    public class QuadroBusiness
    {
        Database.QuadroDatabase quadroDb = new Database.QuadroDatabase();

        private void ValidarQuadroRequest(Models.TbQuadro req)
        {
            if(req.IdUsuario <= 0)
                throw new Exception("Id de usuário inválido.");

            if(req.NmQuadro == string.Empty)
                throw new Exception("Nome do quadro não pode ser vazio.");
        }

        public async Task<List<Models.TbQuadro>> ConsultarQuadrosPorIdUsuarioAsync(int idUsuario)
        {
            if(idUsuario <= 0)
                throw new Exception("Id de usuário inválido.");

            List<Models.TbQuadro> resp = await quadroDb.ConsultarQuadrosPorIdUsuarioAsync(idUsuario);

            if(resp.Count == 0)
                throw new Exception("Você não possui quadros.");

            return resp;
        }

        public async Task<Models.TbQuadro> ConsultarQuadroPorIdQuadroAsync(int idQuadro)
        {
            if(idQuadro < 0)
                throw new Exception("Id do quadro inválido.");

            Models.TbQuadro resp = await quadroDb.ConsultarQuadroPorIdQuadroAsync(idQuadro);

            this.ValidarQuadroRequest(resp);

            return resp;
        }

        public async Task<Models.TbQuadro> CadastrarQuadroAsync(Models.TbQuadro req)
        {
            this.ValidarQuadroRequest(req);

            req = await quadroDb.CadastrarQuadroAsync(req);

            if(req.IdQuadro <= 0)
                throw new Exception("Quadro não cadastrado.");

            return req;
        }

        public async Task<Models.TbQuadro> AlterarQuadroAsync(Models.TbQuadro atual, Models.TbQuadro novo)
        {
            this.ValidarQuadroRequest(novo);

            atual = await quadroDb.AlterarQuadroAsync(atual, novo);

            return atual;
        }

        public async Task<Models.TbQuadro> DeletarQuadroAsync(Models.TbQuadro req)
        {
            return await quadroDb.DeletarQuadroAsync(req);
        }
    }
}