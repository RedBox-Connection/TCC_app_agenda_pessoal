using System;

namespace backend.Utils
{
    public class EsqueciSenhaConversor
    {
        public Models.TbEsqueciSenha ToTbEsqueciSenha(Models.Request.CodigoRecupecaoRequest req)
        {
            Models.TbEsqueciSenha tb = new Models.TbEsqueciSenha();
            
            tb.TmInclusao = DateTime.Now;
            tb.TmExpiracao = DateTime.Now.AddMinutes(15);

            return tb;
        }

        public Models.Response.CodigoRecuperacaoResponse ToEsqueciSenhaResponse(Models.TbEsqueciSenha tb)
        {
            Models.Response.CodigoRecuperacaoResponse resp = new Models.Response.CodigoRecuperacaoResponse();

            resp.Email = tb.IdLoginNavigation.DsEmail;
            resp.IdLogin = tb.IdLogin;

            return resp;
        }
    }
}