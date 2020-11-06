using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

using System.Threading.Tasks;

namespace backend.Database
{
    public class ChecklistItemDatabase
    {
        Models.tccdbContext ctx = new Models.tccdbContext();

        public async Task<Models.TbChecklistItem> AdicionarChecklistItemAsync(Models.TbChecklistItem tb)
        {
            await ctx.TbChecklistItem.AddAsync(tb);

            await ctx.SaveChangesAsync();

            return tb;
        }

        public async Task<Models.TbChecklistItem> ConsultarChecklistItemPorIdAsync(int idChecklistItem)
        {
            return await ctx.TbChecklistItem.FirstOrDefaultAsync(x => x.IdItem == idChecklistItem);
        }

        public async Task<List<Models.TbChecklistItem>> ConsulatrChecklistsItensPorIdUsuarioAsync(int idUsuario)
        {
            return await ctx.TbChecklistItem.Where(x => x.IdChecklistNavigation.IdCartaoNavigation
                                                                                      .IdQuadroNavigation.IdUsuario == idUsuario).ToListAsync();
        }

        public async Task<Models.TbChecklistItem> AlterarChecklistItemAsync(Models.TbChecklistItem tbAtual, Models.TbChecklistItem tbNovo)
        {
            tbAtual.NmItem = tbNovo.NmItem;

            await ctx.SaveChangesAsync();

            return tbAtual;
        }

        public async Task<Models.TbChecklistItem> DeletarChecklistItemAsync(Models.TbChecklistItem tb)
        {
            ctx.TbChecklistItem.Remove(tb);

            await ctx.SaveChangesAsync();

            return tb;
        }
    }
}