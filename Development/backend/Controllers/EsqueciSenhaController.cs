using System;

using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EsqueciSenhaController : ControllerBase
    {
        Business.EsqueciSenhaBusiness esqueciSenhaBsn = new Business.EsqueciSenhaBusiness();
        Utils.EsqueciSenhaConversor esqueciSenhaCnv = new Utils.EsqueciSenhaConversor();

        [HttpPut("recuperar-senha")]
        public async Task<ActionResult<Models.Response.CodigoRecuperacaoResponse>> GerarCodigoAsync(Models.Request.CodigoRecupecaoRequest req)
        {
            try
            {
                Models.TbEsqueciSenha tbEsqueciSenha = esqueciSenhaCnv.ToTbEsqueciSenha(req);

                tbEsqueciSenha = await esqueciSenhaBsn.GerarCodigoRecuperacaoAsync(tbEsqueciSenha);

                Models.Response.CodigoRecuperacaoResponse resp = esqueciSenhaCnv.ToEsqueciSenhaResponse(tbEsqueciSenha);

                return resp;
            }
            catch(Exception ex)
            {
                return BadRequest(
                    new Models.Response.ErroResponse(400, ex.Message)
                );
            }
        }
        
    }
}