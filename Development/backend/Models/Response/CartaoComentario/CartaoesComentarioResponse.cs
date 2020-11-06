using System;
using System.Collections;
using System.Collections.Generic;


namespace backend.Models.Response
{
    public class CartaoesComentarioResponse
    {
        public List<Models.Response.CartaoComentarioResponse> Cartoes { get; set; }

        public CartaoesComentarioResponse (List<Models.Response.CartaoComentarioResponse> cartoes)
        {
            this.Cartoes = cartoes;
        }
    }
}