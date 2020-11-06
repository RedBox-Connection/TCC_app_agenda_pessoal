using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

using System.Threading.Tasks;


namespace backend.Business
{
    public class CartaoComentarioBusiness
    {
        Database.CartaoComentarioDatabase cartaoComentarioDb = new Database.CartaoComentarioDatabase();
        public void ValidarComentarioCartaoRequest(Models.TbCartaoComentario tb)
        {
            if(tb.DsComentario == string.Empty)
                throw new Exception("O Comentario não pode estra vazio.");

            if(tb.DtInclusao > DateTime.Now)
                throw new Exception("A Data esta invalida.");
            
            if(tb.IdCartao <= 0)
                throw new Exception("ID do quadro Invalido.");

            if(tb.IdUsuario <= 0)
                throw new Exception("ID do usuario invalido.");
        }

        public async Task<Models.TbCartaoComentario> AdicionarComentarioCartaoAsync(Models.TbCartaoComentario tb)
        {
            this.ValidarComentarioCartaoRequest(tb);

            tb = await cartaoComentarioDb.AdicionarComentarioCartaoAsync(tb);

            if(tb.IdComentario <= 0)
                throw new Exception("ID do comentario invalido.");

            return tb;
        }

        public async Task<List<Models.TbCartaoComentario>> ConsutarComentarioPorIdCartaoAsync(int idCartao)
        {
            if(idCartao <= 0)
                throw new Exception("ID do Cartao invalido.");

            List<Models.TbCartaoComentario> lista = await cartaoComentarioDb.ConsutarComentarioPorIdCartaoAsync(idCartao);

            if(lista.Count() <= 0)
                throw new Exception("Não há comentario nesse cartão.");

            return lista;
        }

        public async Task<Models.TbCartaoComentario> ConsutarComentarioPorIdLoginAsync(int idLogin)
        {
            if(idLogin <= 0)
                throw new Exception("ID do Login invalido.");

            Models.TbCartaoComentario tbComentario = await cartaoComentarioDb.ConsutarComentarioPorIdLoginAsync(idLogin);

            return tbComentario;
        }

        public async Task<Models.TbCartaoComentario> AlterarComentarioPorIdLoginAsync(int idLogin, Models.TbCartaoComentario atual, Models.TbCartaoComentario novo)
        {
            this.ValidarComentarioCartaoRequest(atual);
            this.ValidarComentarioCartaoRequest(novo);
            
            if(atual.IdUsuarioNavigation.IdLogin != idLogin)
                throw new Exception("Esse comentario não é seu.");
            
            if(atual.DtInclusao.AddDays(1) < DateTime.Now)
                throw new Exception("Esse comentario não pode mais ser alterado.");
            
            atual = await cartaoComentarioDb.AlterarComentarioPorIdLoginAsync(idLogin, atual, novo);

            return atual;
        }

        public async Task<Models.TbCartaoComentario> DeletarComentarioPorIdLoginAsync(int idLogin, Models.TbCartaoComentario tb)
        {
            if(tb.IdUsuarioNavigation.IdLogin != idLogin)
                throw new Exception("Esse comentario não é seu.");

            return await cartaoComentarioDb.DeletarComentarioPorIdLoginAsync(tb);
        }
    }
}