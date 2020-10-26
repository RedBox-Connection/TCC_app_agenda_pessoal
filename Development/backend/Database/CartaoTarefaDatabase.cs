using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

using System.Threading.Tasks;

namespace backend.Database
{
    public class CartaoTarefaDatabase
    {
        Models.tccdbContext ctx = new Models.tccdbContext();

        public async Task<Models.TbCartao> CadastrarCartaoTarefaAsync(Models.TbCartao req)
        {
            await ctx.TbCartao.AddAsync(req);
            await ctx.SaveChangesAsync();

            return req;
        }

        public async Task<List<Models.TbCartao>> ConsultarCartoesTarefaAsync(int idQuadro)
        {
            return await ctx.TbCartao.Where(x => x.IdQuadro == idQuadro).ToListAsync();
        }

        public async Task<Models.TbCartao> ConsultarCartaoTarefaPorIdAsync(int idCartao)
        {
            return await ctx.TbCartao.FirstOrDefaultAsync(x => x.IdCartao == idCartao);
        }

        public async Task<Models.TbCartao> AlterarCartaoTarefaAsync(Models.TbCartao atual, Models.TbCartao novo)
        {
            atual.DsCartao = novo.DsCartao;
            atual.DsCor = novo.DsCor;
            atual.DsStatus = novo.DsStatus;
            atual.DtInclusao = novo.DtInclusao;
            atual.DtTermino = novo.DtTermino;
            atual.IdQuadro = novo.IdQuadro;
            atual.NmCartao = novo.NmCartao;

            await ctx.SaveChangesAsync();

            return atual;
        }

        public async Task<Models.TbCartao> DeletarCartaoTarefaAsync(Models.TbCartao req)
        {
            ctx.TbCartao.Remove(req);
            await ctx.SaveChangesAsync();

            return req;
        }
    }
}