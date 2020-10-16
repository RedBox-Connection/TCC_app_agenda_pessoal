using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace backend.Database
{
    public class  EsqueciSenhaDatabase
    {
        Models.tccdbContext ctx = new Models.tccdbContext();
        public async  Task<List<long>> ConsultarCodigoDeRecuperacao()
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

        public async Task<Models.TbEsqueciSenha> GerarCodigoRecuperacaoAsync(Models.TbEsqueciSenha req)
        {
            Random rand = new Random();
            req.NrCodigo = rand.Next(1, 999999);
            await ctx.TbEsqueciSenha.AddAsync(req);
            await ctx.SaveChangesAsync();

            return req;
        }

    }
}