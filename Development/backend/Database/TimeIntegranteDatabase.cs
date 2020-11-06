using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

using System.Threading.Tasks;

namespace backend.Database
{
    public class TimeIntegranteDatabase
    {
        Models.tccdbContext ctx = new Models.tccdbContext();

        public async Task<Models.TbTimeIntegrante> CadastrarTimeIntegranteAsync(Models.TbTimeIntegrante req)
        {
            await ctx.TbTimeIntegrante.AddAsync(req);

            await ctx.SaveChangesAsync();

            return req;
        }

        public async Task<List<Models.TbTimeIntegrante>> ConsultarTimeIntegrantesPorIdTimeAsync(int idTime)
        {
            return await ctx.TbTimeIntegrante.Where(x => x.IdTime == idTime).ToListAsync();
        }

        public async Task<Models.TbTimeIntegrante> ConsultarIntegrantePorIdIntegrante(int idIntegrante)
        {
            return await ctx.TbTimeIntegrante.FirstOrDefaultAsync(x => x.IdIntegrante == idIntegrante);
        }

        public async Task<Models.TbTimeIntegrante> AlterarTimeIntegrantesAsync(Models.TbTimeIntegrante integranteAntigo, Models.TbTimeIntegrante integranteAtual)
        {
            integranteAntigo.DsPermissao = integranteAtual.DsPermissao;

            await ctx.SaveChangesAsync();

            return integranteAntigo;
        }

        public async Task<Models.TbTimeIntegrante> DeletarTimeIntegranteAsync(Models.TbTimeIntegrante req)
        {
            ctx.TbTimeIntegrante.Remove(req);

            await ctx.SaveChangesAsync();

            return req; 
        }
    }
}