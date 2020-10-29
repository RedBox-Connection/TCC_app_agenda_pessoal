using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<Models.TbEsqueciSenha> DeletarRecuperacaoDeSenhaPorTempo(Models.TbEsqueciSenha req)
        {
            ctx.TbEsqueciSenha.Remove(req);
            await ctx.SaveChangesAsync();

            return req;
        }

        public async Task<Models.TbLogin> DeletarRecuperacaoDeSenhaAsync(Models.TbLogin novo,Models.TbLogin atual, Models.TbEsqueciSenha reqEsqueciSenha)
        {
            atual.DsSenha = novo.DsSenha;

            List<Models.TbEsqueciSenha> lista = ctx.TbEsqueciSenha.Where(x => x.IdLogin == atual.IdLogin).ToList();

            while(lista.Count() > 0)
            {
                lista.Remove(reqEsqueciSenha);
                ctx.TbEsqueciSenha.Remove(reqEsqueciSenha);
                await ctx.SaveChangesAsync();
                reqEsqueciSenha = await this.ConsultarTbEsqueciSenhaPorIdLoginAsync(atual);
            }

            await ctx.SaveChangesAsync();
            

            return atual;
        }

        public async Task<Models.TbLogin> ConsultarLoginPorIdAsync(int? id)
        {
            return await ctx.TbLogin.FirstOrDefaultAsync(x => x.IdLogin == id);
        }

        public async Task<Models.TbEsqueciSenha> ConsultarTbEsqueciSenhaPorIdLoginAsync(Models.TbLogin tbLogin)
        {
            return await ctx.TbEsqueciSenha.FirstOrDefaultAsync(x => x.IdLogin == tbLogin.IdLogin);
        }
    }
}