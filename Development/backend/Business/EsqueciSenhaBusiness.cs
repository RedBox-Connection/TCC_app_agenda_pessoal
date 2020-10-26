using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;

namespace backend.Business
{
    public class EsqueciSenhaBusiness
    {
        Business.UsuarioBusiness usuarioBsn = new UsuarioBusiness();
        Database.EsqueciSenhaDatabase esqueciSenhaDB = new Database.EsqueciSenhaDatabase();

        public long GerarCodigoRecuperacao()
        {
            Random rnd = new Random();
            long resp = rnd.Next(100000, 999999);
            return resp;
        }

        public async Task<bool> ValidarCodigoDeRecuperacaoAsync(long Codigo)
        {
            List<long> codigos = await esqueciSenhaDB.ConsultarCodigosDeRecuperacaoAsync();
            
            if(codigos == null)
                return false;

            if(codigos.Count == 0)
                return true;

            bool resp = !codigos.Contains(Codigo);

            return resp;
        }

        public async Task<Models.TbEsqueciSenha> SalvarCodigoRecuperacaoAsync(Models.TbEsqueciSenha req)
        {
            if(req.IdLogin <= 0)
                throw new Exception("Usuário não encontrado.");

            if(req.TmExpiracao < DateTime.Now)
                throw new Exception("O código expirou, iremos reenviar o email de recuperação de senha.");

            if(req.TmInclusao > DateTime.Now)
                throw new Exception("Período do código inválido.");
            
            if(!req.DsEmail.Contains('@'))
                throw new Exception("Este Email é invalido.");

            if(req.NrCodigo <= 0)
                throw new Exception("Código inválido.");

            bool codigoOk = await this.ValidarCodigoDeRecuperacaoAsync(req.NrCodigo);
            long codigoTest = req.NrCodigo;
            while(codigoOk == false)
            {
                codigoTest = this.GerarCodigoRecuperacao();

                codigoOk = await this.ValidarCodigoDeRecuperacaoAsync(codigoTest);
            }

            req.NrCodigo = codigoTest;

            req = await esqueciSenhaDB.SalvarCodigoRecuperacaoAsync(req);

            return req;   
        }

        public async Task<Models.TbEsqueciSenha> ConsultarRecuperacaoDeSenhaPorCodigoAsync(long codigo)
        {
            if(codigo <= 0 || codigo > 999999)
                throw new Exception("Código inválido.");

            Models.TbEsqueciSenha resp = await esqueciSenhaDB.ConsultarRecuperacaoDeSenhaPorCodigoAsync(codigo);

            if(resp == null)
                throw new Exception("Código não encontrado.");

            if(resp.TmExpiracao < DateTime.Now)
            {
                resp = await this.DeletarRecuperacaoDeSenhaPorTempoAsync(resp);

                throw new Exception("O código expirou, iremos reenviar o email de recuperação de senha.");
            }


            return resp;
        }

        public async Task<Models.TbEsqueciSenha> DeletarRecuperacaoDeSenhaPorTempoAsync(Models.TbEsqueciSenha req)
        {
            if(req == null)
                throw new Exception("Código não encontrado.");

            req = await esqueciSenhaDB.DeletarRecuperacaoDeSenhaPorTempo(req);

            return req;
        }

        public async Task<Models.TbLogin> DeletarRecuperacaoDeSenhaAsync(Models.TbLogin novo, Models.TbLogin atual, Models.TbEsqueciSenha req)
        {
            if(req == null)
                throw new Exception("Código não encontrado.");

            bool senhaOk = usuarioBsn.SenhaForte(novo.DsSenha);

            if(senhaOk == false)
                throw new Exception("A senha deve conter pelo menos um caracter especial, " + 
                                    "uma letra maiúscula, dois números e oito digitos.");

            atual = await esqueciSenhaDB.DeletarRecuperacaoDeSenhaAsync(novo, atual, req);

            return atual;
        }

        public async Task<Models.TbLogin> ConsultarLoginPorIdAsync(int? id)
        {
            if(id <= 0 || id == null)
                throw new Exception("O id está inválido");

            return await esqueciSenhaDB.ConsultarLoginPorIdAsync(id);
        }

        public async Task<Models.TbEsqueciSenha> ConsultarTbEsqueciSenhaPorIdLoginAsync(Models.TbLogin tbLogin)
        {
            return await esqueciSenhaDB.ConsultarTbEsqueciSenhaPorIdLoginAsync(tbLogin);
        }

    }
}