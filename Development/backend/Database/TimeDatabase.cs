using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using Microsoft.EntityFrameworkCore;

using System.Threading.Tasks;

namespace backend.Database
{
    public class TimeDatabase
    {
        Models.tccdbContext ctx = new Models.tccdbContext();

        public async Task<Models.TbTime> CadastrarTimeAsync(Models.TbTime req)
        {
            await ctx.TbTime.AddAsync(req);

            await ctx.SaveChangesAsync();

            return req;
        }

        public async Task<Models.TbTime> ConsultarTimePorIdTime(int idTime)
        {
            return await ctx.TbTime.FirstOrDefaultAsync(x => x.IdTime == idTime);
        }

        public async Task<List<Models.TbTime>> ConsultarTimesPorIdUsuarioAsync(int idUsuario)
        {
            return await ctx.TbTime.Include(x => x.TbTimeIntegrante)
                                   .Where(x => x.TbTimeIntegrante.FirstOrDefault().IdUsuario == idUsuario).ToListAsync();
        }

        public async Task<Models.TbTime> AlterarTimeAsync(Models.TbTime timeAntigo, Models.TbTime timeAtual)
        {
            timeAntigo.NmTime = timeAtual.NmTime;
            timeAntigo.DsTime = timeAtual.DsTime;

            await ctx.SaveChangesAsync();

            return timeAntigo;
        }

        public async Task<Models.TbTime> DeletarTimeAsync(Models.TbTime req)
        {
            ctx.TbTime.Remove(req);

            await ctx.SaveChangesAsync();

            return req;
        }

        public async Task<Models.TbTime> SalvarLinkAsync(Models.TbTime timeAntigo, Models.TbTime timeNovo)
        {
            timeAntigo.DsLinkConvite = timeNovo.DsLinkConvite;

            await ctx.SaveChangesAsync();

            return timeAntigo;
        }
    }
}