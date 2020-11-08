using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;

namespace backend.Business
{
    public class TimeBusiness
    {
        Database.TimeDatabase timeDb = new Database.TimeDatabase();
        Business.GerenciadorLink gerenciadorLink = new GerenciadorLink();

        private void ValidarTimeRequest(Models.TbTime req)
        {
            if(req.NmTime == string.Empty)
                throw new Exception("Nome do time não pode ser vazio.");

            if(req.DsLinkConvite == string.Empty)
                throw new Exception("Não foi possível gerar o link pro seu time.");
        }

        public async Task<Models.TbTime> CadastrarTimeAsync(Models.TbTime req)
        {
            this.ValidarTimeRequest(req);

            if(req.IdQuadro <= 0)
                throw new Exception("Quadro do time não encontrado.");

            req = await timeDb.CadastrarTimeAsync(req);

            if(req.IdTime <= 0)
                throw new Exception("Id do time inválido.");

            return req;
        }

        public async Task<Models.TbTime> ConsultarTimePorIdTime(int idTime)
        {
            if(idTime <= 0)
                throw new Exception("Id de time inválido.");

            Models.TbTime tbTime = await timeDb.ConsultarTimePorIdTime(idTime);

            if(tbTime == null)
                throw new Exception("Time não encontrado.");

            return tbTime;
        }

        public async Task<List<Models.TbTime>> ConsultarTimesPorIdUsuarioAsync(int idUsuario)
        {
            if(idUsuario <= 0)
                throw new Exception("Usuário inválido.");

            List<Models.TbTime> times = await timeDb.ConsultarTimesPorIdUsuarioAsync(idUsuario);

            if(times == null || times.Count == 0)
                throw new Exception("Você não possui ou faz parte de nenhum time ainda.");

            return times;
        }

        public async Task<Models.TbTime> AlterarTimeAsync(Models.TbTime timeAntigo, Models.TbTime timeAtual)
        {
            this.ValidarTimeRequest(timeAtual);

            if(timeAtual.IdTime <= 0)
                throw new Exception("Id do time inválido.");

            if(timeAtual.IdQuadro <= 0)
                throw new Exception("Quadro do time não encontrado.");

            timeAntigo = await timeDb.AlterarTimeAsync(timeAntigo, timeAtual);

            return timeAntigo;
        }

        public async Task<Models.TbTime> DeletarTimeAsync(Models.TbTime req)
        {
            return await timeDb.DeletarTimeAsync(req);
        }

        public async Task<Models.TbTime> SalvarLinkAsync(Models.TbTime timeAntigo, Models.TbTime timeNovo)
        {
            timeNovo.DsLinkConvite = gerenciadorLink.GerarLink(timeAntigo.IdTime, timeAntigo.IdQuadro);

            gerenciadorLink.ValidarLink(timeNovo.DsLinkConvite);

            timeAntigo = await timeDb.SalvarLinkAsync(timeAntigo, timeNovo);

            return timeAntigo;
        }
    }
}