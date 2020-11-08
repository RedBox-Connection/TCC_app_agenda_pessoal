using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace backend.Database
{
    public class QuadroDatabase
    {
        Models.tccdbContext ctx = new Models.tccdbContext();

        public async Task<List<Models.TbQuadro>> ConsultarQuadrosPorIdUsuarioAsync(int idUsuario)
        {
            return await ctx.TbQuadro.Include(x => x.TbTime)
                                     .Where(x => x.IdUsuario == idUsuario && (
                                         x.IdQuadro != x.TbTime.First().IdQuadro
                                     )).ToListAsync();
        }

        public async Task<Models.TbQuadro> ConsultarQuadroPorIdQuadroAsync(int idQuadro)
        {
            return await ctx.TbQuadro.FirstOrDefaultAsync(x => x.IdQuadro == idQuadro);
        }

        public async Task<Models.TbQuadro> CadastrarQuadroAsync(Models.TbQuadro req)
        {
            await ctx.TbQuadro.AddAsync(req);
            await ctx.SaveChangesAsync();

            return req;
        }

        public async Task<Models.TbQuadro> AlterarQuadroAsync(Models.TbQuadro atual, Models.TbQuadro novo)
        {
            atual.NmQuadro = novo.NmQuadro;

            await ctx.SaveChangesAsync();

            return atual;
        }

        public async Task<Models.TbQuadro> DeletarQuadroAsync(Models.TbQuadro req)
        {
            ctx.TbQuadro.Remove(req);
            await ctx.SaveChangesAsync();

            return req;
        }
    }
}