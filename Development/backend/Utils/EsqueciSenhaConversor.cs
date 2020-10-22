using System;

namespace backend.Utils
{
    public class EsqueciSenhaConversor
    {
        public Models.TbEsqueciSenha ToTbEsqueciSenha(long codigo, Models.TbLogin usuario, string email)
        {
            Models.TbEsqueciSenha tb = new Models.TbEsqueciSenha();
            
            tb.DsEmail = email;
            tb.IdLogin = usuario.IdLogin;
            tb.NrCodigo = codigo;
            tb.TmInclusao = DateTime.Now;
            tb.TmExpiracao = DateTime.Now.AddMinutes(15);

            return tb;
        }

        public long ToCodigo(Models.Request.ValidarCodigoRecuperacaoRequest req)
        {
            return req.Codigo;
        }

        public long ToCodigo(Models.Request.DeletarCodigoRecuperacaoRequest req)
        {
            return req.Codigo;
        }

        public Models.Response.CodigoRecuperacaoResponse ToEsqueciSenhaResponse(Models.TbEsqueciSenha tb, Models.TbLogin tbLogin)
        {
            Models.Response.CodigoRecuperacaoResponse resp = new Models.Response.CodigoRecuperacaoResponse();

            resp.Email = tbLogin.DsEmail;
            resp.IdLogin = tb.IdLogin;

            return resp;
        }

        public Models.Response.ValidarCodigoRecuperacaoResponse ToValidarEsqueciSenhaResponse(Models.TbEsqueciSenha tb)
        {
            Models.Response.ValidarCodigoRecuperacaoResponse resp = new Models.Response.ValidarCodigoRecuperacaoResponse();

            resp.Valido = true;
            resp.IdLogin = tb.IdLogin;

            return resp;
        }

        public Models.Response.DeletarCodigoRecuperacaoResponse ToDeletarEsqueciSenhaResponse(Models.TbEsqueciSenha req)
        {
            Models.Response.DeletarCodigoRecuperacaoResponse resp = new Models.Response.DeletarCodigoRecuperacaoResponse();

            resp.Codigo = req.NrCodigo;

            return resp;
        }
    }
}