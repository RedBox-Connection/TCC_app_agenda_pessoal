using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;

namespace backend.Business
{
    public class EsqueciSenhaBusiness
    {
        Database.EsqueciSenhaDatabase esqueciSenhaDB = new Database.EsqueciSenhaDatabase();
        public async Task<bool> ValidarCodigoDeRecuperacao(long Codigo)
        {
            List<long> Codigos = await esqueciSenhaDB.ConsultarCodigoDeRecuperacao();
            
            if(Codigos == null || Codigos.Count <= 0)
                return false;

            bool resp = Codigos.Contains(Codigo);

            return resp;
        }

        public async Task<Models.TbEsqueciSenha> GerarCodigoRecuperacaoAsync(Models.TbEsqueciSenha req)
        {
            bool codigoOk = await this.ValidarCodigoDeRecuperacao(req.NrCodigo);

            if(DateTime.Now > req.TmExpiracao)
                throw new Exception("O Codigo está vencido.");
            
            req = await esqueciSenhaDB.GerarCodigoRecuperacaoAsync(req);
            
            return req;
        }
    }
}