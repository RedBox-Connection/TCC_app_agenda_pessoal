using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

using System.Threading.Tasks;

namespace backend.Database
{
    public class ChecklistDatabase
    {
        Models.tccdbContext ctx = new Models.tccdbContext();

        public async Task<Models.TbChecklist> AdicionarChecklistAsync(Models.TbChecklist tb)
        {
            await ctx.TbChecklist.AddAsync(tb);

            await ctx.SaveChangesAsync();

            return tb;
        }

        public async Task<Models.TbChecklist> ConsultarChecklistPorIdAsync(int idChecklist)
        {
            return await ctx.TbChecklist.FirstOrDefaultAsync(x => x.IdChecklist == idChecklist);
        }

        public async Task<List<Models.TbChecklist>> ConsulatrChecklistsPorIdUsuarioAsync(int idUsuario)
        {
            return await ctx.TbChecklist.Include(x => x.TbChecklistItem)
                                                        .Where(x => x.TbChecklistItem.FirstOrDefault().IdChecklistNavigation.IdCartaoNavigation
                                                                                                          .IdQuadroNavigation.IdUsuario == idUsuario).ToListAsync();
        }

        public async Task<Models.TbChecklist> AlterarChecklistAsync(Models.TbChecklist tbAtual, Models.TbChecklist tbNovo)
        {
            tbAtual.NmChecklist = tbNovo.NmChecklist;

            await ctx.SaveChangesAsync();

            return tbAtual;
        }

        public async Task<Models.TbChecklist> DeletarChecklistAsync(Models.TbChecklist tb)
        {
            ctx.TbChecklist.Remove(tb);

            await ctx.SaveChangesAsync();

            return tb;
        }
    }
}