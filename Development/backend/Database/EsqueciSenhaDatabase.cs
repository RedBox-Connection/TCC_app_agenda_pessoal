using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace backend.Database
{
    public class  EsqueciSenhaDatabase
    {
        Models.tccdbContext ctx = new Models.tccdbContext();

        public async  Task<List<long>> ConsultarCodigosDeRecuperacaoAsync()
        {
            List<Models.TbEsqueciSenha> senhas = await ctx.TbEsqueciSenha.ToListAsync();
            
            List<long> resp = new List<long>();

            foreach(Models.TbEsqueciSenha tb in senhas )
            {
                long x = tb.NrCodigo;

                resp.Add(x);
            }
            
            return resp;
        }

        public async Task<Models.TbEsqueciSenha> SalvarCodigoRecuperacaoAsync(Models.TbEsqueciSenha req)
        {
            await ctx.TbEsqueciSenha.AddAsync(req);
            await ctx.SaveChangesAsync();

            return req;
        }

        public async Task<Models.TbEsqueciSenha> ConsultarRecuperacaoDeSenhaPorCodigoAsync(long codigo)
        {
            return await ctx.TbEsqueciSenha.FirstOrDefaultAsync(x => x.NrCodigo == codigo);
        }

        public async Task<Models.TbEsqueciSenha> DeletarRecuperacaoDeSenha(Models.TbEsqueciSenha req)
        {
            ctx.Remove(req);
            await ctx.SaveChangesAsync();

            return req;
        }

    }
}