using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

using System.Threading.Tasks;


namespace backend.Database
{
    public class CartaoComentarioDatabase
    {
        Models.tccdbContext ctx = new Models.tccdbContext();

        public async Task<Models.TbCartaoComentario> AdicionarComentarioCartaoAsync(Models.TbCartaoComentario tb)
        {
            await ctx.TbCartaoComentario.AddAsync(tb);
            await ctx.SaveChangesAsync();

            return tb;
        }

        public async Task<List<Models.TbCartaoComentario>> ConsutarComentarioPorIdCartaoAsync(int idCartao)
        {
            return await ctx.TbCartaoComentario.Where(x => x.IdCartao == idCartao).ToListAsync();
        }

        public async Task<Models.TbCartaoComentario> ConsutarComentarioPorIdLoginAsync(int idLogin)
        {
            return await ctx.TbCartaoComentario.FirstOrDefaultAsync(x => x.IdUsuarioNavigation.IdLogin == idLogin);
        }

        public async Task<Models.TbCartaoComentario> AlterarComentarioPorIdLoginAsync(int idLogin, Models.TbCartaoComentario atual, Models.TbCartaoComentario novo)
        {
            atual.DsComentario =  novo.DsComentario;
            atual.DtInclusao = DateTime.Now;
            
            await ctx.SaveChangesAsync();
            
            return atual;
        }

        public async Task<Models.TbCartaoComentario> DeletarComentarioPorIdLoginAsync(Models.TbCartaoComentario tb)
        {
            ctx.TbCartaoComentario.Remove(tb);
            await ctx.SaveChangesAsync();

            return tb;
        }
    }
}