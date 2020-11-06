using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

using System.Threading.Tasks;


namespace backend.Business
{
    public class ChecklistBusiness
    {
        Database.ChecklistDatabase checklistDb = new Database.ChecklistDatabase();
        public void ValidarChecklistAsync(Models.TbChecklist tb)
        {
            if(tb.NmChecklist == string.Empty)
                throw new Exception("Nome do Checklist não pode ser vazio.");
        }

        public async Task<Models.TbChecklist> AdicionarChecklistAsync(Models.TbChecklist tb)
        {
            this.ValidarChecklistAsync(tb);

            if(tb.IdCartao <= 0)
                throw new Exception("Cartão não encontrado.");

            tb = await checklistDb.AdicionarChecklistAsync(tb);

            if(tb.IdChecklist <= 0)
                throw new Exception("ID do checklist invalido.");

            return tb;
        }

        public async Task<Models.TbChecklist> ConsultarChecklistPorIdAsync(int idChecklist)
        {
            if(idChecklist <= 0)
                throw new Exception("ID Checklist Invalido.");

            Models.TbChecklist tbChecklist = await checklistDb.ConsultarChecklistPorIdAsync(idChecklist);

            if(tbChecklist == null)
                throw new Exception("Checklist não encontrado.");

            return tbChecklist;
        }

        public async Task<List<Models.TbChecklist>> ConsultarChecklistsPorIdUsuarioAsync(int idUsuario)
        {
            if(idUsuario <= 0)
                throw new Exception("Usuário inválido.");

            List<Models.TbChecklist> checklists = await checklistDb.ConsulatrChecklistsPorIdUsuarioAsync(idUsuario);

            if(checklists == null || checklists.Count == 0)
                throw new Exception("Você não possui nenhum Checklist ainda.");

            return checklists;
        }

        public async Task<Models.TbChecklist> AlterarChecklistAsync(Models.TbChecklist tbAtual, Models.TbChecklist tbNovo)
        {
            this.ValidarChecklistAsync(tbNovo);

            if(tbNovo.IdChecklist <= 0)
                throw new Exception("ID do Checklist inválido.");

            if(tbNovo.IdCartao <= 0)
                throw new Exception("Cartão não encontrado.");

            tbAtual = await checklistDb.AlterarChecklistAsync(tbAtual, tbNovo);

            return tbAtual;
        }

        public async Task<Models.TbChecklist> DeletarChecklistAsync(Models.TbChecklist tb)
        {
            return await checklistDb.DeletarChecklistAsync(tb);
        }
    }
}