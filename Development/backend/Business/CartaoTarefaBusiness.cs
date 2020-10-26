using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

using System.Threading.Tasks;

namespace backend.Business
{
    public class CartaoTarefaBusiness
    {
        Database.CartaoTarefaDatabase cartaoTarefaDb = new Database.CartaoTarefaDatabase();

        private Models.TbCartao ValidarCartaoTarefaRequest(Models.TbCartao req)
        {
            if(req.DsCor == string.Empty)
                throw new Exception("Cor não pode ser vazia.");

            if(req.DsStatus == string.Empty)
                throw new Exception("Status não pode ser nulo.");

            if(req.DtInclusao > DateTime.Now)
                throw new Exception("Data inválida, por favor insira uma data menor que o dia atual.");

            if(req.DtTermino < DateTime.Now)
                throw new Exception("Data inválida, por favor insira uma data maior que o dia atual.");

            if(req.IdQuadro <= 0)
                throw new Exception("ID do quadro inválido.");

            if(req.NmCartao == string.Empty)
                throw new Exception("Nome do quadro não pode ser vazio.");

            return req;
        }

        public async Task<Models.TbCartao> CadastrarCartaoTarefaAsync(Models.TbCartao req)
        {
            this.ValidarCartaoTarefaRequest(req);

            req = await cartaoTarefaDb.CadastrarCartaoTarefaAsync(req);

            if(req.IdCartao <= 0)
                throw new Exception("ID do cartão inválido.");

            return req;
        }

        public async Task<List<Models.TbCartao>> ConsultarCartoesTarefaAsync(int idQuadro)
        {
            if(idQuadro <= 0)
                throw new Exception("Id de Quadro inválido");

            List<Models.TbCartao> resps = await cartaoTarefaDb.ConsultarCartoesTarefaAsync(idQuadro);

            if(resps.Count <= 0)
                throw new Exception("Não há cartões nesse quadro.");

            return resps;
        }

        public async Task<Models.TbCartao> ConsultarCartaoTarefaPorIdAsync(int idCartao)
        {
            if(idCartao <= 0)
                throw new Exception("Id do cartão inválido.");

            Models.TbCartao resp = await cartaoTarefaDb.ConsultarCartaoTarefaPorIdAsync(idCartao);

            return resp;
        }

        public async Task<Models.TbCartao> AlterarCartaoTarefaAsync(Models.TbCartao atual, Models.TbCartao novo)
        {
            this.ValidarCartaoTarefaRequest(atual);
            this.ValidarCartaoTarefaRequest(novo);

            atual = await cartaoTarefaDb.AlterarCartaoTarefaAsync(atual, novo);

            return atual;
        }

        public async Task<Models.TbCartao> DeletarCartaoTarefaAsync(Models.TbCartao req)
        {
            return await cartaoTarefaDb.DeletarCartaoTarefaAsync(req);           
        }
    }
}