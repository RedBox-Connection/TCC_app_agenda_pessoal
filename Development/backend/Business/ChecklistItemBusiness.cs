using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

using System.Threading.Tasks;


namespace backend.Business
{
    public class ChecklistItemBusiness
    {
        Database.ChecklistItemDatabase checklistItemDb = new Database.ChecklistItemDatabase();
        public void ValidarChecklistItemAsync(Models.TbChecklistItem tb)
        {
            if(tb.NmItem == string.Empty)
                throw new Exception("Nome do Item do Checklist não pode ser vazio.");
        }

        public async Task<Models.TbChecklistItem> AdicionarChecklistItemAsync(Models.TbChecklistItem tb)
        {
            this.ValidarChecklistItemAsync(tb);

            if(tb.IdChecklist <= 0)
                throw new Exception("Checklist não encontrado.");

            tb = await checklistItemDb.AdicionarChecklistItemAsync(tb);

            if(tb.IdItem <= 0)
                throw new Exception("ID do Item invalido.");

            return tb;
        }

        public async Task<Models.TbChecklistItem> ConsultarChecklistPorIdAsync(int idChecklistItem)
        {
            if(idChecklistItem <= 0)
                throw new Exception("ID Item Invalido.");

            Models.TbChecklistItem tbChecklistItem = await checklistItemDb.ConsultarChecklistItemPorIdAsync(idChecklistItem);

            if(tbChecklistItem == null)
                throw new Exception("Item no Checklist não encontrado.");

            return tbChecklistItem;
        }

        public async Task<List<Models.TbChecklistItem>> ConsultarChecklistsItemPorIdUsuarioAsync(int idUsuario)
        {
            if(idUsuario <= 0)
                throw new Exception("Usuário inválido.");

            List<Models.TbChecklistItem> checklists = await checklistItemDb.ConsulatrChecklistsItensPorIdUsuarioAsync(idUsuario);

            if(checklists == null || checklists.Count == 0)
                throw new Exception("Você não possui nenhum Item no Checklist ainda.");

            return checklists;
        }

        public async Task<Models.TbChecklistItem> AlterarChecklistItemAsync(Models.TbChecklistItem tbAtual, Models.TbChecklistItem tbNovo)
        {
            this.ValidarChecklistItemAsync(tbNovo);

            if(tbNovo.IdItem <= 0)
                throw new Exception("ID do Item no Checklist inválido.");

            if(tbNovo.IdChecklist <= 0)
                throw new Exception("Checklist não encontrado.");

            tbAtual = await checklistItemDb.AlterarChecklistItemAsync(tbAtual, tbNovo);

            return tbAtual;
        }

        public async Task<Models.TbChecklistItem> DeletarChecklistItemAsync(Models.TbChecklistItem tb)
        {
            return await checklistItemDb.DeletarChecklistItemAsync(tb);
        }
    }
}