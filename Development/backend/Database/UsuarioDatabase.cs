using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

using System.Threading.Tasks;


namespace backend.Database
{
    public class UsuarioDatabase
    {
        Models.tccdbContext ctx = new Models.tccdbContext();

        public async Task<Models.TbUsuario> CadastrarUsuarioAsync(Models.TbUsuario req)
        {
            await ctx.TbUsuario.AddAsync(req);
            await ctx.SaveChangesAsync();

            return req;
        }

        public async Task<Models.TbLogin> CadastrarLoginAsync(Models.TbLogin req)
        {
            await ctx.TbLogin.AddAsync(req);
            await ctx.SaveChangesAsync();

            return req;
        }

        public async Task<Models.TbLogin> LoginAsync(Models.TbLogin req)
        {
            return await ctx.TbLogin
                                     .Include(x => x.TbEsqueciSenha)
                                     .Include(x => x.TbUsuario)
                                     .FirstOrDefaultAsync(x => x.DsEmail == req.DsEmail && x.DsSenha == req.DsSenha);
        }
    }
}